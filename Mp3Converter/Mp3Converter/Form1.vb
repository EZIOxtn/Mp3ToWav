Imports System.IO
Imports NAudio.Wave

Public Class Form1
    Public gex As String
    Public bol As Boolean = False
    Sub Main()
        InitializeComponent()
    End Sub
    Private Sub Guna2CustomGradientPanel1_Paint(sender As Object, e As DragEventArgs) Handles Guna2CustomGradientPanel1.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim files As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())

            If files.Length > 0 Then
                Dim filePath As String = files(0)

                Label1.Text = "Ready"
                gex = filePath
                bol = True
            End If
        End If

    End Sub
    Private Sub Guna2CstomGradientPanel1_Paint(sender As Object, e As DragEventArgs) Handles Guna2CustomGradientPanel1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
        Guna2CustomGradientPanel1.FillColor = Color.Black
        Guna2CustomGradientPanel1.FillColor4 = Color.Black
    End Sub
    Private Sub ld(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Settings.pth = Application.StartupPath
    End Sub
    Private Sub Guna2CustomGradientPaint(sender As Object, e As DragEventArgs) Handles Label1.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim files As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())

            If files.Length > 0 Then
                Dim filePath As String = files(0)


                Label1.Text = "Ready"
                gex = filePath
                bol = True
            End If
        End If

    End Sub
    Private Sub Guna2CstomGradienl1_Paint(sender As Object, e As DragEventArgs) Handles Label1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
        Guna2CustomGradientPanel1.FillColor = Color.Black
        Guna2CustomGradientPanel1.FillColor4 = Color.Black
    End Sub
    Private Sub Guna2CstomGradientPanel1_Pat(sender As Object, e As DragEventArgs) Handles Guna2CustomGradientPanel1.DragLeave
        Guna2CustomGradientPanel1.FillColor = Color.FromArgb(64, 0, 0)
        Guna2CustomGradientPanel1.FillColor4 = Color.FromArgb(0, 0, 64)
    End Sub
    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton1.Click
        If Not bol Then
            MsgBox("select a file first")
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(gex) Then
            Dim inputFile As String = gex
            Dim outputFileName As String = Path.GetFileNameWithoutExtension(inputFile) & ".ogg"
            Dim outputPath As String = Path.Combine(My.Settings.pth, outputFileName)
            If File.Exists(inputFile) Then
                If Path.GetExtension(inputFile).Equals(".mp3", StringComparison.OrdinalIgnoreCase) Then
                    Try
                        Using reader As New Mp3FileReader(inputFile)
                            Using writer As New WaveFileWriter(outputPath, reader.WaveFormat)
                                Dim buffer(1024) As Byte
                                Dim bytesRead As Integer
                                Dim totalBytesRead As Long = 0
                                Dim totalBytes As Long = reader.Length

                                Do
                                    bytesRead = reader.Read(buffer, 0, buffer.Length)
                                    writer.Write(buffer, 0, bytesRead)
                                    totalBytesRead += bytesRead
                                    Dim progressPercentage As Integer = CInt((totalBytesRead / totalBytes) * 100)
                                    Label1.Text = $"Progress: {progressPercentage}%"
                                    Application.DoEvents()
                                Loop While bytesRead > 0
                            End Using
                        End Using

                        Label1.Text = "finish"
                        Guna2CustomGradientPanel1.FillColor = Color.FromArgb(64, 0, 0)
                        Guna2CustomGradientPanel1.FillColor4 = Color.FromArgb(0, 0, 64)
                        Threading.Thread.Sleep(1000)
                        gex = ""
                        bol = False
                        Guna2CustomGradientPanel1.FillColor = Color.FromArgb(64, 0, 0)
                        Guna2CustomGradientPanel1.FillColor4 = Color.FromArgb(0, 0, 64)

                        Label1.Text = "Drop your mp3 here"
                    Catch ex As Exception
                        MessageBox.Show($"Error during conversion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                Else
                    MessageBox.Show("Only MP3 files can be converted to OGG.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("File not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            Label1.Text = "Select a file first"
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim op As New FolderBrowserDialog()
        If op.ShowDialog() = DialogResult.OK Then
            If op IsNot Nothing Then
                My.Settings.pth = op.SelectedPath
            Else
                MsgBox("error", "no path selected")
            End If
        End If

    End Sub
End Class
