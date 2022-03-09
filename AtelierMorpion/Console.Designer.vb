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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ServeurToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DémarrerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArrêterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JoueursToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.LB_Logs = New System.Windows.Forms.ListBox()
        Me.TimerClientListDisplay = New System.Windows.Forms.Timer(Me.components)
        Me.DGV_ClientList = New System.Windows.Forms.DataGridView()
        Me.ColumnID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnPseudo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnIP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnPing = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DGV_ClientList, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DGV_ClientList)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.LB_Logs)
        Me.SplitContainer1.Size = New System.Drawing.Size(633, 278)
        Me.SplitContainer1.SplitterDistance = 300
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
        Me.LB_Logs.Size = New System.Drawing.Size(329, 278)
        Me.LB_Logs.TabIndex = 0
        '
        'TimerClientListDisplay
        '
        Me.TimerClientListDisplay.Interval = 500
        '
        'DGV_ClientList
        '
        Me.DGV_ClientList.AllowUserToAddRows = False
        Me.DGV_ClientList.AllowUserToDeleteRows = False
        Me.DGV_ClientList.AllowUserToOrderColumns = True
        Me.DGV_ClientList.AllowUserToResizeRows = False
        Me.DGV_ClientList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV_ClientList.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DGV_ClientList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_ClientList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnID, Me.ColumnPseudo, Me.ColumnIP, Me.ColumnPing})
        Me.DGV_ClientList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_ClientList.GridColor = System.Drawing.Color.Black
        Me.DGV_ClientList.Location = New System.Drawing.Point(0, 0)
        Me.DGV_ClientList.Name = "DGV_ClientList"
        Me.DGV_ClientList.ReadOnly = True
        Me.DGV_ClientList.RowHeadersVisible = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.DGV_ClientList.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_ClientList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV_ClientList.Size = New System.Drawing.Size(300, 278)
        Me.DGV_ClientList.TabIndex = 0
        '
        'ColumnID
        '
        Me.ColumnID.HeaderText = "GUID"
        Me.ColumnID.Name = "ColumnID"
        Me.ColumnID.ReadOnly = True
        Me.ColumnID.Visible = False
        '
        'ColumnPseudo
        '
        Me.ColumnPseudo.FillWeight = 110.0!
        Me.ColumnPseudo.HeaderText = "Pseudo"
        Me.ColumnPseudo.Name = "ColumnPseudo"
        Me.ColumnPseudo.ReadOnly = True
        '
        'ColumnIP
        '
        Me.ColumnIP.FillWeight = 120.0!
        Me.ColumnIP.HeaderText = "IP"
        Me.ColumnIP.Name = "ColumnIP"
        Me.ColumnIP.ReadOnly = True
        '
        'ColumnPing
        '
        Me.ColumnPing.FillWeight = 50.0!
        Me.ColumnPing.HeaderText = "Ping"
        Me.ColumnPing.Name = "ColumnPing"
        Me.ColumnPing.ReadOnly = True
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
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DGV_ClientList, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents TimerClientListDisplay As Timer
    Friend WithEvents DGV_ClientList As DataGridView
    Friend WithEvents ColumnID As DataGridViewTextBoxColumn
    Friend WithEvents ColumnPseudo As DataGridViewTextBoxColumn
    Friend WithEvents ColumnIP As DataGridViewTextBoxColumn
    Friend WithEvents ColumnPing As DataGridViewTextBoxColumn
End Class
