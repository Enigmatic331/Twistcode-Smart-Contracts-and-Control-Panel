Imports Nethereum.Web3
Imports Nethereum.Hex.HexTypes
Imports System.Numerics
Imports Nethereum.Util
Imports Newtonsoft.Json
Imports System.Text.RegularExpressions

Public Class TokenDistributor
    Dim failCount As Integer
    Dim gasPrice As BigInteger
    Dim filepath As String

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles btnDeploy.Click
        Dim proceed As Boolean = True
        Dim iweb3 As Web3
        Dim account As Accounts.Account

        Dim gas As New HexBigInteger(80000)
        Dim value As New HexBigInteger(0)

        Try
            'get wallet, create account object
            Dim fileOpener As OpenFileDialog = New OpenFileDialog
            Dim strFileName As String

            fileOpener.Title = "Select Ethereum JSON wallet"
            fileOpener.RestoreDirectory = True
            fileOpener.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"

            If fileOpener.ShowDialog() = DialogResult.OK Then
                'file selected - Allow to proceed
                strFileName = fileOpener.FileName

                'read file string
                Dim wallet As String = My.Computer.FileSystem.ReadAllText(strFileName)
                If Not String.IsNullOrEmpty(wallet) Then
                    'ask for password
                    Dim inputBox = New inputbox
                    Call inputBox.ShowDialog()
                    If String.IsNullOrEmpty(inputBox.GetInput) Then
                        MessageBox.Show("Please enter a password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        proceed = False
                    Else
                        Try
                            AddMessage("Decrypting wallet, this may take a couple seconds...")
                            account = Accounts.Account.LoadFromKeyStore(wallet, inputBox.GetInput)
                            iweb3 = New Web3(account, MasterForm.cmbNetwork.SelectedItem.Key.ToString)
                            proceed = True
                        Catch ex As Exception
                            AddMessage("Unable to unlock wallet. Please check if password is correct. Error: " & ex.Message)
                            proceed = False
                        End Try
                    End If
                    inputBox.Dispose()
                    inputBox = Nothing
                Else
                    MessageBox.Show("Please select a valid Ethereum JSON wallet.", "Select a wallet", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                proceed = False
                MessageBox.Show("Please select an Ethereum JSON wallet.", "Select a wallet", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            AddMessage("Error loading wallet: " & ex.Message)
            proceed = False
        End Try
        enableControls(True)

        'checks
        If rbSingleTransfer.Checked = True Then
            'check input
            If txtNum.Text.Length = 0 Then
                proceed = False
                AddMessage("Please enter an address to send tokens to!")
            ElseIf txtTo.Text.Length = 0 Then
                AddMessage("Please enter an amount of tokens to send!")
                proceed = False
            Else
                proceed = True
            End If
        ElseIf rbBulkTransfer.Checked = True Then
            'check file path exists
            If String.IsNullOrEmpty(filepath) Then
                proceed = False
                AddMessage("Please select a CSV file!")
            Else
                proceed = True
            End If
        End If


        If proceed Then
            'token contract
            Dim tokenContract = iweb3.Eth.GetContract(setting.ContractABI, setting.DeployedContract)

            enableControls(False)
            Me.Cursor = Cursors.WaitCursor
            Dim tokentransfer = tokenContract.GetFunction("distributeTokens")

            If rbSingleTransfer.Checked = True Then
                AddMessage("Distributing to address " & txtTo.Text & ", " & txtNum.Text & " tokens. Please wait...")
                Try
                    ' sending tokens
                    Dim numTokens = RemovePrefix(Web3.Convert.ToWei(txtNum.Text).ToString("X16"))
                    Dim toAccount = txtTo.Text

                    Dim transactionHash = Await tokentransfer.SendTransactionAndWaitForReceiptAsync(account.Address, gas, value, , toAccount, numTokens)
                    AddMessage("Tokens sent, transaction hash: " & transactionHash.TransactionHash)
                    AddMessage("")
                Catch ex As Exception
                    AddMessage("Error: " & ex.Message)
                End Try
            ElseIf rbBulkTransfer.Checked = True Then
                'read from CSV
                Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(filepath)
                    MyReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
                    MyReader.Delimiters = New String() {","}
                    Dim currentRow As String()

                    While Not MyReader.EndOfData
                        Try
                            currentRow = MyReader.ReadFields()
                            AddMessage("Distributing to address " & currentRow(0) & ", " & currentRow(1) & " tokens. Please wait...")

                            ' sending tokens
                            Dim numTokens = RemovePrefix(Web3.Convert.ToWei(currentRow(1)).ToString("X16"))
                            Dim toAccount = currentRow(0)

                            Dim transactionHash = Await tokentransfer.SendTransactionAndWaitForReceiptAsync(account.Address, gas, value, , toAccount, numTokens)
                            AddMessage("Tokens sent, transaction hash: " & transactionHash.TransactionHash)
                            AddMessage("")
                        Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                            AddMessage("Error: " & ex.Message)
                        End Try
                    End While
                End Using
            End If

            enableControls(True)
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Public Sub enableControls(ByVal bool As Boolean)
        btnDeploy.Enabled = bool
        txtNum.Enabled = bool
        txtTo.Enabled = bool
    End Sub

    Public Sub AddMessage(ByVal message As String)
        lsConsole.Items.Add(message)
        lsConsole.TopIndex = lsConsole.Items.Count - 1
        Application.DoEvents()
    End Sub

    Public Function RemovePrefix(ByVal input As String) As String
        If input.Substring(0, 2) = "0x" Then
            input = input.Substring(2)
        End If
        Return input
    End Function

    Private Sub txtNum_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtNum_TextChanged(sender As Object, e As EventArgs)
        Dim digitsOnly As Regex = New Regex("[^\d]")
        sender.Text = digitsOnly.Replace(sender.Text, "")
    End Sub

    Private Sub RadioButton_Changed(sender As Object, e As EventArgs) Handles rbBulkTransfer.CheckedChanged, rbSingleTransfer.CheckedChanged
        If rbSingleTransfer.Checked = True Then
            Label2.Enabled = True
            Label3.Enabled = True
            txtNum.Enabled = True
            txtTo.Enabled = True
            btnSelect.Enabled = False
            txtfile.Enabled = False
            Label4.Enabled = False
        ElseIf rbBulkTransfer.Checked = True Then
            Label2.Enabled = False
            Label3.Enabled = False
            txtNum.Enabled = False
            txtTo.Enabled = False
            btnSelect.Enabled = True
            txtfile.Enabled = True
            Label4.Enabled = True
        End If
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        'set radiobutton to radiobutton1 by default
        rbSingleTransfer.Checked = True
        txtAddress.Text = setting.DeployedContract
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        'check if directory makes sense
        'check if csv file is on the correct format
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "CSV Files | *.csv"
        openFileDialog.RestoreDirectory = True

        openFileDialog.ShowDialog()

        If openFileDialog.FileName.Length <> 0 Then
            filepath = openFileDialog.FileName

            'check file structure
            If CheckCSVFile(filepath) = True Then
                txtfile.Text = filepath
                AddMessage("File checks OK.")
            Else
                filepath = ""
                MessageBox.Show("Not a valid file. Please ensure CSV file starts from first line, and has only two columns (address,amount).", "File Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Else
            MessageBox.Show("Please select a file!", "File Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Function CheckCSVFile(ByVal fp As String) As Boolean
        Dim checkOK As Boolean = True

        'check to see if file is a valid csv file
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(filepath)
            MyReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
            MyReader.Delimiters = New String() {","}
            Dim currentRow As String()

            If MyReader.EndOfData Then
                AddMessage("CSV file is empty. Please load a CSV file with compatible data (address,amount).")
                checkOK = False
            End If
            Try
                currentRow = MyReader.ReadFields()
                If currentRow.Length > 2 Then
                    AddMessage("CSV file has more than two columns. Please load a CSV file with compatible data (address,amount).")
                    checkOK = False
                End If
            Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                MessageBox.Show("Error: " & ex.Message)
                checkOK = False
            End Try
        End Using

        Return checkOK
    End Function

    Private Sub txtfile_TextChanged(sender As Object, e As EventArgs) Handles txtfile.DoubleClick
        Call btnSelect_Click(btnSelect, Nothing)
    End Sub
End Class