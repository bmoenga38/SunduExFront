
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports NPOI.SS.UserModel
Imports NPOI.XSSF.UserModel

Public Class UtilityFunctions

    Shared ReadOnly Property GetLoggedOnStaffID As String
        Get


            Dim DBManager As New DatabaseConnectionManager()

            Try

                If Not HttpContext.Current.Session("LoggedOnStaffID") Is Nothing Then
                    If HttpContext.Current.Session("LoggedOnStaffID") <> "0" Then
                        Return HttpContext.Current.Session("LoggedOnStaffID")
                    End If
                End If

                Dim query As String = "SELECT ID FROM Staff WHERE Email = '" + HttpContext.Current.Session("Email") + "'"
                Dim command As New SqlCommand(query, DBManager.GetConnection())
                Dim SqlResults As SqlDataReader = command.ExecuteReader()

                If SqlResults.Read() Then
                    GetLoggedOnStaffID = SqlResults("ID")

                    HttpContext.Current.Session("LoggedOnStaffID") = GetLoggedOnStaffID

                    SqlResults.Close()
                Else
                    'MsgBox("Could not find student information")
                    GetLoggedOnStaffID = 0

                    HttpContext.Current.Session("LoggedOnStaffID") = "0"
                End If

                If Not SqlResults.IsClosed Then
                    SqlResults.Close()
                End If

            Catch ex As Exception
                LogException(ex)
                GetLoggedOnStaffID = 0
            Finally
                DBManager.Disconnect()
            End Try
        End Get
    End Property


    Shared ReadOnly Property GetLoggedOnStaffName As String
        Get


            Dim DBManager As New DatabaseConnectionManager()

            Try

                If Not HttpContext.Current.Session("LoggedOnStaffName") Is Nothing Then
                    If HttpContext.Current.Session("LoggedOnStaffName") <> "" Then
                        Return HttpContext.Current.Session("LoggedOnStaffName")
                    End If
                End If

                Dim query As String = "SELECT Name StaffName FROM Staff WHERE ID = '" + HttpContext.Current.Session("LoggedOnStaffID") + "'"
                Dim command As New SqlCommand(query, DBManager.GetConnection())
                Dim SqlResults As SqlDataReader = command.ExecuteReader()

                If SqlResults.Read() Then
                    GetLoggedOnStaffName = SqlResults("StaffName")

                    HttpContext.Current.Session("LoggedOnStaffName") = GetLoggedOnStaffName

                    SqlResults.Close()
                Else
                    'MsgBox("Could not find student information")
                    GetLoggedOnStaffName = 0

                    HttpContext.Current.Session("LoggedOnStaffName") = "0"
                End If

                If Not SqlResults.IsClosed Then
                    SqlResults.Close()
                End If

            Catch ex As Exception
                LogException(ex)
                GetLoggedOnStaffName = 0
            Finally
                DBManager.Disconnect()
            End Try
        End Get
    End Property



    Shared ReadOnly Property GetLoggedOnStaffRole As String
        Get


            Dim DBManager As New DatabaseConnectionManager()

            Try

                If Not HttpContext.Current.Session("LoggedOnStaffRole") Is Nothing Then
                    If HttpContext.Current.Session("LoggedOnStaffRole") <> "0" Then
                        Return HttpContext.Current.Session("LoggedOnStaffRole")
                    End If
                End If

                Dim query As String = "SELECT l.Name StaffRole FROM Staff s INNER JOIN StaffRoles r ON s.ID = r.StaffID AND r.IsCurrent = 'Y' INNER JOIN Role l ON r.RoleID = l.ID WHERE s.ID = '" + HttpContext.Current.Session("LoggedOnStaffID") + "'"
                Dim command As New SqlCommand(query, DBManager.GetConnection())
                Dim SqlResults As SqlDataReader = command.ExecuteReader()

                If SqlResults.Read() Then
                    GetLoggedOnStaffRole = SqlResults("StaffRole")

                    HttpContext.Current.Session("LoggedOnStaffRole") = GetLoggedOnStaffName

                    SqlResults.Close()
                Else
                    'MsgBox("Could not find student information")
                    GetLoggedOnStaffRole = 0

                    HttpContext.Current.Session("LoggedOnStaffRole") = "0"
                End If

                If Not SqlResults.IsClosed Then
                    SqlResults.Close()
                End If

            Catch ex As Exception
                LogException(ex)
                GetLoggedOnStaffRole = 0
            Finally
                DBManager.Disconnect()
            End Try
        End Get
    End Property


    Shared ReadOnly Property GetLoggedOnMinistryID As String
        Get


            Dim DBManager As New DatabaseConnectionManager()

            Try

                If Not HttpContext.Current.Session("LoggedOnMinistryID") Is Nothing Then
                    If HttpContext.Current.Session("LoggedOnMinistryID") <> "0" Then
                        Return HttpContext.Current.Session("LoggedOnMinistryID")
                    End If
                End If

                Dim query As String = "SELECT COALESCE(MinistryID,0) MinistryID FROM Staff WHERE Email = '" + HttpContext.Current.Session("Email") + "'"
                Dim command As New SqlCommand(query, DBManager.GetConnection())
                Dim SqlResults As SqlDataReader = command.ExecuteReader()

                If SqlResults.Read() Then
                    GetLoggedOnMinistryID = SqlResults("MinistryID")

                    HttpContext.Current.Session("LoggedOnMinistryID") = GetLoggedOnMinistryID

                    SqlResults.Close()
                Else
                    'MsgBox("Could not find student information")
                    GetLoggedOnMinistryID = 0

                    HttpContext.Current.Session("LoggedOnMinistryID") = "0"
                End If

                If Not SqlResults.IsClosed Then
                    SqlResults.Close()
                End If

            Catch ex As Exception
                LogException(ex)
                GetLoggedOnMinistryID = 0
            Finally
                DBManager.Disconnect()
            End Try
        End Get
    End Property
    Shared Sub LogException(ex As Exception)
        Try
            LogText(ex.Message + Environment.NewLine + ex.StackTrace)

            'EmailLogFile(ex)

        Catch exIgnore As Exception
            'Avoid the logging process generating an extra error, especially if two people try to write to the log file at the same time...
        End Try
    End Sub

    Shared Function GetOrganizationID() As String

        GetOrganizationID = "0"

        Try
            If Not HttpContext.Current.Session("OrganizationID") Is Nothing Then
                If HttpContext.Current.Session("OrganizationID") <> "" AndAlso HttpContext.Current.Session("OrganizationID") <> "0" Then
                    Return HttpContext.Current.Session("OrganizationID")
                End If
            End If

        Catch ex As Exception
            LogException(ex)
        End Try

    End Function

    Shared Function GetOrganizationID(StaffID As String) As String

        GetOrganizationID = "0"

        Dim DBManager As New DatabaseConnectionManager()

        Try
            If HttpContext.Current.Session("OrganizationID") IsNot Nothing Then
                If HttpContext.Current.Session("OrganizationID") <> "" AndAlso HttpContext.Current.Session("OrganizationID") <> "0" Then
                    Return HttpContext.Current.Session("OrganizationID")
                End If
            End If

            Dim query As String = "SELECT OrganizationID FROM Staff WHERE ID = '" + StaffID + "'"

            Dim command As New SqlCommand(query, DBManager.GetConnection())

            Dim SqlResults As SqlDataReader = command.ExecuteReader()

            If SqlResults.Read() Then
                GetOrganizationID = SqlResults("OrganizationID").ToString
                SqlResults.Close()
            Else
                SqlResults.Close()
            End If
        Catch ex As Exception
            LogException(ex)
            GetOrganizationID = "0"
        Finally
            DBManager.Disconnect()
        End Try

    End Function
    Shared Function GetTempFileNameNoLogin() As String
        Return Now.Year.ToString + "-" + Now.Month.ToString + "-" + Now.Day.ToString + "-" + Now.Hour.ToString + "-" + Now.Minute.ToString + "-" + Now.Second.ToString + "-" + Now.Millisecond.ToString
    End Function

    Public Class InsuranceRecipients
        Public PhoneNumber As String
        Public InsuranceMessage As String
    End Class

    Public Class BadgeRecipients
        Public PhoneNumber As String
        Public BadgeMessage As String
    End Class

    Shared Sub SendInsuranceNotification(InsuranceDays As String)

        Try
            Dim Insurance As New List(Of InsuranceRecipients)

            Insurance = GetInsuranceSMSRecipent(InsuranceDays)

            For Each r In Insurance
                AITSMSManager.SendMultipleSMS(r.PhoneNumber, r.InsuranceMessage)
                AITSMSManager.SendMultipleSMS("0724598895", r.InsuranceMessage)
            Next
        Catch ex As Exception
            UtilityFunctions.LogException(ex)
        End Try

    End Sub

    Shared Function ExecuteNonQueries(query As String, Optional CustomCommandTimeout As Integer = 0) As Boolean

        Dim DBConnection As New DatabaseConnectionManager()

        Try
            If CustomCommandTimeout = 0 Then
                CustomCommandTimeout = 120 '2 minutes
            End If

            Dim command2 As SqlCommand = New SqlCommand(query, DBConnection.GetConnection)

            command2.CommandTimeout = CustomCommandTimeout

            UtilityFunctions.LogSQLCommand(command2)

            command2.ExecuteNonQuery()

            command2.Dispose()

            Return True

        Catch ex As Exception
            LogException(ex)
            Throw
        Finally
            DBConnection.Disconnect()
        End Try

    End Function
    Shared Function GetCurrentDate() As String
        Dim DBManager As New DatabaseConnectionManager()
        Dim CurrentDate As String = "1990-01-01"

        Dim query As String = "SELECT CAST(CAST(dbo.fn_get_date_with_offset() AS DATE) AS varchar (50)) CurrentDate"

        Try
            Dim command As New SqlCommand(query, DBManager.GetConnection())

            Dim SqlResults As SqlDataReader = command.ExecuteReader()

            If SqlResults.HasRows = False Then
                Return CurrentDate
            End If

            SqlResults.Read()

            CurrentDate = SqlResults("CurrentDate").ToString

            SqlResults.Close()

        Catch ex As Exception
            LogException(ex)
            Return CurrentDate
        Finally
            DBManager.Disconnect()
        End Try
        Return CurrentDate
    End Function
    Shared Sub SendBadgeNotification(BadgeDays As String)

        Try
            Dim Insurance As New List(Of BadgeRecipients)

            Insurance = GetBadgeSMSRecipent(BadgeDays)

            For Each r In Insurance
                AITSMSManager.SendMultipleSMS(r.PhoneNumber, r.BadgeMessage)
            Next
        Catch ex As Exception
            UtilityFunctions.LogException(ex)
        End Try

    End Sub



    Private Shared Function GetInsuranceSMSRecipent(InsuranceDays As String) As List(Of InsuranceRecipients)

        Dim DBManager As New DatabaseConnectionManager

        Try

            Dim Insurance As New List(Of InsuranceRecipients)

            Dim query As String = "GetInsuranceSMSRecipent"
            Dim command As New SqlCommand(query, DBManager.GetConnection())
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@Days", InsuranceDays)
            command.CommandTimeout = 300 '5 minutes

            UtilityFunctions.LogSQLCommand(command)

            Dim SqlResults As SqlDataReader = command.ExecuteReader()

            While SqlResults.Read()
                Dim r As New InsuranceRecipients
                r.PhoneNumber = SqlResults("PhoneNumber").ToString()
                r.InsuranceMessage = SqlResults("InsuranceMessage").ToString()
                Insurance.Add(r)
            End While

            If Not SqlResults.IsClosed Then
                SqlResults.Close()
            End If

            Return Insurance

        Catch ex As Exception
            Throw
        Finally
            DBManager.Disconnect()
        End Try
    End Function

    Private Shared Function GetBadgeSMSRecipent(BadgeDays As String) As List(Of BadgeRecipients)

        Dim DBManager As New DatabaseConnectionManager

        Try

            Dim Insurance As New List(Of BadgeRecipients)

            Dim query As String = "GetBadgeSMSRecipent"
            Dim command As New SqlCommand(query, DBManager.GetConnection())
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@Days", BadgeDays)
            command.CommandTimeout = 300 '5 minutes

            UtilityFunctions.LogSQLCommand(command)

            Dim SqlResults As SqlDataReader = command.ExecuteReader()

            While SqlResults.Read()
                Dim r As New BadgeRecipients
                r.PhoneNumber = SqlResults("PhoneNumber").ToString()
                r.BadgeMessage = SqlResults("BageMessage").ToString()
                Insurance.Add(r)
            End While

            If Not SqlResults.IsClosed Then
                SqlResults.Close()
            End If

            Return Insurance

        Catch ex As Exception
            Throw
        Finally
            DBManager.Disconnect()
        End Try
    End Function


    Shared Function GetSMSCost(Message As String, Recipients As String) As String
        Try

            Dim Cost As Double = 0
            Dim SMS_OVERSEAS_COUNTRY_FACTOR As Double = 1

            Dim COUNTRY_CODE As String = "254"
            Dim SMS_BUYING_PRICE As Double = 1

            If Not Recipients.StartsWith("+" + COUNTRY_CODE) AndAlso Not Recipients.StartsWith(COUNTRY_CODE) AndAlso Recipients.Length > 10 Then
                SMS_OVERSEAS_COUNTRY_FACTOR = 5
            End If

            If Message.Length = 0 Then
                Cost = 0
            ElseIf Message.Length <= 160 Then
                Cost = 1
            ElseIf Message.Length Mod 153 = 0 Then 'When the message is a multiple of 153 characters and more than 160 characters
                Cost = (Message.Length / 153)
            Else
                Cost = (1 + Math.Floor(Message.Length / 153)) 'When the message is a NOT multiple of 153 characters and more than 160 characters
            End If

            'Multiply by SMS_BUYING_PRICE 
            Cost *= SMS_BUYING_PRICE

            'Multiply by SMS_OVERSEAS_COUNTRY_FACTOR if it is not a local number COUNTRY_CODE
            Cost *= SMS_OVERSEAS_COUNTRY_FACTOR

            Return Cost

        Catch ex As Exception
            LogException(ex)
            Throw
        End Try
    End Function

    Friend Shared Function GetExportedPath(RefNo As String) As String
        Dim DBManager As New DatabaseConnectionManager()

        Try

            Dim query As String = "GetExportedPath '" & RefNo & "'"
            Dim command As New SqlCommand(query, DBManager.GetConnection())
            Dim SqlResults As SqlDataReader = command.ExecuteReader()

            If SqlResults.Read() Then
                GetExportedPath = SqlResults("Exportedpath")
                SqlResults.Close()
            Else
                GetExportedPath = ""
            End If

            If Not SqlResults.IsClosed Then
                SqlResults.Close()
            End If

        Catch ex As Exception
            LogException(ex)
            GetExportedPath = ""
        Finally
            DBManager.Disconnect()
        End Try
    End Function

    Shared Function CleanTextHtmlDecode(text As String) As String
        Try

            text = HttpContext.Current.Server.HtmlDecode(text)

            Return text

        Catch ex As Exception
            UtilityFunctions.LogException(ex)
            Return ""
        End Try
    End Function

    Shared Function GetScalarValue(Query As String) As String

        Dim DBManager As New DatabaseConnectionManager()

        Try

            Dim SqlResults As SqlDataReader = Nothing

            Dim ScalarValue As String = "0"

            Dim cmd As New SqlCommand(Query, DBManager.GetConnection)

            SqlResults = cmd.ExecuteReader()

            While SqlResults.Read()

                ScalarValue = SqlResults(0).ToString

            End While

            If Not SqlResults.IsClosed Then
                SqlResults.Close()
            End If

            Return ScalarValue

        Catch ex As Exception
            LogException(ex)
            Throw
        Finally
            DBManager.Disconnect()
        End Try
    End Function
    Shared Function FormatPhoneNumber(PhoneNumber As String) As String
        Dim DBManager As New DatabaseConnectionManager()
        Dim query As String = "select dbo.fn_format_intnl_phone('" + PhoneNumber + "') PhoneNumber"
        Try
            Dim command As New SqlCommand(query, DBManager.GetConnection())
            Dim SqlResults As SqlDataReader = command.ExecuteReader()
            If Not SqlResults.HasRows Then
                Return ""
            Else
                SqlResults.Read()
                Return SqlResults("PhoneNumber")
            End If
            SqlResults.Close()
        Catch ex As Exception
            LogException(ex)
            Return ""
        Finally
            DBManager.Disconnect()
        End Try
    End Function
    Shared Sub LogText(LogText As String)
        Try

            CreateDirectory(HttpContext.Current.Server.MapPath("~/BatchReports/"))

            Dim LogFileName As String = UtilityFunctions.GetLogFileName()

            LogText = "--" + Now.ToString("dd-MMM-yyyy hh:mm:ss") + Environment.NewLine + LogText

            LogText += Environment.NewLine 'vbNewLine

            File.AppendAllText(LogFileName, LogText)

        Catch ex As Exception
            'LogException(ex) 'Ignore errors from this Sub. If this throws an exception, it causes an infinite loop as LogException calls LogText. Commented out. Simon. 23-Oct-2019.
        End Try
    End Sub

    Shared Function GetLogFileName() As String
        Try

            Return HttpContext.Current.Server.MapPath("~/BatchReports/") + "Mathree_Log_File_" + Now.ToString("ddMMMyyyy") + ".txt"

        Catch ex As Exception
            Return HttpContext.Current.Server.MapPath("~/BatchReports/") + "Mathree_Log_File" + ".txt"
        End Try
    End Function
    Shared Function CreateDirectory(Path As String) As String
        Try
            If (Not System.IO.Directory.Exists(Path)) Then
                System.IO.Directory.CreateDirectory(Path)
            End If

            CreateDirectory = Path

            If CheckFileExists(Path + "Home.aspx") = "N" Then
                System.IO.File.CreateText(Path + "Home.aspx")
            End If

        Catch ex As Exception
            LogException(ex)
            Throw
        End Try
    End Function

    Shared Function CheckFileExists(Path As String) As String
        Try
            If System.IO.File.Exists(Path) Then
                Return "Y"
            Else
                Return "N"
            End If
        Catch ex As Exception
            LogException(ex)
            CheckFileExists = ex.Message
        End Try
    End Function

    Shared Function GetTempReportFileName(ReportName As String) As String
        Return ReportName + "-" + Now.Year.ToString + "-" + Now.Month.ToString + "-" + Now.Day.ToString + "-" + Now.Hour.ToString + "-" + Now.Minute.ToString + "-" + Now.Second.ToString
    End Function


    Shared Sub LogSQLCommand(Command As SqlCommand)
        Try

            Dim SQL As String = DatabaseConnectionManager.CommandAsSql(Command)

            LogText(SQL)

        Catch ex As Exception
            LogException(ex)
        End Try
    End Sub

    Shared Function CheckExists(queryExists As String) As Boolean

        Dim DBManager As New DatabaseConnectionManager()

        Try
            Dim command As New SqlCommand(queryExists, DBManager.GetConnection())
            Dim SqlResults As SqlDataReader = command.ExecuteReader()
            command.Dispose()
            If SqlResults.Read() Then
                SqlResults.Close()
                DBManager.Disconnect()
                Return True
            Else
                Return False

            End If

            If Not SqlResults.IsClosed Then
                SqlResults.Close()
            End If

        Catch ex As Exception
            LogException(ex)
            Throw
        Finally
            DBManager.Disconnect()
        End Try
    End Function
    Friend Shared Function UserIsInRole(RoleName As String) As Boolean
        Try
            If RoleName = "Bus" Then
                Return UtilityFunctions.CheckExists("SELECT * FROM Buses WHERE Name = '" & Membership.GetUser.Email.Replace("'", "''") & "' ")
            End If
            If RoleName = "Super Admin" Then
                Return UtilityFunctions.CheckExists("SELECT * FROM Users WHERE Role = 'Super Admin' AND Email = '" & Membership.GetUser.Email.Replace("'", "''") & "' ")
            End If
            If RoleName = "Admin" Then
                Return UtilityFunctions.CheckExists("SELECT * FROM Users WHERE Role = 'Admin' AND Email = '" & Membership.GetUser.Email.Replace("'", "''") & "' ")
            End If
            If RoleName = "User" Then
                Return UtilityFunctions.CheckExists("SELECT * FROM Users WHERE Role = 'Passenger' AND Email = '" & Membership.GetUser.Email.Replace("'", "''") & "' ")
            End If
            If RoleName = "Receipt" Then
                Return UtilityFunctions.CheckExists("SELECT * FROM Users WHERE Role = 'Receipt' AND Email = '" & Membership.GetUser.Email.Replace("'", "''") & "' ")
            End If
            If RoleName = "Insurance" Then
                Return UtilityFunctions.CheckExists("SELECT * FROM Users WHERE Role = 'Insurance' AND Email = '" & Membership.GetUser.Email.Replace("'", "''") & "' ")
            End If
            If RoleName = "TLB" Then
                Return UtilityFunctions.CheckExists("SELECT * FROM Users WHERE Role = 'TLB' AND Email = '" & Membership.GetUser.Email.Replace("'", "''") & "' ")
            End If
            If RoleName = "HR" Then
                Return UtilityFunctions.CheckExists("SELECT * FROM Users WHERE Role = 'HR' AND Email = '" & Membership.GetUser.Email.Replace("'", "''") & "' ")
            End If
            If RoleName = "allocation" Then
                Return UtilityFunctions.CheckExists("SELECT * FROM Users WHERE Role = 'allocation' AND Email = '" & Membership.GetUser.Email.Replace("'", "''") & "' ")
            End If
            If RoleName = "Inspector" Then
                Return UtilityFunctions.CheckExists("SELECT * FROM Users WHERE Role = 'Inspector' AND Email = '" & Membership.GetUser.Email.Replace("'", "''") & "' ")
            End If

            Return False 'Default, not in role...

        Catch ex As Exception
            Throw
        End Try

    End Function
    Shared ReadOnly Property GetLoggedOnUserID As String
        Get
            If Membership.GetUser Is Nothing Then
                System.Web.HttpContext.Current.Response.Redirect("../Logout.aspx")
                Return "0"
            End If
            Dim DBManager As New DatabaseConnectionManager()

            Try

                If Not HttpContext.Current.Session("LoggedOnUserID") Is Nothing Then
                    If HttpContext.Current.Session("LoggedOnUserID") <> "0" Then
                        Return HttpContext.Current.Session("LoggedOnUserID")
                    End If
                End If
                Dim query As String = "SELECT ID FROM Users WHERE Email = '" & Membership.GetUser.Email.Replace("'", "''") & "'"
                Dim command As New SqlCommand(query, DBManager.GetConnection())
                Dim SqlResults As SqlDataReader = command.ExecuteReader()

                If SqlResults.Read() Then
                    GetLoggedOnUserID = SqlResults("ID")

                    HttpContext.Current.Session("LoggedOnUserID") = GetLoggedOnUserID

                    SqlResults.Close()
                Else
                    GetLoggedOnUserID = 0

                    HttpContext.Current.Session("LoggedOnUserID") = "0"
                End If

                If Not SqlResults.IsClosed Then
                    SqlResults.Close()
                End If

            Catch ex As Exception
                LogException(ex)
                GetLoggedOnUserID = 0
            Finally
                DBManager.Disconnect()
            End Try
        End Get
    End Property

    Shared ReadOnly Property GetLoggedOnBusID As String
        Get

            Dim DBManager As New DatabaseConnectionManager()

            Try

                If Not HttpContext.Current.Session("LoggedOnBusID") Is Nothing Then
                    If HttpContext.Current.Session("LoggedOnBusID") <> "0" Then
                        Return HttpContext.Current.Session("LoggedOnBusID")
                    End If
                End If
                Dim query As String = "SELECT ID FROM Buses WHERE Name = '" & Membership.GetUser.Email.Replace("'", "''") & "'"
                Dim command As New SqlCommand(query, DBManager.GetConnection())
                Dim SqlResults As SqlDataReader = command.ExecuteReader()

                If SqlResults.Read() Then
                    GetLoggedOnBusID = SqlResults("ID")

                    HttpContext.Current.Session("LoggedOnBusID") = GetLoggedOnBusID

                    SqlResults.Close()
                Else
                    GetLoggedOnBusID = 0

                    HttpContext.Current.Session("LoggedOnBusID") = "0"
                End If

                If Not SqlResults.IsClosed Then
                    SqlResults.Close()
                End If

            Catch ex As Exception
                LogException(ex)
                GetLoggedOnBusID = 0
            Finally
                DBManager.Disconnect()
            End Try
        End Get
    End Property
    Shared Function GetLoggedOnUserName() As String

        Dim DBManager As New DatabaseConnectionManager()

        Try
            If Membership.GetUser Is Nothing Then
                System.Web.HttpContext.Current.Response.Redirect("../Logout.aspx")
                Return "0"
            End If

            Dim UserID As String = UtilityFunctions.GetLoggedOnUserID

            If Not HttpContext.Current.Session("LoggedOnUserName") Is Nothing Then
                If HttpContext.Current.Session("LoggedOnUserName") <> "" Then
                    Return HttpContext.Current.Session("LoggedOnUserName")
                End If
            End If

            Dim query As String = "SELECT dbo.fn_InitCap(name) + ' - '+ LastName + ' ' UserName FROM Users WHERE ID = '" & UserID & "'"
            Dim command As New SqlCommand(query, DBManager.GetConnection())
            Dim SqlResults As SqlDataReader = command.ExecuteReader()

            If SqlResults.Read() Then
                GetLoggedOnUserName = SqlResults("UserName")
                HttpContext.Current.Session("LoggedOnUserName") = GetLoggedOnUserName
                SqlResults.Close()
            Else
                'MsgBox("Could not find student information")
                GetLoggedOnUserName = ""
                HttpContext.Current.Session("LoggedOnUserName") = ""
            End If

            If Not SqlResults.IsClosed Then
                SqlResults.Close()
            End If

        Catch ex As Exception
            LogException(ex)
            GetLoggedOnUserName = ""
        Finally
            DBManager.Disconnect()
        End Try

    End Function

    Shared Function GetLoggedOnBusName() As String

        Dim DBManager As New DatabaseConnectionManager()

        Try
            If Membership.GetUser Is Nothing Then
                System.Web.HttpContext.Current.Response.Redirect("../Logout.aspx")
                Return "0"
            End If

            Dim BusID As String = UtilityFunctions.GetLoggedOnBusID

            If Not HttpContext.Current.Session("LoggedOnBusName") Is Nothing Then
                If HttpContext.Current.Session("LoggedOnBusName") <> "" Then
                    Return HttpContext.Current.Session("LoggedOnBusName")
                End If
            End If

            Dim query As String = "SELECT Name BusName FROM Buses WHERE ID = '" & BusID & "'"
            Dim command As New SqlCommand(query, DBManager.GetConnection())
            Dim SqlResults As SqlDataReader = command.ExecuteReader()

            If SqlResults.Read() Then
                GetLoggedOnBusName = SqlResults("BusName")
                HttpContext.Current.Session("LoggedOnBusName") = GetLoggedOnUserName()
                SqlResults.Close()
            Else
                'MsgBox("Could not find student information")
                GetLoggedOnBusName = ""
                HttpContext.Current.Session("LoggedOnBusName") = ""
            End If

            If Not SqlResults.IsClosed Then
                SqlResults.Close()
            End If

        Catch ex As Exception
            LogException(ex)
            GetLoggedOnBusName = ""
        Finally
            DBManager.Disconnect()
        End Try

    End Function

    Shared Function GetBusIDFromNumberPlate(NumberPlate As String) As String

        Dim DBManager As New DatabaseConnectionManager()

        Try

            Dim query As String = "SELECT ID BusID FROM Buses WHERE Name = '" & NumberPlate & "'"
            Dim command As New SqlCommand(query, DBManager.GetConnection())
            Dim SqlResults As SqlDataReader = command.ExecuteReader()

            If SqlResults.Read() Then
                GetBusIDFromNumberPlate = SqlResults("BusID")
                SqlResults.Close()
            Else
                GetBusIDFromNumberPlate = "0"
            End If

            If Not SqlResults.IsClosed Then
                SqlResults.Close()
            End If

        Catch ex As Exception
            LogException(ex)
            GetBusIDFromNumberPlate = "0"
        Finally
            DBManager.Disconnect()
        End Try

    End Function
    Shared Function GetBusIDFromFleetNumber(FleetNumber As String) As String

        Dim DBManager As New DatabaseConnectionManager()

        Try

            Dim query As String = "SELECT ID BusID FROM Buses WHERE FleetNumber = '" & FleetNumber & "'"
            Dim command As New SqlCommand(query, DBManager.GetConnection())
            Dim SqlResults As SqlDataReader = command.ExecuteReader()

            If SqlResults.Read() Then
                GetBusIDFromFleetNumber = SqlResults("BusID")
                SqlResults.Close()
            Else
                GetBusIDFromFleetNumber = "0"
            End If

            If Not SqlResults.IsClosed Then
                SqlResults.Close()
            End If

        Catch ex As Exception
            LogException(ex)
            GetBusIDFromFleetNumber = "0"
        Finally
            DBManager.Disconnect()
        End Try

    End Function
    Shared Function GetTempFileName() As String
        Return GetLoggedOnStaffID.ToString() + "-" + Now.Year.ToString + "-" + Now.Month.ToString + "-" + Now.Day.ToString + "-" + Now.Hour.ToString + "-" + Now.Minute.ToString + "-" + Now.Second.ToString + "-" + Now.Millisecond.ToString
    End Function

    Shared Function GetBusIDFromName(Name) As String

        Dim DBManager As New DatabaseConnectionManager()

        Try
            If Membership.GetUser Is Nothing Then
                System.Web.HttpContext.Current.Response.Redirect("../Logout.aspx")
                Return "0"
            End If

            Dim query As String = "SELECT ID BusID FROM Buses WHERE Name = '" & Name & "' OR FleetNumber = '" + Name + "'"
            Dim command As New SqlCommand(query, DBManager.GetConnection())
            Dim SqlResults As SqlDataReader = command.ExecuteReader()

            If SqlResults.Read() Then
                GetBusIDFromName = SqlResults("BusID")
                HttpContext.Current.Session("BusID") = GetBusIDFromName
                SqlResults.Close()
            Else
                GetBusIDFromName = ""
                HttpContext.Current.Session("BusID") = ""
            End If

            If Not SqlResults.IsClosed Then
                SqlResults.Close()
            End If

        Catch ex As Exception
            LogException(ex)
            GetBusIDFromName = ""
        Finally
            DBManager.Disconnect()
        End Try

    End Function

    Shared Function CreateExcelFromStoreProcedure() As String

        Dim ReturnErrorMessage As String = ""

        Dim DBManager As New DatabaseConnectionManager()

        Try
            Dim StoredProcedureName As String = HttpContext.Current.Session("StoredProcedureName")

            Dim OrganizationID, ReceiptDate, Query, ParamsQuery, StaffID As String


            OrganizationID = HttpContext.Current.Session("OrganizationID")
            StaffID = HttpContext.Current.Session("LoggedOnStaffID")
            ReceiptDate = HttpContext.Current.Session("ReceiptDateFrom")



            Query = "EXEC " + StoredProcedureName

            ParamsQuery = "Select PARAMETER_NAME FROM information_schema.parameters WHERE SPECIFIC_NAME = '" + StoredProcedureName + "'"

            Dim command As New Data.SqlClient.SqlCommand(ParamsQuery, DBManager.GetConnection())

            Dim SqlResults As Data.SqlClient.SqlDataReader = command.ExecuteReader()

            While SqlResults.Read()
                If SqlResults("PARAMETER_NAME").ToString = "@OrganizationID" Then
                    Query += " '" + OrganizationID + "',"
                ElseIf SqlResults("PARAMETER_NAME").ToString = "@ReceiptDate" Then
                    Query += " '" + ReceiptDate + "',"
                ElseIf SqlResults("PARAMETER_NAME").ToString = "@ReceiptDate" Then
                    Query += " '" + ReceiptDate + "',"
                ElseIf SqlResults("PARAMETER_NAME").ToString = "@StaffID" Then
                    Query += " '" + StaffID + "'"
                End If

            End While

            If Not SqlResults.IsClosed Then
                SqlResults.Close()
            End If

            'Remove trailing comma
            If Query.EndsWith(",") Then
                Query = Left(Query, Query.Length - 1)
            End If

            Try

                Dim command2 As New Data.SqlClient.SqlCommand(Query, DBManager.GetConnection())

                Dim SqlResults2 As Data.SqlClient.SqlDataReader = command2.ExecuteReader()

                Dim i As Integer = 1 'Start with 1 as row 0 is the header row

                Dim ExportFileName As String = UtilityFunctions.GenerateCollectionRandomNumbers()

                Dim workbook As IWorkbook = New XSSFWorkbook()

                'Dim sheet1 As ISheet = workbook.CreateSheet("Sheet1")
                Dim sheet1 As XSSFSheet = DirectCast(workbook.CreateSheet("Sheet 1"), XSSFSheet)

                Dim header As IRow = sheet1.CreateRow(0)

                Dim font As IFont = workbook.CreateFont()

                Dim FieldCount As Integer = SqlResults2.FieldCount

                For j As Integer = 0 To FieldCount - 1

                    If Not SqlResults2.GetName(j).ToString = "NavigationURL" And Not SqlResults2.GetName(j).ToString = "NavigationURL2" Then

                        'Remove the (R) If present
                        Dim DataValue As String = SqlResults2.GetName(j)
                        If DataValue.Contains("(R)") Then
                            'Reason why this wasnt working before...
                            'https://stackoverflow.com/questions/19234334/how-does-the-string-replace-function-in-vb-net-not-work
                            DataValue = DataValue.Replace("(R)", "")
                        End If

                        header.CreateCell(j).SetCellValue(DataValue)

                        font.FontHeightInPoints = 11
                        font.FontName = "Cambria"
                        font.Boldweight = NPOI.SS.UserModel.FontBoldWeight.Bold
                        font.IsBold = True

                        header.Cells(j).CellStyle.SetFont(font)
                    End If

                Next

                While SqlResults2.Read()

                    Dim row As IRow = sheet1.CreateRow(i)

                    For j As Integer = 0 To SqlResults2.FieldCount - 1

                        If Not SqlResults2.GetName(j).ToString = "NavigationURL" And Not SqlResults2.GetName(j).ToString = "NavigationURL2" Then

                            If IsNumeric(SqlResults2(j)) Then
                                row.CreateCell(j).SetCellValue(CDbl(SqlResults2(j)))
                            Else
                                row.CreateCell(j).SetCellValue(SqlResults2(j).ToString)
                            End If

                            font.FontHeightInPoints = 11
                            font.FontName = "Cambria"
                            font.Boldweight = NPOI.SS.UserModel.FontBoldWeight.Normal

                            row.Cells(j).CellStyle.SetFont(font)
                        End If

                    Next

                    i += 1 'Move on to the next row

                End While

                If Not SqlResults2.IsClosed Then
                    SqlResults2.Close()
                End If

                'Auto size all columns
                For j As Integer = 0 To FieldCount - 1
                    sheet1.AutoSizeColumn(j)
                    'GC.Collect()
                Next

                Dim sw As FileStream = File.Create(HttpContext.Current.Server.MapPath("~/BatchReports/" + ExportFileName + ".xlsx"))

                workbook.Write(sw)

                sw.Close()


                Return ExportFileName
                'This should be implemented after this method is called
                'ResponseHelper.Redirect("~/BatchReports/" + ExportFileName + ".xlsx", "_blank", "menubar=0,width=1000,height=600,resizable=yes,scrollbars=yes")


            Catch ex As Exception

                LogException(ex)
                Throw
            Finally
                DBManager.Disconnect()
            End Try
        Catch ex As Exception
            LogException(ex)
            Throw
        End Try

    End Function
    Public Shared Function GenerateRandomNumbers() As String

        Return GetLoggedOnUserID.ToString() + "-" + Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString + Now.Millisecond.ToString

    End Function
    Public Shared Function GenerateCollectionRandomNumbers() As String
        Return "REPORT - " + Now.Year.ToString + "-" + Now.Month.ToString + "-" + Now.Day.ToString + "-" + Now.Hour.ToString + "-" + Now.Minute.ToString + "-" + Now.Second.ToString + "-" + Now.Millisecond.ToString
    End Function
    Public Class OGlobalSettings
        Public SettingName As String
        Public SettingValue As String
    End Class
    Shared Function GetGlobalSetting(SettingName As String, Optional DefaultValue As String = "", Optional ForceDBQuery As Boolean = False) As String

        Return GetGlobalSettingWithSession(SettingName, DefaultValue, ForceDBQuery)



    End Function

    Shared Function GetGlobalSettingWithSession(SettingName As String, Optional DefaultValue As String = "", Optional ForceDBQuery As Boolean = False) As String

        Dim DBManager As New DatabaseConnectionManager()

        Try

            Dim OrganizationID As String = UtilityFunctions.GetOrganizationID

            If OrganizationID Is Nothing Then
                OrganizationID = "0"
                Return DefaultValue
            End If

            Dim OrgSet As New List(Of OGlobalSettings)

            If Not HttpContext.Current.Session("OrganizationGlobalSettings") Is Nothing And ForceDBQuery = False Then

                OrgSet = HttpContext.Current.Session("OrganizationGlobalSettings")

                If OrgSet.Count > 0 Then

                    For Each s As OGlobalSettings In OrgSet
                        If s.SettingName = SettingName Then
                            Return s.SettingValue
                        End If
                    Next

                End If
            End If

            Dim query As String = "SELECT SettingName, COALESCE(SettingValue, '') SettingValue FROM OrganizationGlobalSettings WHERE OrganizationID = '" + OrganizationID + "'"
            Dim command As New SqlCommand(query, DBManager.GetConnection())
            Dim SqlResults As SqlDataReader = command.ExecuteReader()

            While SqlResults.Read()
                Dim s As New OGlobalSettings()
                s.SettingName = SqlResults("SettingName")
                s.SettingValue = SqlResults("SettingValue")
                OrgSet.Add(s)
            End While

            HttpContext.Current.Session.Add("OrganizationGlobalSettings", OrgSet)

            If Not SqlResults.IsClosed Then
                SqlResults.Close()
            End If

            For Each s As OGlobalSettings In OrgSet
                If s.SettingName = SettingName Then
                    Return s.SettingValue
                End If
            Next

            Return DefaultValue

        Catch ex As Exception
            LogException(ex)
            Return DefaultValue
        Finally
            DBManager.Disconnect()
        End Try

    End Function

    Shared Sub UpdateClientMpesaPayments()
        Try
            If UtilityFunctions.GetGlobalSetting("SMS_BALANCE_LOCAL") <> "YES" Then
                Return
            End If

            UtilityFunctions.InitiateSyncOnlineTransactions()

            UtilityFunctions.ProcessBulkSMSTopUps()

        Catch ex As Exception
            LogException(ex)

        End Try
    End Sub

    Shared Sub InitiateSyncOnlineTransactions()

        Dim DBManager As New DatabaseConnectionManager()

        Try
            Dim OrganizationID As String = UtilityFunctions.GetOrganizationID

            Dim query As String = ""

            Dim Username As String = ""
            Dim SourceName As String = ""
            Dim LastSyncID As String = "0"

            query = " EXEC GetOnlineTransactionParams '" + OrganizationID + "' "

            Dim cmd As New SqlCommand(query, DBManager.GetConnection)

            Dim SqlResults As SqlDataReader = cmd.ExecuteReader()

            While SqlResults.Read()

                Username = SqlResults("Username").ToString
                SourceName = SqlResults("SourceName").ToString
                LastSyncID = SqlResults("LastSyncID").ToString

                UtilityFunctions.SyncOnlineTransactions(Username, SourceName, LastSyncID)

            End While

        Catch ex As Exception
            Throw ex
        Finally
            DBManager.Disconnect()
        End Try
    End Sub

    Shared Sub SyncOnlineTransactions(Username As String, SourceName As String, LastSyncID As String)

        Dim DBManager As New DatabaseConnectionManager

        Try

            Dim OrganizationID As String = UtilityFunctions.GetOrganizationID

            Dim Url As String

            Url = UtilityFunctions.GetGlobalSetting("ONLINE_TRANSACTIONS_JSON_API_URL", "")

            If Url = "" Then
                Return
            End If

            If Not Url.EndsWith("/") Then
                Url += "/"
            End If

            Url += "OnlineTrans"

            Dim request As WebRequest
            Dim response As WebResponse

            Dim Params As New JsonHelper.OnlineTrans()
            Params.Username = Username
            Params.SourceName = SourceName
            Params.LastSyncID = LastSyncID

            Dim JS As New JavaScriptSerializer '--https://stackoverflow.com/questions/39328250/use-system-web-script-serialization-javascriptserializer-to-create-json-object-i

            Dim jsonParams As String = JS.Serialize(Params).ToString()

            Dim Encoder As New ASCIIEncoding()
            Dim data As Byte() = Encoder.GetBytes(jsonParams)

            request = WebRequest.Create(Url)

            request.ContentType = "application/json"
            request.Method = "POST"
            request.Timeout = 3600000
            request.ContentLength = data.Length

            request.GetRequestStream().Write(data, 0, data.Length)

            response = request.GetResponse()

            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As StreamReader = New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()

            reader.Close()
            dataStream.Close()
            response.Close()

            Dim Transactions As JsonHelper.OnlineTransResponse() = JsonHelper.DeserializeOnlineTransactionResponse(responseFromServer)

            For i As Integer = 0 To Transactions.Length - 1

                Dim cmd As New SqlCommand("SaveOnlineTransactions", DBManager.GetConnection)

                cmd.CommandType = System.Data.CommandType.StoredProcedure

                cmd.Parameters.Add(New SqlParameter("@OrganizationID", OrganizationID))
                cmd.Parameters.Add(New SqlParameter("@TransactionID", Transactions(i).TransactionID))
                cmd.Parameters.Add(New SqlParameter("@SourceName", Transactions(i).SourceName))
                cmd.Parameters.Add(New SqlParameter("@Username", Transactions(i).Username))
                cmd.Parameters.Add(New SqlParameter("@AccountReference", Transactions(i).StudentAccountNo))
                cmd.Parameters.Add(New SqlParameter("@PaidAmount", Transactions(i).PaidAmount))
                cmd.Parameters.Add(New SqlParameter("@ChannelRefNumber", Transactions(i).ChannelRefNumber))
                cmd.Parameters.Add(New SqlParameter("@BankRefNumber", Transactions(i).BankRefNumber))
                cmd.Parameters.Add(New SqlParameter("@DebitAccount", Transactions(i).DebitAccount))
                cmd.Parameters.Add(New SqlParameter("@PaymentMode", Transactions(i).PaymentMode))
                cmd.Parameters.Add(New SqlParameter("@TransactionDate", Transactions(i).TransactionDate))
                cmd.Parameters.Add(New SqlParameter("@PhoneNo", Transactions(i).PhoneNo))
                cmd.Parameters.Add(New SqlParameter("@CustomerName", Transactions(i).CustomerName))
                cmd.Parameters.Add(New SqlParameter("@DepositSlipFilePath", Transactions(i).DepositSlipFilePath))

                UtilityFunctions.LogSQLCommand(cmd)

                cmd.ExecuteNonQuery()

            Next

        Catch ex As Exception
            LogException(ex)
            Throw
        Finally
            DBManager.Disconnect()
        End Try
    End Sub
    Friend Shared Sub UpdateExportedpath(RefNo As String, ExportedReportPath As String)
        Dim DBManager As New DatabaseConnectionManager()

        Try

            Dim query As String = "UpdateExportedpath"

            Dim cmd As New SqlCommand(query, DBManager.GetConnection)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("RefNo", RefNo)
            cmd.Parameters.AddWithValue("ExportedReportPath", ExportedReportPath)
            UtilityFunctions.LogSQLCommand(cmd)

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            LogException(ex)
            Throw
        Finally
            DBManager.Disconnect()
        End Try
    End Sub
    Private Shared Sub ProcessBulkSMSTopUps()
        Dim DBManager As New DatabaseConnectionManager

        Try
            Dim OrganizationID As String = UtilityFunctions.GetOrganizationID

            Dim cmd As New SqlCommand("ProcessBulkSMSTopUps", DBManager.GetConnection)
            cmd.CommandType = System.Data.CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@OrganizationID", OrganizationID))

            UtilityFunctions.LogSQLCommand(cmd)

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            LogException(ex)
            Throw
        Finally
            DBManager.Disconnect()
        End Try
    End Sub

    Shared Function CleanTextHtmlEncode(text As String) As String
        Try

            text = HttpContext.Current.Server.HtmlEncode(text)

            Return text

        Catch ex As Exception
            UtilityFunctions.LogException(ex)
            Return ""
        End Try
    End Function

    Shared Function validatePhoneNumber(PhoneNumber) As Integer
        Dim DBManager As New DatabaseConnectionManager()
        Dim Valid As String = ""

        Dim query As String = "SELECT [dbo].[fn_ValidPhoneNumber]('" & PhoneNumber & "') AS Valid"

        Try
            Dim cmd As New SqlCommand(query, DBManager.GetConnection)
            Dim SqlReader As SqlDataReader = cmd.ExecuteReader()

            Do While SqlReader.Read
                Valid = SqlReader("Valid")
            Loop

            If Not SqlReader.IsClosed Then
                SqlReader.Close()
            End If

            Return Valid

        Catch ex As Exception
            Throw New ArgumentException("Exception Occured")
        Finally
            DBManager.Disconnect()
        End Try
    End Function

    Friend Shared Sub QueueSMSCCRecipient(Message As String, IsBulkSMS As Boolean)

        Dim DBManager As New DatabaseConnectionManager()

        Try

            Dim cmd As New SqlCommand("PopulateSMSCCRecipient", DBManager.GetConnection)
            cmd.CommandType = System.Data.CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("Msg", Message))
            cmd.Parameters.Add(New SqlParameter("StaffID", UtilityFunctions.GetLoggedOnStaffID))
            cmd.Parameters.Add(New SqlParameter("IsBulkSMS", Convert.ToBoolean(IsBulkSMS)))

            UtilityFunctions.LogSQLCommand(cmd)

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            LogException(ex)
            Throw
        Finally
            DBManager.Disconnect()
        End Try

    End Sub

    Shared Function validateEmail(Email) As Integer
        Dim DBManager As New DatabaseConnectionManager()
        Dim Valid As Integer = 0

        Dim query As String = "SELECT [dbo].[fn_ValidEmail]('" & Email & "') AS Valid"

        Try
            Dim cmd As New SqlCommand(query, DBManager.GetConnection)
            Dim SqlReader As SqlDataReader = cmd.ExecuteReader()

            Do While SqlReader.Read
                Valid = SqlReader("Valid")
            Loop

            If Not SqlReader.IsClosed Then
                SqlReader.Close()
            End If

            Return Valid

        Catch ex As Exception
            Throw New ArgumentException("Exception Occured")
        Finally
            DBManager.Disconnect()
        End Try
    End Function

    Friend Shared Function GetProjectIDFromStaffID(StaffID As String)

        Dim ProjectID As String = "0"

        Dim DBManager As New DatabaseConnectionManager()

        Dim query As String = "select top 1 id ProjectID from project where ProjectOfficerID ='" + StaffID + "'"

        Try
            Dim command As New SqlCommand(query, DBManager.GetConnection())

            Dim SqlResults As SqlDataReader = command.ExecuteReader()

            If SqlResults.Read() Then
                ProjectID = SqlResults("ProjectID").ToString
                SqlResults.Close()
            Else
                SqlResults.Close()
            End If

            DBManager.Disconnect()

            Return ProjectID
        Catch ex As Exception
            LogException(ex)
            Return ProjectID = "0"
        Finally
            DBManager.Disconnect()
        End Try
    End Function

    Public Shared Function GetCountyFeeInvoice(OrganizationCountyFeeInvoiceID As String) As Dictionary(Of String, String)

        Dim DBManager As New DatabaseConnectionManager()

        Try
            Dim PaymentMesaage As New Dictionary(Of String, String)
            Dim query As String = $"EXEC GetCountyFeeInvoice '{OrganizationCountyFeeInvoiceID}'"
            Dim command As New SqlCommand(query, DBManager.GetConnection())
            command.CommandType = CommandType.Text
            Dim SqlResults As SqlDataReader = command.ExecuteReader()

            While SqlResults.Read()
                PaymentMesaage.Add("OrganizationName", SqlResults("OrganizationName").ToString())
                PaymentMesaage.Add("Amount", FormatNumber(SqlResults("Amount").ToString()))
                PaymentMesaage.Add("OrganizationID", SqlResults("OrganizationID").ToString())
                PaymentMesaage.Add("PhoneNumber", SqlResults("PhoneNumber").ToString())
                PaymentMesaage.Add("InvoiceStatusID", SqlResults("InvoiceStatusID").ToString())
                PaymentMesaage.Add("MonthDesc", SqlResults("MonthDesc").ToString())
            End While

            If Not SqlResults.IsClosed Then
                SqlResults.Close()
            End If

            Return PaymentMesaage
        Catch ex As Exception
            UtilityFunctions.LogException(ex)
            Throw
        Finally
            DBManager.Disconnect()
        End Try
    End Function

    Public Shared Function GetCountyFeeBusInfo(NumberPlate As String) As Dictionary(Of String, String)

        Dim DBManager As New DatabaseConnectionManager()

        Try
            Dim PaymentMesaage As New Dictionary(Of String, String)
            Dim query As String = $"EXEC GetCountyFeeBusInfo '{NumberPlate}'"
            Dim command As New SqlCommand(query, DBManager.GetConnection())
            command.CommandType = CommandType.Text
            Dim SqlResults As SqlDataReader = command.ExecuteReader()

            While SqlResults.Read()
                PaymentMesaage.Add("OrganizationName", SqlResults("OrganizationName").ToString())
                PaymentMesaage.Add("Amount", FormatNumber(SqlResults("Amount").ToString()))
                PaymentMesaage.Add("NumberPlate", SqlResults("NumberPlate").ToString())
                PaymentMesaage.Add("PaymentStatus", SqlResults("PaymentStatus").ToString())
                PaymentMesaage.Add("OwnerName", SqlResults("OwnerName").ToString())
                PaymentMesaage.Add("OwnerPhoneNumber", SqlResults("OwnerPhoneNumber").ToString())
                PaymentMesaage.Add("VehicleType", SqlResults("VehicleType").ToString())
            End While

            If Not SqlResults.IsClosed Then
                SqlResults.Close()
            End If

            Return PaymentMesaage
        Catch ex As Exception
            UtilityFunctions.LogException(ex)
            Throw
        Finally
            DBManager.Disconnect()
        End Try
    End Function

End Class
