Imports System
Imports System.Net
Imports System.Text
Imports System.Net.Sockets
Imports System.Threading
Imports System.Collections.Generic

Public Class Smartboard
    Structure aline
        Public x1 As Integer
        Public y1 As Integer
        Public x2 As Integer
        Public y2 As Integer
    End Structure
    Dim new_line As Boolean
    Dim connected As Boolean
    Dim drawing As New List(Of aline)
    Dim x1, y1, x2, y2 As Integer
    Dim udpClient As New UdpClient
    Dim GLOIP As IPAddress
    Dim GLOINTPORT As Integer
    Public receiveUdpClient As UdpClient
    Public RemoteIPEndPoint As New IPEndPoint(IPAddress.Any, 0)
    Public ThreadReceive As Thread
    Public ReceivedCommand As String
    Public ReceivedMessage As String
    Public Received As Boolean
    Public ListenPort As Integer
    Public run_thread As Boolean = True
    Public receiveClose As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClientSize = New Size(800, 600)
        new_line = False
        DoubleBuffered = True
        Received = False
        connected = False
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        x1 = e.X
        y1 = e.Y
        new_line = True
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        x2 = e.X
        y2 = e.Y
        Dim line As New aline
        line.x1 = x1
        line.x2 = x2
        line.y1 = y1
        line.y2 = y2
        drawing.Add(line)
        new_line = False
        Send_Coordinate(x1, y1, x2, y2)
        Invalidate()
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If new_line Then
            x2 = e.X
            y2 = e.Y
            Dim line As New aline
            line.x1 = x1
            line.x2 = x2
            line.y1 = y1
            line.y2 = y2
            drawing.Add(line)
            Send_Coordinate(x1, y1, x2, y2)
            x1 = x2
            y1 = y2
            Invalidate()
        End If
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim g As Graphics = e.Graphics
        Dim draw As aline
        If Received Then
            Received = False

            Select Case ReceivedCommand
                Case = "Message"
                    Conversation_ListBox.Items.Add(ReceivedMessage)
                Case = "Close"
                    Conversation_ListBox.Items.Add("Connected user is closing the application")
                    Thread.Sleep(3000)
                    Application.Exit()
                Case = "Draw"
                    draw.x1 = Integer.Parse(ReceivedMessage.Substring(ReceivedMessage.IndexOf("(") + 1, ReceivedMessage.IndexOf(",") - (ReceivedMessage.IndexOf("(") + 1)))
                    draw.y1 = Integer.Parse(ReceivedMessage.Substring(ReceivedMessage.IndexOf(",") + 1, ReceivedMessage.IndexOf(")") - (ReceivedMessage.IndexOf(",") + 1)))
                    draw.x2 = Integer.Parse(ReceivedMessage.Substring(ReceivedMessage.LastIndexOf("(") + 1, ReceivedMessage.LastIndexOf(",") - (ReceivedMessage.LastIndexOf("(") + 1)))
                    draw.y2 = Integer.Parse(ReceivedMessage.Substring(ReceivedMessage.LastIndexOf(",") + 1, ReceivedMessage.LastIndexOf(")") - (ReceivedMessage.LastIndexOf(",") + 1)))
                    drawing.Add(draw)
            End Select
        End If
        If new_line Then
            g.DrawLine(Pens.Blue, x1, y1, x2, y2)
        End If
        For Each line As aline In drawing
            g.DrawLine(Pens.Black, line.x1, line.y1, line.x2, line.y2)
        Next

    End Sub

    Private Sub Set_Button_Click(sender As Object, e As EventArgs) Handles Set_Button.Click
        GLOIP = IPAddress.Parse(BuddyIP.Text)
        GLOINTPORT = BuddyPort.Text

        If (MyPort.Text <> "") Then
            ListenPort = MyPort.Text

            'Create a receive thread
            ThreadReceive = New Thread(AddressOf ReceiveMessages)
            Received = False
            ThreadReceive.Start()
            Set_Button.Enabled = False
            connected = True
        Else
            Conversation_ListBox.Items.Add("Must set proper listening port!")
        End If




    End Sub

    Private Sub ReceiveMessages()
        Dim receivingUdpClient As New UdpClient(ListenPort)

        Do While run_thread
            Try
                Dim receiveBytes As Byte() = receivingUdpClient.Receive(RemoteIPEndPoint)

                'Convert the received message to human readable format
                Dim returnData As String = Encoding.ASCII.GetString(receiveBytes)

                'Figure out what is being sent:
                If (returnData.Substring(0, returnData.IndexOf(";")) = "Message") Then
                    ReceivedCommand = "Message"
                    returnData = returnData.Substring(8, returnData.Length - 8)
                ElseIf (returnData.Substring(0, returnData.IndexOf(";")) = "Close") Then
                    ReceivedCommand = "Close"
                    returnData = returnData.Substring(6, returnData.Length - 6)
                    receiveClose = True
                ElseIf (returnData.Substring(0, returnData.IndexOf(";")) = "Draw") Then
                    ReceivedCommand = "Draw"
                    returnData = returnData.Substring(5, returnData.Length - 5)
                End If

                'RemoteIdEndPoint is your buddy's IP address
                ReceivedMessage = RemoteIPEndPoint.Address.ToString() + " says: " + returnData

                'A message is received, set flag to true
                Received = True

                'Ask program to update the output
                Me.Invalidate()
            Catch ex As Exception
                ReceivedMessage = ex.ToString()
                Me.Invalidate()
            End Try
        Loop
    End Sub

    Private Sub Send_Abort()
        If connected Then

            Dim bytCommand As Byte() = New Byte() {}

            'Connect
            udpClient.Connect(GLOIP, GLOINTPORT)

            'Get message from I Say box, encode it
            bytCommand = Encoding.ASCII.GetBytes("Close;Connected user initiated close, application will close in 3 seconds!")

            'Send
            udpClient.Send(bytCommand, bytCommand.Length)

            If (receiveClose) Then
                Thread.Sleep(3000)
            Else
                Thread.Sleep(6000)
            End If

        End If
    End Sub

    Private Sub Send_Coordinate(x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer)
        If connected Then

            Dim bytCommand As Byte() = New Byte() {}

            'Connect
            udpClient.Connect(GLOIP, GLOINTPORT)

            'Get message from I Say box, encode it

            Dim tempLine As String
            tempLine = "(" + x1.ToString + "," + y1.ToString + ")(" + x2.ToString + "," + y2.ToString + ")"
            bytCommand = Encoding.ASCII.GetBytes("Draw;" + tempLine)
            'Send
            udpClient.Send(bytCommand, bytCommand.Length)


        End If
    End Sub

    Private Sub Send_Text(Message As String)
        If connected Then
            Dim bytCommand As Byte() = New Byte() {}

            'Connect
            udpClient.Connect(GLOIP, GLOINTPORT)

            'Get message from I Say box, encode it
            bytCommand = Encoding.ASCII.GetBytes(Message)

            'Send
            udpClient.Send(bytCommand, bytCommand.Length)
        End If

    End Sub

    Private Sub Smartboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If run_thread Then
            Send_Abort()
        End If
    End Sub

    Private Sub ISay_Box_KeyDown(sender As Object, e As KeyEventArgs) Handles ISay_Box.KeyDown
        If e.KeyValue = 13 Then
            e.SuppressKeyPress = True
            Send_Text("Message;" + ISay_Box.Text)
            ' Add your message to the conversation box
            Conversation_ListBox.Items.Add("I Say:" + ISay_Box.Text)
            ISay_Box.Text = ""
            Invalidate()
        End If
    End Sub
End Class
