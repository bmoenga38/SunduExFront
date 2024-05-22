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

    <WebMethod(True)>
    Public Sub Login(UserName As String, Password As String)
        Session("ErrorMessage") = ""

        Dim conn As New DatabaseConnectionManager()

        Dim StaffID As String = "0"
        Dim Email As String = ""

        Try

            Dim cmd As New SqlCommand("AuthenticateStaff", conn.GetConnection)
            cmd.CommandType = System.Data.CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@UserName", UserName))
            cmd.Parameters.Add(New SqlParameter("@PassWord", Password))
            cmd.Parameters.AddWithValue("StaffID", "")
            cmd.Parameters("StaffID").Direction = ParameterDirection.InputOutput
            cmd.Parameters("StaffID").Size = 10

            cmd.Parameters.AddWithValue("Email", "")
            cmd.Parameters("Email").Direction = ParameterDirection.InputOutput
            cmd.Parameters("Email").Size = 300


            'UtilityFunctions.LogSQLCommand(cmd)

            cmd.ExecuteNonQuery()

            StaffID = cmd.Parameters("StaffID").Value.ToString()
            Email = cmd.Parameters("Email").Value.ToString()

            FormsAuthentication.SetAuthCookie(UserName, True)

            HttpContext.Current.Session("LoggedOnStaffID") = StaffID
            HttpContext.Current.Session("StaffID") = StaffID
            HttpContext.Current.Session("Email") = Email

            SendSuccessResponse()

        Catch ex As Exception
            UtilityFunctions.LogException(ex)
            Session("ErrorMessage") = ex.Message
        Finally
            conn.Disconnect()
        End Try

    End Sub
    Public Class ErrorMessage
        Public Message As String
    End Class
    <WebMethod(True)>
    Public Sub CheckForErrorMessages()

        Dim errorMessage As New ErrorMessage
        errorMessage.Message = IIf(Session("ErrorMessage") IsNot Nothing, Session("ErrorMessage"), "")

        Context.Response.Write(JsonConvert.SerializeObject(errorMessage))
    End Sub
    Private Sub SendSuccessResponse()

        Dim success = New Dictionary(Of String, Boolean) From {{"Success", True}}

        Context.Response.Write(JsonConvert.SerializeObject(success))
    End Sub

    Public Class Staff
        Public StaffID As String
        Public StaffName As String
        Public Email As String
        Public NationalID As String
        Public PhoneNumber As String
        Public RoleID As String
        Public RoleName As String
        Public EmploymentStatusID As String
        Public EStatus As String
        Public EStatusDesc As String
        Public PhotoURL As String
    End Class

    <WebMethod(True)>
    Public Sub GetAllStaff()
        Dim DBManager As New DatabaseConnectionManager()
        Dim JS As New JavaScriptSerializer()
        Try

            Dim MyList As New List(Of Staff)

            Dim query As String = "EXEC GetAllStaff "

            Dim command As New SqlCommand(query, DBManager.GetConnection())
            Dim SqlResults As SqlDataReader = command.ExecuteReader()

            Do While SqlResults.Read()
                Dim MyListItem As New Staff

                MyListItem.StaffID = SqlResults("StaffID")
                MyListItem.StaffName = SqlResults("StaffName")
                MyListItem.Email = SqlResults("Email")
                MyListItem.NationalID = SqlResults("NationalID")
                MyListItem.PhoneNumber = SqlResults("PhoneNumber")
                MyListItem.RoleID = SqlResults("RoleID")
                MyListItem.RoleName = SqlResults("RoleName")
                MyListItem.EmploymentStatusID = SqlResults("EmploymentStatusID")
                MyListItem.EStatus = SqlResults("EStatus")
                MyListItem.EStatusDesc = SqlResults("EStatusDesc")
                MyListItem.PhotoURL = SqlResults("PhotoURL")
                MyList.Add(MyListItem)
            Loop

            Session.Add("GetAllStaff", MyList)

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
    <WebMethod(True)>
    Public Sub SaveStaffDetails(StaffID As String, StaffName As String, Email As String, NationalID As String,
                                PhoneNumber As String, RoleID As String, EmploymentStatusID As String)

        Dim DBManager As New DatabaseConnectionManager
        Dim JS As New JavaScriptSerializer

        Dim PhotoURL As String = Session("ProfilePhoto")

        Try
            Dim cmd As New SqlCommand("SaveStaffDetails", DBManager.GetConnection())

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("StaffID", StaffID)
            cmd.Parameters.AddWithValue("StaffName", StaffName)
            cmd.Parameters.AddWithValue("Email", Email)
            cmd.Parameters.AddWithValue("NationalID", NationalID)
            cmd.Parameters.AddWithValue("PhoneNumber", PhoneNumber)
            cmd.Parameters.AddWithValue("EmploymentStatusID", EmploymentStatusID)
            cmd.Parameters.AddWithValue("RoleID", RoleID)
            cmd.Parameters.AddWithValue("PhotoURL", PhotoURL)
            cmd.Parameters.AddWithValue("SavedBy", UtilityFunctions.GetLoggedOnStaffID())

            cmd.CommandType = CommandType.StoredProcedure

            cmd.CommandTimeout = 120 '2 minutes

            UtilityFunctions.LogSQLCommand(cmd)

            cmd.ExecuteNonQuery()

            Dim ok As Boolean = True


            Dim Path = New With {.Path = ok}
            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.ContentType = "application/json"
            HttpContext.Current.Response.AddHeader("content-length", JsonConvert.SerializeObject(ok).Length.ToString())
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(ok))
            HttpContext.Current.Response.Flush()
            HttpContext.Current.Response.SuppressContent = True
            HttpContext.Current.ApplicationInstance.CompleteRequest()


        Catch ex As Exception
            UtilityFunctions.LogException(ex)
            Throw New Exception(ex.Message)
        Finally
            DBManager.Disconnect()
        End Try
    End Sub

    Public Class Roles
        Public RoleID As String
        Public Name As String
    End Class

    <WebMethod(True)>
    Public Sub GetRoles()
        Dim DBManager As New DatabaseConnectionManager()
        Dim JS As New JavaScriptSerializer()

        If Not HttpContext.Current.Session("GetRoles") Is Nothing Then
            Context.Response.Write(JS.Serialize(Session("GetRoles")))
            Return
        End If

        Try

            Dim MyList As New List(Of Roles)

            Dim query As String = "EXEC GetRoles "

            Dim command As New SqlCommand(query, DBManager.GetConnection())
            Dim SqlResults As SqlDataReader = command.ExecuteReader()

            Do While SqlResults.Read()
                Dim MyListItem As New Roles

                MyListItem.RoleID = SqlResults("RoleID")
                MyListItem.Name = SqlResults("Name")
                MyList.Add(MyListItem)
            Loop
            Session.Add("GetRoles", MyList)

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