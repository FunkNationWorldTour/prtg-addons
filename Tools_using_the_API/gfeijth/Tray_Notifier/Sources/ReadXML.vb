Option Strict On
Option Explicit On
'
Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Threading


Public Class ReadXML

#Region " Events "
    Public Event WebResult(ByVal doc As XmlDocument, ByVal ex As Exception)
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
        Dim noCachePolicy As Cache.HttpRequestCachePolicy = New Cache.HttpRequestCachePolicy(Cache.HttpRequestCacheLevel.NoCacheNoStore)
        Dim rssDoc As New XmlDocument

        Try
            Dim request As HttpWebRequest = CType(HttpWebRequest.Create(_url), HttpWebRequest)
            '//GK Set HTTP headers, user-agent property needed for some rss feeds
            With request
                .Timeout = 5000
                .Method = "GET"
                .ContentType = "text/xml"
                .Headers.Add(HttpRequestHeader.CacheControl, "max-age=0")
                .UserAgent = "Mozilla 4.0"
                .CachePolicy = noCachePolicy
            End With

            Using response As WebResponse = request.GetResponse()
                Dim mem As New MemoryStream()
                Dim s As Stream = response.GetResponseStream()

                While (True)
                    Dim i As Integer = s.ReadByte()
                    If i < 0 Then Exit While
                    mem.WriteByte(CByte(i))
                End While
                mem.Flush()
                mem.Position = 0

                Dim xtReader As New XmlTextReader(mem)

                Try
                    xtReader.MoveToContent()
                Catch ex As XmlException
                    '//GF returned an empty page
                    xtReader.Close()
                    RaiseEvent WebResult(Nothing, Nothing)
                    Exit Sub
                End Try

                Dim enc As System.Text.Encoding = xtReader.Encoding
                mem.Position = 0

                Dim reader As New StreamReader(mem, enc)

                Dim lolcatXml As String = reader.ReadToEnd()
                rssDoc.LoadXml(lolcatXml)
                xtReader.Close()
            End Using
            RaiseEvent WebResult(rssDoc, Nothing)
        Catch ex As Exception
            RaiseEvent WebResult(Nothing, ex)
        End Try
    End Sub
#End Region
End Class

