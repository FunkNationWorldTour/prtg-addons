Option Strict On
Option Explicit On
'
Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Threading


Public Class ReadXML

#Region " Events "
    Public Event WebResult(ByVal doc As XmlDocument, ByVal ErrorMessage As String)
#End Region

#Region " Membervars "
    Private _url As String
#End Region

#Region " Methods "

    Public Sub SendRequest(ByVal url As String)
        _url = url
        Dim t As Thread = New Thread(AddressOf GetXmlDocFromStream)
        t.Start()
    End Sub


    Private Sub GetXmlDocFromStream()
        Dim rssDoc As New XmlDocument

        Try
            Dim request As HttpWebRequest = CType(HttpWebRequest.Create(_url), HttpWebRequest)
            '//GK Set HTTP headers, user-agent property needed for some rss feeds
            With request
                .Timeout = 2000
                .Method = "GET"
                .ContentType = "text/xml"
                .UserAgent = "Mozilla 4.0"
            End With

            Using response As WebResponse = request.GetResponse
                Dim mem As New MemoryStream()
                Dim s As Stream = response.GetResponseStream()

                Dim readStream As New StreamReader(s, System.Text.Encoding.UTF8)

                rssDoc.LoadXml(readStream.ReadToEnd)
                s.Close()
                readStream.Close()
            End Using
            RaiseEvent WebResult(rssDoc, Nothing)
        Catch ex As Exception
            RaiseEvent WebResult(Nothing, ex.Message)
        End Try
    End Sub
#End Region
End Class

