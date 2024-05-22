Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports SundusEx

Public Class DatabaseConnectionManager

    Dim ConnectionString As String = Nothing
    Dim DBConnection As SqlConnection = Nothing
    Dim objXConn As OleDbConnection = Nothing

    Public Sub New(Optional ByVal UseMasterDB As Boolean = False)
        Try
            If UseMasterDB Then
                ConnectionString = ConfigurationManager.AppSettings("ConnectionString")
            Else
                ConnectionString = GetClientConnectionString()
            End If

            DBConnection = New SqlConnection(ConnectionString)

            DBConnection.Open()

            Try
                ''--https://stackoverflow.com/questions/1421002/getting-the-name-of-the-calling-method
                'UtilityFunctions.LogText("Connection Openned: " + New Diagnostics.StackFrame(1).GetMethod.Name)
                'UtilityFunctions.LogText("Connection Openned: " + New Diagnostics.StackFrame(2).GetMethod.Name)
                'UtilityFunctions.LogText("Connection Openned: " + New Diagnostics.StackFrame(3).GetMethod.Name)
                'UtilityFunctions.LogText("Connection Openned: " + New Diagnostics.StackFrame(4).GetMethod.Name)
            Catch ex As Exception

            End Try

        Catch ex As Exception
            UtilityFunctions.LogException(ex)
            Throw
        End Try
    End Sub

    Public Function GetDataSourceName() As String

        Try

            GetDataSourceName = Split(ConnectionString, ";")(0).ToString.Split("=")(1).Trim

        Catch ex As Exception
            UtilityFunctions.LogException(ex)
            Return "localhost"
        End Try

    End Function

    Public Function GetInitialCatalogName() As String

        Try

            GetInitialCatalogName = Split(ConnectionString, ";")(1).ToString.Split("=")(1).Trim

        Catch ex As Exception
            UtilityFunctions.LogException(ex)
            Return "sundusex"
        End Try

    End Function

    Public Function GetDataSourceUserName() As String

        Try

            GetDataSourceUserName = Split(ConnectionString, ";")(2).ToString.Split("=")(1).Trim

        Catch ex As Exception
            UtilityFunctions.LogException(ex)
            Return "sundusex"
        End Try

    End Function

    Public Function GetDataSourcePassword() As String

        Try

            GetDataSourcePassword = Split(ConnectionString, ";")(3).ToString.Split("=")(1).Trim

        Catch ex As Exception
            UtilityFunctions.LogException(ex)
            Return "sundusex"
        End Try

    End Function

    Public ReadOnly Property GetState()
        Get
            Return DBConnection.State
        End Get
    End Property

    Public ReadOnly Property GetConnection()
        Get
            Return DBConnection
        End Get
    End Property

    Public Sub Disconnect()
        Try
            DBConnection.Close()

            ''--https://stackoverflow.com/questions/1421002/getting-the-name-of-the-calling-method
            'UtilityFunctions.LogText("Connection Openned: " + New Diagnostics.StackFrame(1).GetMethod.Name)
            'UtilityFunctions.LogText("Connection Openned: " + New Diagnostics.StackFrame(2).GetMethod.Name)
            'UtilityFunctions.LogText("Connection Openned: " + New Diagnostics.StackFrame(3).GetMethod.Name)
            'UtilityFunctions.LogText("Connection Openned: " + New Diagnostics.StackFrame(4).GetMethod.Name)

        Catch ex As Exception
            UtilityFunctions.LogException(ex)
            'MsgBox("Cannot close connection:" + Err.Description)
            Throw
        End Try
    End Sub

    'Public ReadOnly Property GetExcelConnection(FileName As String)
    '    Get
    '        Try
    '            Dim path As String = "C:\Users\Chillax\Documents\Visual Studio 2008\Projects\SchoolManagementSystem\SchoolManagementSystem\SchoolManagementSystem\Excel_Uploads\" + FileName + ""
    '            ' Connect to the Excel Spreadsheet
    '            Dim xConnStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;" &
    '                "Data Source=" + path + ";" &
    '                "Extended Properties=Excel 12.0"

    '            ' create your excel connection object using the connection string
    '            objXConn = New OleDbConnection(xConnStr)
    '            objXConn.Open()
    '            Return objXConn
    '        Catch ex As Exception
    '            UtilityFunctions.LogException(ex)
    '            Return Nothing
    '        End Try
    '        Return Nothing
    '    End Get
    'End Property

    Public Sub DisconnectExcelConnection()
        Try
            objXConn.Close()
        Catch ex As Exception
            UtilityFunctions.LogException(ex)
            'MsgBox("Cannot close connection:" + Err.Description)
        End Try
    End Sub

    Shared Function CommandAsSql(ByVal sc As SqlCommand) As String
        Dim sql As StringBuilder = New StringBuilder()
        Dim FirstParam As Boolean = True
        Dim ParamType As String = ""

        sql.AppendLine("use " + sc.Connection.Database + ";")

        Select Case sc.CommandType
            Case CommandType.StoredProcedure
                sql.AppendLine("declare @return_value int;")

                For Each sp As SqlParameter In sc.Parameters

                    If sp.SqlDbType = SqlDbType.VarChar Then
                        ParamType = "varchar(max)"
                    ElseIf sp.SqlDbType = SqlDbType.NVarChar Then
                        ParamType = "nvarchar(max)"
                    Else
                        ParamType = sp.SqlDbType.ToString()
                    End If

                    If (sp.Direction = ParameterDirection.InputOutput) OrElse (sp.Direction = ParameterDirection.Output) Then
                        sql.Append("declare @" + sp.ParameterName + vbTab + ParamType + vbTab + "= ")
                        sql.AppendLine((If((sp.Direction = ParameterDirection.Output), "null", ParameterValueForSQL(sp))) + ";")
                    End If
                Next

                sql.AppendLine("exec [" + sc.CommandText + "]")

                For Each sp As SqlParameter In sc.Parameters

                    'UtilityFunctions.LogText(sp.ParameterName)

                    'If sp.ParameterName = "ImageData" Then
                    '    UtilityFunctions.LogText(sp.DbType)
                    'End If

                    If sp.Direction <> ParameterDirection.ReturnValue Then
                        sql.Append(If((FirstParam), vbTab, vbTab + ", "))
                        If FirstParam Then FirstParam = False

                        If sp.Direction = ParameterDirection.Input Then
                            sql.AppendLine("@" + sp.ParameterName + " = " + ParameterValueForSQL(sp))
                        Else
                            sql.AppendLine("@" + sp.ParameterName + " = @" + sp.ParameterName + " output")
                        End If
                    End If
                Next

                sql.AppendLine(";")
                sql.AppendLine("select 'Return Value' = convert(varchar, @return_value);")

                For Each sp As SqlParameter In sc.Parameters
                    If (sp.Direction = ParameterDirection.InputOutput) OrElse (sp.Direction = ParameterDirection.Output) Then
                        sql.AppendLine("select '" + sp.ParameterName + "' = convert(varchar(max), @" + sp.ParameterName + ");")
                    End If
                Next

            Case CommandType.Text
                sql.AppendLine(sc.CommandText)
        End Select

        Return sql.ToString()

    End Function

    Shared Function ParameterValueForSQL(ByVal sp As SqlParameter) As String
        Dim retval As String = ""

        If sp.Value Is Nothing Then
            retval = "'NULL'"
            Return retval
        End If

        Select Case sp.SqlDbType
            Case SqlDbType.Char, SqlDbType.NChar, SqlDbType.NText, SqlDbType.NVarChar, SqlDbType.Text, SqlDbType.Time, SqlDbType.VarChar, SqlDbType.Xml, SqlDbType.Date, SqlDbType.DateTime, SqlDbType.DateTime2, SqlDbType.DateTimeOffset
                retval = "'" + sp.Value.ToString().Replace("'", "''") + "'"
            Case SqlDbType.Bit
                retval = If((sp.Value.ToBooleanOrDefault(False)), "1", "0")
            Case Else
                retval = sp.Value.ToString().Replace("'", "''")
        End Select

        Return retval
    End Function

    Public Shared Function GetClientInitialCatalog() As String

        Dim DBConnection As SqlConnection = Nothing

        Try            'Dim ConnectionString As String = ConfigurationManager.AppSettings("ConnectionString")


            Dim ClientInitialCatalog As String = "sundusex"


            Return ClientInitialCatalog

        Catch ex As Exception
            'Throw
            HttpContext.Current.Response.Redirect("Logout.aspx?err=" + ex.Message)
        Finally
            If Not DBConnection Is Nothing Then
                If DBConnection.State = ConnectionState.Open Then
                    DBConnection.Close()
                End If
            End If
        End Try

    End Function

    Shared Function InitializeClientConnectionString(ClientInitialCatalog As String) As String

        Dim strConnectionString As String = ""

        strConnectionString = ConfigurationManager.AppSettings("ConnectionString")

        HttpContext.Current.Session("ClientInitialCatalog") = ClientInitialCatalog
        HttpContext.Current.Session("ClientConnectionString") = strConnectionString

        Return strConnectionString

    End Function

    Shared Function GetClientConnectionString() As String

        Dim strConnectionString As String = ""
        Dim ClientInitialCatalog = GetClientInitialCatalog()
        strConnectionString = ConfigurationManager.AppSettings("ConnectionString").Replace("sundusex", ClientInitialCatalog)

        If Not HttpContext.Current.Session Is Nothing Then
            HttpContext.Current.Session("ClientConnectionString") = strConnectionString
        End If

        Return strConnectionString

    End Function

End Class
