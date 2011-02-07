Imports System
Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Reflection
Imports System.Security.Cryptography


Public Class Globals
#Region " Membervars "
    Private Const _urlStatus As String = "http://[server]/api/getstatus.xml?username=[username]&password=[password]"
    Private Const _urlAlarms As String = "http://[server]/api/table.xml?content=sensors&columns=objid,downtimetime,device,sensor,lastvalue,status,message,group&filter_status=4&filter_status=5&filter_status=7&filter_status=8&filter_status=9&filter_status=10&filter_status=11&sortby=group&username=[username]&password=[password]"
    Private Const _urlHomePage As String = "http://[server]/public/checklogin.htm?username=[username]&password=[password]"
    Private Const _urlDevicePage As String = "http://[server]/sensor.htm?id=[objid]&username=[username]&password=[password]"
    Private Const _urlPauseDevice As String = "http://[server]/api/pause.htm?id=[objid]&action=0&username=[username]&password=[password]"
    Private Const _urlResumeDevice As String = "http://[server]/api/pause.htm?id=[objid]&action=1&username=[username]&password=[password]"
    Private Const _urlScanNow As String = "http://[server]/api/scannow.htm?id=[objid]&username=[username]&password=[password]"

    Private Const saltRep As String = "Salting reply"
#End Region

#Region " Enums "
    Public Enum SensorStatus
        None = 0       'Should never happen
        Unknown = 1    'e.g. after startup
        Up = 3
        Warning = 4
        Alarms = 5
        NoProbe = 6
        Paused_By_User = 7
        Paused_By_Dependency = 8
        Paused_By_Schedule = 9
        Unusual = 10
        Paused_By_Licence = 11
        Paused_Until = 12
    End Enum
#End Region

#Region " Property's "
    Private Shared _WebserviceTimeout As Boolean = False
    Public Shared Property WebserviceTimeout() As Boolean
        Get
            Return _WebserviceTimeout
        End Get
        Set(ByVal value As Boolean)
            _WebserviceTimeout = value
        End Set
    End Property

    Private Shared _PRTGversion As String = ""
    Public Shared Property PRTGversion() As String
        Get
            Return _PRTGversion
        End Get
        Set(ByVal value As String)
            _PRTGversion = value
        End Set
    End Property

    Public Shared ReadOnly Property urlStatus() As String
        Get
            Return formatURL(_urlStatus)
        End Get
    End Property

    Public Shared ReadOnly Property urlAlarms() As String
        Get
            Return formatURL(_urlAlarms)
        End Get
    End Property

    Public Shared ReadOnly Property urlHomePage() As String
        Get
            Return formatURL(_urlHomePage)
        End Get
    End Property

    Public Shared ReadOnly Property urlDevicePage(ByVal objid As String) As String
        Get
            Return formatURL(_urlDevicePage, objid)
        End Get
    End Property

    Public Shared ReadOnly Property urlPauseDevice(ByVal objid As String) As String
        Get
            Return formatURL(_urlPauseDevice, objid)
        End Get
    End Property

    Public Shared ReadOnly Property urlResumeDevice(ByVal objid As String) As String
        Get
            Return formatURL(_urlResumeDevice, objid)
        End Get
    End Property

    Public Shared ReadOnly Property urlScanNow(ByVal objid As String) As String
        Get
            Return formatURL(_urlScanNow, objid)
        End Get
    End Property
#End Region

#Region " Methods "
    Private Shared _company As String = ""
    Public Shared Property RegisteredCompany() As String
        Get
            Return _company
        End Get
        Set(ByVal value As String)
            _company = value
        End Set
    End Property

    Private Shared _user As String
    Public Shared Property RegisteredUser() As String
        Get
            Return _user
        End Get
        Set(ByVal value As String)
            _user = value
        End Set
    End Property

    Private Shared _registered As Boolean
    Public Shared Property Registered() As Boolean
        Get
            Return _registered
        End Get
        Set(ByVal value As Boolean)
            _registered = value
            If Not value Then
                RegisteredCompany = ""
                RegisteredUser = ""
            End If
        End Set
    End Property

    Private Shared Function formatURL(ByVal url As String, Optional ByVal deviceId As String = "") As String
        Return url.Replace("[server]", My.Settings.Server).Replace("[username]", My.Settings.Username).Replace("[password]", Globals.Decrypt(My.Settings.Password, "Geheim01")).Replace("[objid]", deviceId)
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
            Return encoding.GetString(ms.ToArray())
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

    Public Shared Function TryDecode(ByVal codedString As String, ByVal showMessage As Boolean) As Boolean
        Dim s As String() = Globals.Decrypt(codedString, "Geheim01").Split(","c)
        If s.Length = 6 AndAlso s(0) = saltRep AndAlso s(5) = saltRep Then
            Dim keyAppVersion As String() = s(2).Split("."c)
            Dim myAppVersion As String() = Application.ProductVersion.Split("."c)
            If Not s(1) = My.Application.Info.ProductName OrElse Not keyAppVersion(0) = myAppVersion(0) OrElse Not keyAppVersion(1) = myAppVersion(1) Then
                If showMessage Then MessageBox.Show(String.Format("Invalid registration key for {0} version {1}.{2}", My.Application.Info.ProductName, myAppVersion(0), myAppVersion(1)), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Registered = False
            Else
                RegisteredCompany = s(3)
                RegisteredUser = s(4)
                File.WriteAllText(String.Format("{0}\Registration.bin", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)), codedString)
                Registered = True
            End If
        Else
            If showMessage Then MessageBox.Show("Invalid registration key " & My.Application.Info.ProductName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Registered = False
        End If

        Return Registered
    End Function

    Public Shared Function DecodeKey(ByVal codedString As String) As String()
        Dim s As String() = Globals.Decrypt(codedString, "Geheim01").Split(","c)
        If s.Length = 6 AndAlso s(0) = saltRep AndAlso s(5) = saltRep Then
            Dim keyAppVersion As String() = s(2).Split("."c)
            Dim myAppVersion As String() = Application.ProductVersion.Split("."c)
            If Not s(1) = My.Application.Info.ProductName OrElse Not keyAppVersion(0) = myAppVersion(0) OrElse Not keyAppVersion(1) = myAppVersion(1) Then
                Return Nothing
            Else
                Return New String() {s(3), s(4)}
            End If
        Else
            Return Nothing
        End If

    End Function

    Public Shared Sub CheckRegistration()
        Dim regFile As String = String.Format("{0}\Registration.bin", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
        If Not File.Exists(regFile) Then
            Registered = False
            Return
        End If
        TryDecode(File.ReadAllText(regFile), False)
    End Sub
#End Region
End Class
