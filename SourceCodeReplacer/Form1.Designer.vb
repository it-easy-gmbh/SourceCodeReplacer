<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ButtonRun = New System.Windows.Forms.Button()
        Me.TextBoxErgebnis = New System.Windows.Forms.TextBox()
        Me.TextBoxPfad = New System.Windows.Forms.TextBox()
        Me.LabelBasisPfad = New System.Windows.Forms.Label()
        Me.ComboBoxErweiterung = New System.Windows.Forms.ComboBox()
        Me.LabelErweiterung = New System.Windows.Forms.Label()
        Me.ButtonBrowse = New System.Windows.Forms.Button()
        Me.TextBoxErsetzen = New System.Windows.Forms.TextBox()
        Me.TextBoxSuchen = New System.Windows.Forms.TextBox()
        Me.LabelSuche = New System.Windows.Forms.Label()
        Me.LabelErsetzen = New System.Windows.Forms.Label()
        Me.LabelTreffer = New System.Windows.Forms.Label()
        Me.LabelCount = New System.Windows.Forms.Label()
        Me.ButtonDryRun = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButtonRun
        '
        Me.ButtonRun.Location = New System.Drawing.Point(713, 113)
        Me.ButtonRun.Name = "ButtonRun"
        Me.ButtonRun.Size = New System.Drawing.Size(75, 23)
        Me.ButtonRun.TabIndex = 0
        Me.ButtonRun.Text = "Run"
        Me.ButtonRun.UseVisualStyleBackColor = True
        '
        'TextBoxErgebnis
        '
        Me.TextBoxErgebnis.Location = New System.Drawing.Point(12, 142)
        Me.TextBoxErgebnis.Multiline = True
        Me.TextBoxErgebnis.Name = "TextBoxErgebnis"
        Me.TextBoxErgebnis.ReadOnly = True
        Me.TextBoxErgebnis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxErgebnis.Size = New System.Drawing.Size(776, 269)
        Me.TextBoxErgebnis.TabIndex = 1
        '
        'TextBoxPfad
        '
        Me.TextBoxPfad.Location = New System.Drawing.Point(147, 37)
        Me.TextBoxPfad.Name = "TextBoxPfad"
        Me.TextBoxPfad.Size = New System.Drawing.Size(396, 20)
        Me.TextBoxPfad.TabIndex = 1
        '
        'LabelBasisPfad
        '
        Me.LabelBasisPfad.AutoSize = True
        Me.LabelBasisPfad.Location = New System.Drawing.Point(23, 40)
        Me.LabelBasisPfad.Name = "LabelBasisPfad"
        Me.LabelBasisPfad.Size = New System.Drawing.Size(57, 13)
        Me.LabelBasisPfad.TabIndex = 2
        Me.LabelBasisPfad.Text = "Basis-Pfad"
        '
        'ComboBoxErweiterung
        '
        Me.ComboBoxErweiterung.FormattingEnabled = True
        Me.ComboBoxErweiterung.Items.AddRange(New Object() {"VB", "CS", "HTM", "HTML", "CSS", "XML"})
        Me.ComboBoxErweiterung.Location = New System.Drawing.Point(147, 63)
        Me.ComboBoxErweiterung.Name = "ComboBoxErweiterung"
        Me.ComboBoxErweiterung.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxErweiterung.TabIndex = 3
        '
        'LabelErweiterung
        '
        Me.LabelErweiterung.AutoSize = True
        Me.LabelErweiterung.Location = New System.Drawing.Point(23, 66)
        Me.LabelErweiterung.Name = "LabelErweiterung"
        Me.LabelErweiterung.Size = New System.Drawing.Size(63, 13)
        Me.LabelErweiterung.TabIndex = 2
        Me.LabelErweiterung.Text = "Erweiterung"
        '
        'ButtonBrowse
        '
        Me.ButtonBrowse.Location = New System.Drawing.Point(549, 35)
        Me.ButtonBrowse.Name = "ButtonBrowse"
        Me.ButtonBrowse.Size = New System.Drawing.Size(26, 23)
        Me.ButtonBrowse.TabIndex = 0
        Me.ButtonBrowse.Text = "..."
        Me.ButtonBrowse.UseVisualStyleBackColor = True
        '
        'TextBoxErsetzen
        '
        Me.TextBoxErsetzen.Location = New System.Drawing.Point(147, 116)
        Me.TextBoxErsetzen.Name = "TextBoxErsetzen"
        Me.TextBoxErsetzen.Size = New System.Drawing.Size(396, 20)
        Me.TextBoxErsetzen.TabIndex = 4
        '
        'TextBoxSuchen
        '
        Me.TextBoxSuchen.Location = New System.Drawing.Point(147, 90)
        Me.TextBoxSuchen.Name = "TextBoxSuchen"
        Me.TextBoxSuchen.Size = New System.Drawing.Size(396, 20)
        Me.TextBoxSuchen.TabIndex = 4
        '
        'LabelSuche
        '
        Me.LabelSuche.AutoSize = True
        Me.LabelSuche.Location = New System.Drawing.Point(23, 93)
        Me.LabelSuche.Name = "LabelSuche"
        Me.LabelSuche.Size = New System.Drawing.Size(74, 13)
        Me.LabelSuche.TabIndex = 2
        Me.LabelSuche.Text = "Suche nach..."
        '
        'LabelErsetzen
        '
        Me.LabelErsetzen.AutoSize = True
        Me.LabelErsetzen.Location = New System.Drawing.Point(23, 119)
        Me.LabelErsetzen.Name = "LabelErsetzen"
        Me.LabelErsetzen.Size = New System.Drawing.Size(87, 13)
        Me.LabelErsetzen.TabIndex = 2
        Me.LabelErsetzen.Text = "Ersetzen durch..."
        '
        'LabelTreffer
        '
        Me.LabelTreffer.Location = New System.Drawing.Point(12, 428)
        Me.LabelTreffer.Name = "LabelTreffer"
        Me.LabelTreffer.Size = New System.Drawing.Size(44, 13)
        Me.LabelTreffer.TabIndex = 2
        Me.LabelTreffer.Text = "Treffer:"
        '
        'LabelCount
        '
        Me.LabelCount.Location = New System.Drawing.Point(62, 428)
        Me.LabelCount.Name = "LabelCount"
        Me.LabelCount.Size = New System.Drawing.Size(70, 13)
        Me.LabelCount.TabIndex = 2
        Me.LabelCount.Text = "100"
        '
        'ButtonDryRun
        '
        Me.ButtonDryRun.Location = New System.Drawing.Point(713, 84)
        Me.ButtonDryRun.Name = "ButtonDryRun"
        Me.ButtonDryRun.Size = New System.Drawing.Size(75, 23)
        Me.ButtonDryRun.TabIndex = 0
        Me.ButtonDryRun.Text = "Dry-Run"
        Me.ButtonDryRun.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TextBoxSuchen)
        Me.Controls.Add(Me.TextBoxErsetzen)
        Me.Controls.Add(Me.ComboBoxErweiterung)
        Me.Controls.Add(Me.LabelCount)
        Me.Controls.Add(Me.LabelTreffer)
        Me.Controls.Add(Me.LabelErsetzen)
        Me.Controls.Add(Me.LabelSuche)
        Me.Controls.Add(Me.LabelErweiterung)
        Me.Controls.Add(Me.LabelBasisPfad)
        Me.Controls.Add(Me.TextBoxPfad)
        Me.Controls.Add(Me.ButtonBrowse)
        Me.Controls.Add(Me.TextBoxErgebnis)
        Me.Controls.Add(Me.ButtonDryRun)
        Me.Controls.Add(Me.ButtonRun)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonRun As Button
    Friend WithEvents TextBoxErgebnis As TextBox
    Friend WithEvents TextBoxPfad As TextBox
    Friend WithEvents LabelBasisPfad As Label
    Friend WithEvents ComboBoxErweiterung As ComboBox
    Friend WithEvents LabelErweiterung As Label
    Friend WithEvents ButtonBrowse As Button
    Friend WithEvents TextBoxErsetzen As TextBox
    Friend WithEvents TextBoxSuchen As TextBox
    Friend WithEvents LabelSuche As Label
    Friend WithEvents LabelErsetzen As Label
    Friend WithEvents LabelTreffer As Label
    Friend WithEvents LabelCount As Label
    Friend WithEvents ButtonDryRun As Button
End Class
