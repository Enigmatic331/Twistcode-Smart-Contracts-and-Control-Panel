Imports Nethereum.Web3
Imports Newtonsoft.Json
Imports System.Numerics
Imports Nethereum.Hex.HexTypes
Imports Nethereum.Util

Public Class MasterForm
    Private Sub MasterForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        cmbNetwork.DataSource = New BindingSource(setting.Network, Nothing)
        cmbNetwork.DisplayMember = "Value"
        cmbNetwork.ValueMember = "Key"
        cmbNetwork.SelectedIndex = 0

        If String.IsNullOrEmpty(setting.DeployedContract) Then
            btndeployToken.Enabled = True
            GroupBox2.Enabled = True
        Else
            cmbNetwork.SelectedIndex = cmbNetwork.FindStringExact(setting.DeployedToNetwork)
            btndeployToken.Enabled = False
            GroupBox2.Enabled = False
        End If
    End Sub

    Private Async Sub btndeployToken_Click(sender As Object, e As EventArgs) Handles btndeployToken.Click
        Dim proceed As Boolean
        Dim account As Accounts.Account
        Dim iweb3 As Web3
        Dim contractAddress As String

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
                            account = Accounts.Account.LoadFromKeyStore(wallet, inputBox.GetInput)
                            iweb3 = New Web3(account, cmbNetwork.SelectedItem.Key.ToString)
                            proceed = True
                        Catch ex As Exception
                            MessageBox.Show("Unable to unlock wallet. Please check if password is correct. Error: " & ex.Message)
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
            MessageBox.Show("Wallet unlocked, checking if wallet has sufficient balance for contract deployment, and attempting deploy. This may take a few minutes...")
            Me.Cursor = Cursors.WaitCursor

            'insert compiled contracts and initialise web3
            Dim TokenAbi = setting.ContractABI
            Dim TokenbyteCode = setting.ContractByteCode

            Try

                Dim hGasPrice = New HexBigInteger(setting.GasPriceInWei)
                Dim value = New HexBigInteger(0)
                Dim gas = Await iweb3.Eth.DeployContract.EstimateGasAsync(TokenAbi, TokenbyteCode, account.Address, Nothing)
                Dim accountTotal = Await iweb3.Eth.GetBalance.SendRequestAsync(account.Address)
                ' calculate for a surplus of 10% - Let's not leave the account empty shall we....
                If ((gas.Value / 90 * 100) * hGasPrice.Value) < accountTotal.Value Then
                    Dim receiptHash = Await iweb3.Eth.DeployContract.SendRequestAndWaitForReceiptAsync(TokenAbi, TokenbyteCode, account.Address, gas, hGasPrice, value, Nothing)


                    If receiptHash IsNot Nothing Then
                        contractAddress = receiptHash.ContractAddress
                        MessageBox.Show("The token contract is created at address " & contractAddress & vbCrLf & "The address is automatically copied to your clipboard.")
                        Clipboard.SetText(contractAddress)

                        setting.DeployedContract = contractAddress
                        setting.DeployedToNetwork = cmbNetwork.SelectedItem.Value.ToString
                        Dim json As String = JsonConvert.SerializeObject(setting, Formatting.Indented)
                        Dim objWriter As New System.IO.StreamWriter("settings.json")
                        objWriter.Write(json)
                        objWriter.Close()
                    End If

                Else
                    MessageBox.Show("Balance insufficient. Please ensure your Ethereum address has at least " & Web3.Convert.FromWei((gas.Value / 90 * 100) * hGasPrice.Value, UnitConversion.EthUnit.Ether) & " ETH")
                End If


            Catch ex As Exception
                MessageBox.Show("Error during token deployment. Error: " & ex.Message)
            End Try

            enableControls(True)
            Me.Cursor = Cursors.Default

            'disable relevant controls
            GroupBox2.Enabled = False
            btndeployToken.Enabled = False
        End If
    End Sub

    Public Sub enableControls(ByVal bool As Boolean)
        If GroupBox2.Enabled = False Then
            btntimelockContract.Enabled = bool
            btntokenDistribute.Enabled = bool
        Else
            btndeployToken.Enabled = bool
            btntimelockContract.Enabled = bool
            btntokenDistribute.Enabled = bool
        End If
    End Sub

    Private Sub btntimelockContract_Click(sender As Object, e As EventArgs) Handles btntimelockContract.Click
        TimeLock.ShowDialog()
    End Sub

    Private Sub btntokenDistribute_Click(sender As Object, e As EventArgs) Handles btntokenDistribute.Click
        TokenDistributor.ShowDialog()
    End Sub
End Class