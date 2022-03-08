<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Console
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ServeurToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DémarrerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArrêterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JoueursToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.LB_Logs = New System.Windows.Forms.ListBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ServeurToolStripMenuItem, Me.JoueursToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(633, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ServeurToolStripMenuItem
        '
        Me.ServeurToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DémarrerToolStripMenuItem, Me.ArrêterToolStripMenuItem})
        Me.ServeurToolStripMenuItem.Name = "ServeurToolStripMenuItem"
        Me.ServeurToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ServeurToolStripMenuItem.Text = "Serveur"
        '
        'DémarrerToolStripMenuItem
        '
        Me.DémarrerToolStripMenuItem.Name = "DémarrerToolStripMenuItem"
        Me.DémarrerToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.DémarrerToolStripMenuItem.Text = "Démarrer"
        '
        'ArrêterToolStripMenuItem
        '
        Me.ArrêterToolStripMenuItem.Name = "ArrêterToolStripMenuItem"
        Me.ArrêterToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.ArrêterToolStripMenuItem.Text = "Arrêter"
        '
        'JoueursToolStripMenuItem
        '
        Me.JoueursToolStripMenuItem.Name = "JoueursToolStripMenuItem"
        Me.JoueursToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.JoueursToolStripMenuItem.Text = "Joueurs"
        '
        'PanelBottom
        '
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 302)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(633, 41)
        Me.PanelBottom.TabIndex = 1
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.LB_Logs)
        Me.SplitContainer1.Size = New System.Drawing.Size(633, 278)
        Me.SplitContainer1.SplitterDistance = 211
        Me.SplitContainer1.TabIndex = 2
        '
        'LB_Logs
        '
        Me.LB_Logs.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LB_Logs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_Logs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LB_Logs.ForeColor = System.Drawing.Color.White
        Me.LB_Logs.FormattingEnabled = True
        Me.LB_Logs.Location = New System.Drawing.Point(0, 0)
        Me.LB_Logs.Name = "LB_Logs"
        Me.LB_Logs.Size = New System.Drawing.Size(418, 278)
        Me.LB_Logs.TabIndex = 0
        '
        'Console
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(633, 343)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.PanelBottom)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Console"
        Me.ShowIcon = False
        Me.Text = "Serveur Morpion - Atelier EPSI Dev B3 G2"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ServeurToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DémarrerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ArrêterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents JoueursToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PanelBottom As Panel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents LB_Logs As ListBox
End Class
