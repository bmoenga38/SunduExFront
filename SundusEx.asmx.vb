Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Newtonsoft.Json
Imports NPOI.SS.Formula.Functions
Imports RestSharp
Imports System.Net.Http
Imports System.Threading.Tasks
Imports NPOI.HSSF.UserModel
Imports NPOI.SS.UserModel
Imports NPOI.XSSF.UserModel
Imports System.Net
Imports CrystalDecisions.[Shared].Json
Imports StreamCollect.StreamCollect
Imports StreamCollect.ExtensionMethods
Imports Westwind.Utilities

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class SundusEx
    Inherits System.Web.Services.WebService

    Public Class CurrencyFrom
        Public CurrencyFromID As String
        Public CurrencyCode As String
    End Class

    <WebMethod(True)>
    Public Sub GetCurrencyFrom()
        Dim DBManager As New DatabaseConnectionManager()
        Dim JS As New JavaScriptSerializer()

        If Not HttpContext.Current.Session("GetCurrencyFrom") Is Nothing Then
            Context.Response.Write(JS.Serialize(Session("GetCurrencyFrom")))
            Return
        End If

        Try

            Dim MyList As New List(Of CurrencyFrom)

            Dim query As String = "EXEC GetCurrencyFrom "

            Dim command As New SqlCommand(query, DBManager.GetConnection())
            Dim SqlResults As SqlDataReader = command.ExecuteReader()

            Do While SqlResults.Read()
                Dim MyListItem As New CurrencyFrom

                MyListItem.CurrencyFromID = SqlResults("CurrencyFromID")
                MyListItem.CurrencyCode = SqlResults("CurrencyCode")
                MyList.Add(MyListItem)
            Loop
            Session.Add("GetCurrencyFrom", MyList)

            If Not SqlResults.IsClosed Then
                SqlResults.Close()
            End If

            Context.Response.Write(JS.Serialize(MyList)) 'Write the list object to the response as JSON...

        Catch ex As Exception
            UtilityFunctions.LogException(ex)
            Context.Response.Write(JS.Serialize(ex.Message))
        Finally
            DBManager.Disconnect()
        End Try
    End Sub

End Class