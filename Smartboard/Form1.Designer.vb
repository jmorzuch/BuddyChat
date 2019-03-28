<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smartboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Conversation_ListBox = New System.Windows.Forms.ListBox()
        Me.MyPort = New System.Windows.Forms.TextBox()
        Me.BuddyPort = New System.Windows.Forms.TextBox()
        Me.BuddyIP = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Set_Button = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ISay_Box = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.Conversation_ListBox)
        Me.Panel1.Controls.Add(Me.MyPort)
        Me.Panel1.Controls.Add(Me.BuddyPort)
        Me.Panel1.Controls.Add(Me.BuddyIP)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Set_Button)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ISay_Box)
        Me.Panel1.Location = New System.Drawing.Point(1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(237, 561)
        Me.Panel1.TabIndex = 0
        '
        'Conversation_ListBox
        '
        Me.Conversation_ListBox.Enabled = False
        Me.Conversation_ListBox.FormattingEnabled = True
        Me.Conversation_ListBox.Location = New System.Drawing.Point(7, 158)
        Me.Conversation_ListBox.Name = "Conversation_ListBox"
        Me.Conversation_ListBox.Size = New System.Drawing.Size(225, 329)
        Me.Conversation_ListBox.TabIndex = 14
        '
        'MyPort
        '
        Me.MyPort.Location = New System.Drawing.Point(102, 69)
        Me.MyPort.Name = "MyPort"
        Me.MyPort.Size = New System.Drawing.Size(121, 20)
        Me.MyPort.TabIndex = 13
        '
        'BuddyPort
        '
        Me.BuddyPort.Location = New System.Drawing.Point(64, 45)
        Me.BuddyPort.Name = "BuddyPort"
        Me.BuddyPort.Size = New System.Drawing.Size(159, 20)
        Me.BuddyPort.TabIndex = 12
        '
        'BuddyIP
        '
        Me.BuddyIP.Location = New System.Drawing.Point(64, 20)
        Me.BuddyIP.Name = "BuddyIP"
        Me.BuddyIP.Size = New System.Drawing.Size(159, 20)
        Me.BuddyIP.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Conversation"
        '
        'Set_Button
        '
        Me.Set_Button.Location = New System.Drawing.Point(6, 95)
        Me.Set_Button.Name = "Set_Button"
        Me.Set_Button.Size = New System.Drawing.Size(226, 23)
        Me.Set_Button.TabIndex = 9
        Me.Set_Button.Text = "Set"
        Me.Set_Button.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "My Listening Port:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Buddy Port:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Buddy IP:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 499)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "I Say:"
        '
        'ISay_Box
        '
        Me.ISay_Box.Location = New System.Drawing.Point(7, 518)
        Me.ISay_Box.Name = "ISay_Box"
        Me.ISay_Box.Size = New System.Drawing.Size(216, 20)
        Me.ISay_Box.TabIndex = 3
        '
        'Smartboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Smartboard"
        Me.Text = "Smartboard By Dr.  Lin"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ISay_Box As System.Windows.Forms.TextBox
    Friend WithEvents MyPort As System.Windows.Forms.TextBox
    Friend WithEvents BuddyPort As System.Windows.Forms.TextBox
    Friend WithEvents BuddyIP As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Set_Button As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Conversation_ListBox As System.Windows.Forms.ListBox

End Class
