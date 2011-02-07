Imports System.IO
Imports System.Text
Imports System.Security.Cryptography


Public Class Globals
#Region " Membervars "
    Public Const urlAlarms As String = "http://[server]/api/table.xml?content=sensors&columns=objid,downtimetime,device,sensor,lastvalue,status,message,group&filter_status=4&filter_status=5&filter_status=7&filter_status=8&sortby=group&username=[username]&password=[password]"
    Public Const urlPauseDevice As String = "http://[server]/api/pause.htm?id=[objid]&action=0&username=[username]&password=[password]"
    Public Const urlResumeDevice As String = "http://[server]/api/pause.htm?id=[objid]&action=1&username=[username]&password=[password]"
    Private Const _iniFile As String = "\Notifier.ini"
#End Region

#Region " Propertys "
    Private Shared _server As String = ""
    Public Shared Property Server() As String
        Get
            Return _server
        End Get
        Set(ByVal value As String)
            _server = value
        End Set
    End Property

    Private Shared _user As String = ""
    Public Shared Property User() As String
        Get
            Return _user
        End Get
        Set(ByVal value As String)
            _user = value
        End Set
    End Property

    Private Shared _password As String = ""
    Public Shared Property Password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property
#End Region

#Region " Methods "
    Public Shared Sub LoadSettings()
        If File.Exists(_iniFile) Then
            Dim fs As FileStream = File.OpenRead(_iniFile)
            Dim sr As New StreamReader(fs)
            Dim s As String = Decrypt(sr.ReadLine, "Geheim02")
            sr.Close()
            fs.Close()

            Dim regels As String() = s.Split(","c)

            If regels.Length = 3 Then
                _server = regels(0).Trim
                _user = regels(1).Trim
                _password = regels(2).Trim
            End If
        End If
    End Sub

    Public Shared Sub SaveSettings()
        If File.Exists(_iniFile) Then
            File.Delete(_iniFile)
        End If
        Dim fs As FileStream = File.Create(_iniFile)
        Dim sw As New StreamWriter(fs)
        sw.WriteLine(Encrypt(String.Format("{0},{1},{2}", Server, User, Password), "Geheim02"))
        sw.Flush()
        sw.Close()
        fs.Close()
    End Sub

    Public Shared Function formatURL(ByVal url As String, Optional ByVal SensorID As String = "") As String
        Return url.Replace("[server]", Globals.Server).Replace("[username]", Globals.User).Replace("[password]", Globals.Password).Replace("[objid]", SensorID)
    End Function


    Public Shared Function Decrypt(ByVal stringToDecrypt As String, ByVal sEncryptionKey As String) As String
        Dim inputByteArray(stringToDecrypt.Length) As Byte
        Dim key() As Byte = {}
        Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
        Try
            key = System.Text.Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8))
            Dim des As New DESCryptoServiceProvider()
            inputByteArray = Convert.FromBase64String(stringToDecrypt)
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(key, IV), _
                CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
            'Return encoding.GetString(ms.ToArray())
            Return encoding.GetString(ms.ToArray, 0, CInt(ms.Length))
        Catch e As Exception
            Return e.Message
        End Try
    End Function

    Public Shared Function Encrypt(ByVal stringToEncrypt As String, ByVal SEncryptionKey As String) As String
        Dim key() As Byte = {}
        Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
        Try
            key = System.Text.Encoding.UTF8.GetBytes(SEncryptionKey.Substring(0, 8))
            Dim des As New DESCryptoServiceProvider()
            Dim inputByteArray() As Byte = Encoding.UTF8.GetBytes( _
                stringToEncrypt)
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(key, IV), _
                CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())
        Catch e As Exception
            Return e.Message
        End Try
    End Function
#End Region

End Class
