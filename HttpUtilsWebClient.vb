Imports System.Net
Public Class HttpUtilsWebClient
        Inherits WebClient

        Friend Property Response As HttpWebResponse

        Friend Property Timeout As Integer

        Protected Overrides Function GetWebRequest(ByVal address As Uri) As WebRequest
            Dim request = TryCast(MyBase.GetWebRequest(address), HttpWebRequest)
            request.Timeout = Timeout
            Return request
        End Function
        Protected Overrides Function GetWebResponse(ByVal request As WebRequest) As WebResponse
            Response = TryCast(MyBase.GetWebResponse(request), HttpWebResponse)
            Return Response
        End Function

        Protected Overrides Function GetWebResponse(ByVal request As WebRequest, ByVal result As System.IAsyncResult) As WebResponse
            Response = TryCast(MyBase.GetWebResponse(request, result), HttpWebResponse)
            Return Response
        End Function
    End Class
