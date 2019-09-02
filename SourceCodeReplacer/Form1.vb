Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Public Class Form1

    Private Extension As String
    Private SucheString As String
    Private ErsetzenString As String
    Private BasisPfad As String
    Private _Count As Integer

    Private Property Count As Integer
        Set(value As Integer)
            If value = 0 Then
                Me.LabelCount.Text = "0"
                _Count = 0
            Else
                _Count += value
                Me.LabelCount.Invoke(Sub() Me.LabelCount.Text = _Count)
            End If
        End Set
        Get
            Return _Count
        End Get
    End Property

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.LabelCount.Text = 0
    End Sub

    Private Sub ButtonRun_Click(sender As Object, e As EventArgs) Handles ButtonRun.Click
        SetzeVariablen()
        Dim t As New Task(Sub() Ersetzen(False))
        t.Start()
    End Sub

    Private Sub ButtonDryRun_Click(sender As Object, e As EventArgs) Handles ButtonDryRun.Click
        SetzeVariablen()
        Dim t As New Task(Sub() Ersetzen(True))
        t.Start()
    End Sub

    Private Sub SetzeVariablen()
        Me.SucheString = Me.TextBoxSuchen.Text
        Me.ErsetzenString = Me.TextBoxErsetzen.Text
        Me.BasisPfad = Me.TextBoxPfad.Text
        Me.Extension = Me.ComboBoxErweiterung.Text.ToLower
        Me.Count = 0
    End Sub

    Private Sub Ersetzen(DryRun As Boolean)
        If Not Directory.Exists(Me.BasisPfad) OrElse String.IsNullOrWhiteSpace(Me.Extension) OrElse String.IsNullOrWhiteSpace(Me.SucheString) OrElse String.IsNullOrWhiteSpace(Me.ErsetzenString) Then
            MsgBox("Alle notwendigen Felder füllen")
            Exit Sub
        End If
        Dim fileLIS As New List(Of FileInfo)
        AddFilesToList(Me.TextBoxPfad.Text, fileLIS)
        Dim sb As New StringBuilder
        For Each datei In fileLIS
            Try
                '>>> Prüfen, ob BOM vorhanden ist
                Dim bytes() As Byte = Nothing
                Using fsSource As FileStream = New FileStream(datei.FullName, FileMode.Open, FileAccess.Read)
                    bytes = New Byte(3) {}
                    Dim numBytesToRead As Integer = 3
                    Dim numBytesRead As Integer = 0
                    While (numBytesToRead > 0)
                        ' Read may return anything from 0 to numBytesToRead.
                        Dim n As Integer = fsSource.Read(bytes, numBytesRead, numBytesToRead)
                        ' Break when the end of the file is reached.
                        If (n = 0) Then
                            Exit While
                        End If
                        numBytesRead = (numBytesRead + n)
                        numBytesToRead = (numBytesToRead - n)
                    End While
                End Using
                Dim enc = New UTF8Encoding(True)
                Dim preamble = enc.GetPreamble()
                If preamble.Where(Function(p, i) p <> bytes(i)).Any() Then
                    '>>> Nur wenn kein UTF8-BOM vorhanden ist, Datei umwandeln:
                    Dim tmpCodierungsErgebnis As TextdateiRückgabe = TextdateiMitCodierungUTF8ohneBomOderAnsiKorrektLesen(datei.FullName)
                    If tmpCodierungsErgebnis.FehlerFlag = False Then
                        File.WriteAllText(datei.FullName, tmpCodierungsErgebnis.Text, Encoding.UTF8)
                    End If
                End If
                Dim count As Integer
                Dim content As String = File.ReadAllText(datei.FullName, Encoding.UTF8)
                count = Regex.Matches(content, Me.SucheString).Count
                If count > 0 Then
                    Me.Count = count
                    If DryRun = False Then
                        content = content.Replace(Me.SucheString, Me.ErsetzenString)
                        File.WriteAllText(datei.FullName, content, Encoding.UTF8)
                    End If
                    sb.AppendLine($"{datei.Name} ({count} Vorkommen)")
                    Me.TextBoxErgebnis.Invoke(Sub() Me.TextBoxErgebnis.Text = sb.ToString)
                End If
            Catch ex As Exception
                Stop
            End Try
        Next
    End Sub

    Private Sub AddFilesToList(Pfad As String, FileLIS As List(Of FileInfo))
        For Each file In Directory.GetFiles(Pfad, "*." & Me.Extension)
            FileLIS.Add(New FileInfo(file))
        Next
        For Each folder In Directory.GetDirectories(Pfad)
            AddFilesToList(folder, FileLIS)
        Next
    End Sub

    Private Sub ButtonBrowse_Click(sender As Object, e As EventArgs) Handles ButtonBrowse.Click
        Dim ddd As New FolderBrowserDialog
        If ddd.ShowDialog = DialogResult.OK Then
            Me.TextBoxPfad.Text = ddd.SelectedPath
        End If
    End Sub






