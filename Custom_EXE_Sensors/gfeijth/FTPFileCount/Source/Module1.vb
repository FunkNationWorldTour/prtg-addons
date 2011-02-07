Imports System.Net
Imports System.Reflection.Assembly
Imports System.Diagnostics.FileVersionInfo



Module Module1
    Dim _user As String = ""
    Dim _password As String = ""
    Dim _url As String = ""

    Sub Main()
        GetCommandLineInput()

        GetFileCount()
    End Sub

    ''' <summary>
    ''' Gets the username, password and url from the commandline.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetCommandLineInput()
        Dim Args As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs

        If Args Is Nothing Then ShowHelp()

        For Each s As String In Args
            If s.Length > 3 Then
                Select Case s.Substring(0, 3)
                    Case "-u:"
                        _user = s.Substring(3)
                    Case "-p:"
                        _password = s.Substring(3)
                    Case Else
                        _url = s
                End Select
            End If
        Next

        If _user = "" Or _password = "" Or _url = "" Then ShowHelp()

        '//GF correct user input
        If Not _url.EndsWith("/") Then _url &= "/"
        _url = _url.Replace("ftp:", "").Replace("//", "").Replace("\\", "")
        _url = _url.Replace("\", "/")
    End Sub

    ''' <summary>
    ''' Counts the files on the ftp server.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetFileCount()
        Try
            Dim request As FtpWebRequest = CType(WebRequest.Create(String.Format("ftp://{0}", _url)), FtpWebRequest)
            With request
                .Credentials = New System.Net.NetworkCredential(_user, _password)
                .Method = WebRequestMethods.Ftp.ListDirectoryDetails
            End With

            Dim filecount As Integer = 0
            Using response As FtpWebResponse = CType(request.GetResponse, FtpWebResponse)
                Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream, System.Text.Encoding.UTF8)
                Dim result As String = sr.ReadToEnd
                Dim files() As String = result.Split(Convert.ToChar(13))
                response.Close()

                For Each s As String In files
                    If Not s.Trim = "" AndAlso Not s.Trim.StartsWith("d") Then
                        filecount += 1
                    End If
                Next
            End Using
            System.Console.WriteLine(filecount & ":" & filecount & " Files")
            Environment.ExitCode = Math.Min(filecount, 1)
        Catch ex As Exception
            System.Console.WriteLine(-1 & ":" & ex.Message)
            Environment.ExitCode = 2
        End Try

    End Sub

    ''' <summary>
    ''' Provides program usage to the user.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowHelp()
        Dim vi As FileVersionInfo = GetVersionInfo(GetExecutingAssembly.Location)

        System.Console.WriteLine(String.Format("{0} {1}.{2}.{3}", vi.FileDescription, vi.ProductMajorPart, vi.ProductMinorPart, vi.ProductBuildPart))
        System.Console.WriteLine()
        System.Console.WriteLine(vi.FileDescription & " -u:username -p:password url")
        System.Console.WriteLine()
        System.Console.WriteLine("-u:   username for the FTP login")
        System.Console.WriteLine("-p:   password for the FTP login")
        System.Console.WriteLine("url   server/share [10.0.0.10/upload]")
        System.Console.WriteLine()
        Environment.Exit(-1)
    End Sub

End Module
