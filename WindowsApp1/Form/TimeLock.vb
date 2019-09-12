Imports Nethereum.Web3
Imports Nethereum.Hex.HexTypes
Imports System.Numerics
Imports Nethereum.Util
Imports Newtonsoft.Json
Imports System.Text.RegularExpressions

Public Class TimeLock
    Public Sub AddMessage(ByVal message As String)
        lsConsole.Items.Add(message)
        lsConsole.TopIndex = lsConsole.Items.Count - 1
        Application.DoEvents()
    End Sub

    Private Async Sub btnDeploy_Click(sender As Object, e As EventArgs) Handles btnDeploy.Click
        Dim proceed As Boolean = True
        Dim account As Accounts.Account
        Dim iweb3 As Web3
        Dim contractAddress As String

        If String.IsNullOrEmpty(txtAddress.Text) Then
            AddMessage("Enter an beneficiary address!")
            proceed = False
        ElseIf String.IsNullOrEmpty(setting.DeployedContract) Then
            AddMessage("Make sure the ERC20 contract is deployed, otherwise include the contract address on the DeployedContract field in settings.json!")
            proceed = False
        End If

        If proceed Then
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
                MessageBox.Show("Error loading wallet: " & ex.Message)
                proceed = False
            End Try

            If proceed Then
                enableControls(False)
                AddMessage("Wallet unlocked, checking if wallet has sufficient balance for contract deployment, and attempting deploy.")
                AddMessage("This may take a few minutes...")
                AddMessage("")
                Me.Cursor = Cursors.WaitCursor

                'insert compiled contracts and initialise web3
                Dim abi = setting.TimeLockABI
                Dim byteCode = setting.TimeLockByteCode

                Dim beneficiaryAddress As String = txtAddress.Text
                Dim tmp As DateTimeOffset = New DateTimeOffset(DateTimePicker1.Value, TimeSpan.Zero)
                Dim unixTime = tmp.ToUnixTimeSeconds

                Try

                    Dim hGasPrice = New HexBigInteger(setting.GasPriceInWei)
                    Dim value = New HexBigInteger(0)
                    Dim gas = Await iweb3.Eth.DeployContract.EstimateGasAsync(abi, byteCode, account.Address, setting.DeployedContract, beneficiaryAddress, unixTime)
                    Dim accountTotal = Await iweb3.Eth.GetBalance.SendRequestAsync(account.Address)
                    ' calculate for a surplus of 10% - Let's not leave the account empty shall we....
                    If ((gas.Value / 90 * 100) * hGasPrice.Value) < accountTotal.Value Then
                        Dim receiptHash = Await iweb3.Eth.DeployContract.SendRequestAndWaitForReceiptAsync(abi, byteCode, account.Address, gas, hGasPrice, value, Nothing, setting.DeployedContract, beneficiaryAddress, unixTime)


                        If receiptHash IsNot Nothing Then
                            contractAddress = receiptHash.ContractAddress
                            AddMessage("The contract is created at address " & contractAddress & ". (address is copied to clipboard)")
                            AddMessage("You can now send tokens as required to this contract for time lock purposes")
                            Clipboard.SetText(contractAddress)
                        End If

                    Else
                        AddMessage("Balance insufficient. Please ensure your Ethereum address has at least " & Web3.Convert.FromWei((gas.Value / 90 * 100) * hGasPrice.Value, UnitConversion.EthUnit.Ether) & " ETH")
                    End If


                Catch ex As Exception
                    MessageBox.Show("Error during contract deployment. Error: " & ex.Message)
                End Try

                enableControls(True)
                Me.Cursor = Cursors.Default
                AddMessage("")
            End If
        End If
    End Sub

    Public Sub enableControls(ByVal bool As Boolean)
        DateTimePicker1.Enabled = bool
        btnDeploy.Enabled = bool
        txtAddress.Enabled = bool
    End Sub
End Class