Imports Newtonsoft.Json
Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Http
Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization

Public Class AITSMSManager

    Public Shared Sub SendSMS(Recipients As String, RecipientName As String, RecipientType As String, Message As String, ID As String, LinkID As String)


        Dim username As String = "streamparcel"
        Dim apiKey As String = "0d080448709b5022a189cf3d01b96c6deb07eec09273cbc7cba292e779199936"
        Dim Originator As String = "SUPER_METRO"
        Dim BulkSMSMode As String = "1"
        Dim KeyWord As String = "SUPER_METRO"
        Dim ShortCode As String = ""

        Dim Cost As String = "0"

        Dim gateway As New AfricasTalkingGateway(username, apiKey)

        Dim OptionsHashTable = Nothing

        'When BulkSMSMode = 0, then this is a premium SMS and need to send from the ShortCode and NOT the School Seder ID.
        If BulkSMSMode = "0" Then
            'Premium bulk sms mode
            Originator = ShortCode

            OptionsHashTable = New Hashtable From {
                {"keyword", KeyWord},
                {"linkId", LinkID}
            }
        End If

        Try
            'Dim results As Object()
            Dim resultMessage As String

            If BulkSMSMode = "1" Then 'Not charging the recipient
                If Originator = "" Or Originator = "20414" Then
                    'Results = gateway.sendMessage(Recipients, Message) 'for the schools without alphnumeric originator
                    resultMessage = gateway.sendMessage(Recipients, Message) 'for the schools without alphnumeric originator
                Else
                    'results = gateway.sendMessage(Recipients, Message, Originator)
                    resultMessage = gateway.sendMessage(Recipients, Message, Originator)
                End If
            Else 'Charging the recipient
                'results = gateway.sendMessage(Recipients, Message, Originator, CInt(BulkSMSMode), OptionsHashTable)
                resultMessage = gateway.sendMessage(Recipients, Message, Originator, CInt(BulkSMSMode), OptionsHashTable)
            End If

            'For Each result In results

            '    If UtilityFunctions.GetGlobalSetting("SMS_BALANCE_LOCAL") = "YES" Then
            '        Cost = UtilityFunctions.GetSMSCost(Message)
            '    Else
            '        Cost = DirectCast(result("cost").ToString, String)
            '    End If

            '    LogAITSMS(DirectCast(result("number").ToString, String), RecipientName, RecipientType, Message,
            '              DirectCast(result("status").ToString, String), DirectCast(result("messageId").ToString, String), Cost, ID)

            'Next

            Cost = UtilityFunctions.GetSMSCost(Message, Recipients)

            ' LogAITSMS(Recipients, RecipientName, RecipientType, Message, resultMessage, ID, Cost, ID)

        Catch ex As AfricasTalkingGatewayException
            UtilityFunctions.LogException(ex)
            Throw
        End Try

    End Sub

    Public Shared Sub SendMultipleSMS(Recipients As String, Message As String)

        Message = UtilityFunctions.CleanTextHtmlDecode(Message)

        Dim username As String = "streamparcel"
        Dim apiKey As String = "28feb763edc95d829ecca3c0f648af2f14b28981b370780e797aaae6225aaabc"
        Dim Originator As String = "SUPER_METRO"
        Dim BulkSMSMode As String = "1"
        Dim KeyWord As String = "SUPER_METRO"
        Dim ShortCode As String = ""

        Dim PhoneNumber As String = ""
        Dim SentStatus As String = ""
        Dim SentStatusCode As String = ""
        Dim Cost As String = "0"
        Dim MessageID As String = ""

        Dim LinkID As String = ""

        'Create a data table to hold all the records
        Dim dt As New DataTable()
        dt.Columns.Add(New DataColumn("PhoneNumber", GetType(String)))
        dt.Columns.Add(New DataColumn("SentStatus", GetType(String)))
        dt.Columns.Add(New DataColumn("SentStatusCode", GetType(String)))
        dt.Columns.Add(New DataColumn("Cost", GetType(String)))
        dt.Columns.Add(New DataColumn("MessageID", GetType(String)))

        Dim gateway As New AfricasTalkingGateway(username, apiKey)

        Dim OptionsHashTable As Hashtable = Nothing

        'When BulkSMSMode = 0, then this is a premium SMS and need to send from the ShortCode and NOT the School Seder ID.
        If BulkSMSMode = "0" Then
            'Premium bulk sms mode
            Originator = ShortCode

            OptionsHashTable = New Hashtable From {
                {"keyword", KeyWord},
                {"linkId", LinkID}
            }
        End If

        Try
            'Dim results As Object()
            Dim resultMessage As Object() = gateway.sendMultipleMessages(Recipients, Message, Originator, CInt(BulkSMSMode), OptionsHashTable)

            For Each result In resultMessage

                PhoneNumber = DirectCast(result("number").ToString, String)
                SentStatus = DirectCast(result("status").ToString, String)
                SentStatusCode = DirectCast(result("statusCode").ToString, String)
                Cost = UtilityFunctions.GetSMSCost(Message, PhoneNumber) ' DirectCast(result("cost").ToString, String)
                MessageID = DirectCast(result("messageId").ToString, String)

                dt.Rows.Add(PhoneNumber, SentStatus, SentStatusCode, Cost, MessageID)

            Next

            'LogMultipleAITSMS(dt, Message)

        Catch ex As AfricasTalkingGatewayException
            UtilityFunctions.LogException(ex)
            Throw
        End Try

    End Sub


    Public Shared Function QueueAITSMS(Recipient As String, RecipientName As String, RecipientType As String, Message As String, SendWhatsApp As String, Optional SMSType As String = "") As Integer

        Dim DBManager As New DatabaseConnectionManager()

        Try

            Dim cmd As New SqlCommand("QueueAITSMS", DBManager.GetConnection)

            cmd.Parameters.AddWithValue("Recipient", Recipient)
            cmd.Parameters.AddWithValue("RecipientName", RecipientName)
            cmd.Parameters.AddWithValue("RecipientType", RecipientType)
            cmd.Parameters.AddWithValue("Message", Message)
            cmd.Parameters.AddWithValue("InitiatedBy", UtilityFunctions.GetLoggedOnUserID)
            cmd.Parameters.AddWithValue("SendWhatsApp", SendWhatsApp)
            cmd.Parameters.AddWithValue("SMSType", SMSType)

            cmd.CommandType = CommandType.StoredProcedure

            UtilityFunctions.LogSQLCommand(cmd)

            cmd.ExecuteNonQuery()

            Return 1

        Catch ex As Exception
            UtilityFunctions.LogException(ex)
            Throw ex
        Finally
            DBManager.Disconnect()
        End Try

    End Function

    Public Shared Function QueueMultipleAITSMS(dt As DataTable) As Integer

        Dim DBManager As New DatabaseConnectionManager()

        Try

            Dim cmd As New SqlCommand("QueueMultipleAITSMS", DBManager.GetConnection)

            cmd.Parameters.AddWithValue("dt", dt)

            cmd.CommandType = CommandType.StoredProcedure

            cmd.CommandTimeout = 900 '15 minutes timeout

            UtilityFunctions.LogSQLCommand(cmd)

            cmd.ExecuteNonQuery()

            Return 1

        Catch ex As Exception
            UtilityFunctions.LogException(ex)
            Throw ex
        Finally
            DBManager.Disconnect()
        End Try

    End Function

    Public Shared Sub ReceiveSMS()

        ' Specify your login credentials
        Dim username As String = ConfigurationManager.AppSettings("AIT_SMS_USER_NAME")
        Dim apiKey As String = ConfigurationManager.AppSettings("AIT_SMS_API_KEY")

        Dim sender As String = ""
        Dim recipient As String = ""
        Dim text As String = ""
        Dim timestamp As Date = Now
        Dim id As Integer = 0
        Dim linkId As String
        Dim networkCode As String

        ' Create a new instance of our awesome gateway class
        Dim gateway As New AfricasTalkingGateway(username, apiKey)

        ' Our gateway will return 10 messages at a time back to you, starting with
        ' what you currently believe is the lastReceivedId. Specify 0 for the first
        ' time you access the gateway, and the ID of the last message we sent you
        ' on subsequent results
        Dim lastReceivedId As Integer = UtilityFunctions.GetScalarValue("SELECT COALESCE(MAX(MessageID), 0) FROM mzizi_live..ReceivedSMS") 'HttpContext.Current.Session("lastReceivedId")

        'UtilityFunctions.LogText("lastReceivedId: " + lastReceivedId.ToString)

        ' Any gateway errors will be captured by our custom Exception class below,
        ' so wrap the call in a try-catch block          
        Try

            ' Here is a sample of how to fetch all messages using a while loop
            Dim results = gateway.fetchMessages(lastReceivedId)

            For Each result In results

                sender = CStr(result("from"))
                recipient = CStr(result("to"))
                text = CStr(result("text"))
                timestamp = CDate(result("date"))
                id = CInt(result("id"))
                linkId = CStr(result("linkId"))
                networkCode = "63902" 'CStr(result("networkCode")) '--63902: Safaricom

                If id < lastReceivedId Then 'Avoid un-necessary db traffic if DB is more updated...
                    Continue For
                End If

                SaveReceicedSMS(id, sender, recipient, text, timestamp, linkId, networkCode)

                ComposeSendResponse(id, sender, recipient, text, timestamp, linkId, networkCode)

                lastReceivedId = CInt(result("id"))

                HttpContext.Current.Session("lastReceivedId") = lastReceivedId

            Next

        Catch ex As AfricasTalkingGatewayException
            UtilityFunctions.LogException(ex)
            Throw
        End Try

    End Sub

    Public Shared Function SaveReceicedSMS(MessageID As String, Sender As String, Recipient As String, Message As String, TimeSent As Date, LinkID As String, NetworkCode As String) As Integer

        Dim DBManager As New DatabaseConnectionManager()

        Try

            Dim cmd As New SqlCommand("SaveReceicedSMS", DBManager.GetConnection)

            cmd.Parameters.AddWithValue("MessageID", MessageID)
            cmd.Parameters.AddWithValue("Sender", Sender)
            cmd.Parameters.AddWithValue("Recipient", Recipient)
            cmd.Parameters.AddWithValue("Message", Message)
            cmd.Parameters.AddWithValue("TimeSent", TimeSent)
            cmd.Parameters.AddWithValue("LinkID", LinkID)
            cmd.Parameters.AddWithValue("NetworkCode", NetworkCode)

            cmd.CommandType = CommandType.StoredProcedure

            UtilityFunctions.LogSQLCommand(cmd)

            cmd.ExecuteNonQuery()

            Return 1

        Catch ex As Exception
            UtilityFunctions.LogException(ex)
            Throw ex
        Finally
            DBManager.Disconnect()
        End Try

    End Function

    Public Shared Function ComposeSendResponse(MessageID As String, Subscriber As String, ShortCode As String, Message As String, TimeSent As Date, LinkID As String, NetworkCode As String) As String

        Dim DBManager As New DatabaseConnectionManager()

        Try
            Message = Message.Trim()

            Dim response As String = ""

            Dim KeyWord As String = ""
            Dim ServiceName As String = ""
            Dim ServiceData As String = Message.Trim() 'Initialize (remove spaces from both ends)

            Dim param As New SqlParameter
            Dim reader As SqlDataReader

            Try
                KeyWord = Split(Message, " ")(0)
                ServiceData = ServiceData.Replace(KeyWord, "")
            Catch ex As Exception
                'UtilityFunctions.LogException(ex)
                KeyWord = ""
            End Try

            Try
                ServiceName = Split(Message, " ")(1)
                ServiceData = ServiceData.Replace(ServiceName, "")
            Catch ex As Exception
                'UtilityFunctions.LogException(ex)
                ServiceName = ""
            End Try

            ServiceData = ServiceData.Trim()

            Dim cmd As New SqlCommand("ComposeSMSResponse", DBManager.GetConnection)

            cmd.Parameters.AddWithValue("MessageID", MessageID)
            cmd.Parameters.AddWithValue("KeyWord", KeyWord)
            cmd.Parameters.AddWithValue("ServiceName", ServiceName)
            cmd.Parameters.AddWithValue("ServiceData", ServiceData)

            cmd.CommandType = CommandType.StoredProcedure

            reader = cmd.ExecuteReader()

            While reader.Read()

                response = reader("Response").ToString

                If response.Length > 0 Then
                    ' SendPremiumSMS(Subscriber, response, LinkID, ShortCode)
                    'APISendPremiumSMS(Subscriber, response, LinkID, ShortCode)
                End If

            End While

            reader.Close()

            Return response

        Catch ex As Exception

            UtilityFunctions.LogException(ex)

            'SendPremiumSMS(Subscriber, "Sorry, you have made an invalid request.", LinkID, ShortCode)

        Finally
            DBManager.Disconnect()
        End Try

    End Function

    'Public Shared Sub SendWhatsAppMsg(Recipients As String, Message As String)

    '    If Not UtilityFunctions.GetGlobalSetting("SEND_WHATSAPP_MSGS") = "YES" Then
    '        Return
    '    End If

    '    Try

    '        Dim Sender As String = UtilityFunctions.GetGlobalSetting("SEND_WHATSAPP_SENDER")
    '        Dim IMEI As String = UtilityFunctions.GetGlobalSetting("SEND_WHATSAPP_IMEI")

    '        'Dim wa As WhatsApp = New WhatsApp(Sender, "48aBzo6ouRIL70V/l+usD6gESM=", "Simon Kiarie", False, False)
    '        'Dim wa As WhatsApp = New WhatsApp(Sender, "P3nfoKMgTgytnjq34U1wJmLTorM=", "Simon Kiarie", False, False)
    '        'Dim wa As WhatsApp = New WhatsApp(Sender, "%e6%e9%1f%aa6b%9b%d3%9a%20%e0l%23c%ea%2f7%5e%ce%e9", "Simon Kiarie", False, False)

    '        Dim wa As WhatsApp = New WhatsApp(Sender, IMEI, "Simon Kiarie", False, False)
    '        wa.SendMessage(Recipients, Message)

    '    Catch ex As Exception
    '        UtilityFunctions.LogException(ex)
    '        Throw
    '    End Try

    'End Sub

    Shared Function GetAITAccountBalance() As String

        Try

            Dim Balance As String


            Balance = GetOnlineAITAccountBalance()

            Return Balance

        Catch ex As AfricasTalkingGatewayException
            UtilityFunctions.LogException(ex)
            Return "0"
        End Try
    End Function

    Shared Function GetOnlineAITAccountBalance() As String

        Try

            Dim Worth As Decimal = 0

            Dim username As String = "streamparcel"
            Dim apiKey As String = "0d080448709b5022a189cf3d01b96c6deb07eec09273cbc7cba292e779199936"

            Dim gateway As New AfricasTalkingGateway(username, apiKey)
            Dim userData As Object = gateway.getUserData()

            Dim balance As String = userData("balance")

            Try
                Dim digitsOnly As New Regex("[^0-9.]")

                balance = digitsOnly.Replace(balance, "")

                Worth = balance * (CDbl(1) / CDbl(1))

                balance = FormatNumber(balance, 0)

            Catch ex As Exception
                UtilityFunctions.LogException(ex)
                'Ignore errors
            End Try

            'Return "Current Account Balance: " + balance + " Units Worth " + FormatNumber(Worth, 2) + "."
            Return balance

        Catch ex As AfricasTalkingGatewayException
            UtilityFunctions.LogException(ex)
            Return ""
        End Try
    End Function

    Shared Function GetTopUpInstructions() As String
        Try

            Dim PayBill As String = "459512"
            Dim Account As String = "DEMO39.SMS"

            If Account = "" Then
                Return ""
            End If

            'Return "<br /><br />To load your bulk SMS account using MPESA: <br />Select <span class='sms_balance_msg'>Pay Bill</span> <br />Enter Business Number as <span class='sms_balance_msg'>459512</span> <br />Enter your Account Number as <span class='sms_balance_msg'>" + Account.ToUpper() +
            '    "</span> <br />Enter the <span class='sms_balance_msg'>Amount</span> you wish to topup and complete the MPESA process. "
            Return "To load your bulk SMS account using MPESA: Select <span class='sms_balance_msg'>Pay Bill</span> Enter Business Number as <span class='sms_balance_msg'>459512</span> Enter your Account Number as <span class='sms_balance_msg'>" + Account.ToUpper() +
                "</span> Enter the <span class='sms_balance_msg'>Amount</span> you wish to topup and complete the MPESA process. "

        Catch ex As Exception
            UtilityFunctions.LogException(ex)
            Return ex.Message
        End Try
    End Function

End Class