#Region " Private Shared Function: TextdateiMitCodierungUTF8ohneBomOderAnsiKorrektLesen (Textdatei mit Codierung UTF8ohneBOM oder ANSI korrekt einlesen) "
    ''' <summary>
    ''' Bei Textdateien ohne BOM-Markierung am Anfang muss anhand des Inhalts entschieden werden, ob es sich um UTF8 oder ANSI handelt
    ''' </summary>
    ''' <param name="DateiPfad">Pfad zur Textdatei</param>
    ''' <returns>Struktur: Korrekt eingelesener Text bei Erfolg, sonst leerer Text, sowie Fehlerflag</returns>
    ''' <remarks></remarks>
    Private Shared Function TextdateiMitCodierungUTF8ohneBomOderAnsiKorrektLesen(ByVal DateiPfad As String) As TextdateiRückgabe
        Dim tmpBuilder As StringBuilder = New StringBuilder()
        Dim dateiBytes As Byte() = File.ReadAllBytes(DateiPfad)
        Dim utf8OhneBomDecoder As Decoder = Encoding.UTF8.GetDecoder()
        utf8OhneBomDecoder.Fallback = New DecoderExceptionFallback()
        Dim rückgabeStr As TextdateiRückgabe
        rückgabeStr.Text = ""
        rückgabeStr.FehlerFlag = False
        Try
            Dim decodiertedUtf8Chars As Char() = New Char(utf8OhneBomDecoder.GetCharCount(dateiBytes, 0, dateiBytes.Length, True) - 1) {}
            utf8OhneBomDecoder.GetChars(dateiBytes, 0, dateiBytes.Length, decodiertedUtf8Chars, 0)
            Array.ForEach(Of Char)(decodiertedUtf8Chars, Function(c) tmpBuilder.Append(c))
        Catch fallbackAufAnsiEx As DecoderFallbackException
            Dim ansiDecoder As Decoder = Encoding.[Default].GetDecoder()
            ansiDecoder.Fallback = New DecoderExceptionFallback()
            Try
                Dim decodedAnsiChars As Char() = New Char(ansiDecoder.GetCharCount(dateiBytes, 0, dateiBytes.Length, True) - 1) {}
                ansiDecoder.GetChars(dateiBytes, 0, dateiBytes.Length, decodedAnsiChars, 0)
                Array.ForEach(Of Char)(decodedAnsiChars, Function(c) tmpBuilder.Append(c))
            Catch keinPassenderDecoderEx As DecoderFallbackException
                rückgabeStr.FehlerFlag = True
            End Try
        End Try
        '>>> Text in Struktur speichern
        rückgabeStr.Text = tmpBuilder.ToString
        '>>> R E T U R N
        Return rückgabeStr
    End Function
    Private Structure TextdateiRückgabe
        Public Text As String
        Public FehlerFlag As Boolean
    End Structure
#End Region

End Class
