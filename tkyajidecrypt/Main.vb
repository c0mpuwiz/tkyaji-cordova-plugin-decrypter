Imports System.Security.Cryptography
Imports Plossum.CommandLine

Module Main
    Function Main(args As String()) As Integer
        Dim options As New Options()
        Dim parser As New CommandLineParser(options)
        parser.Parse()
        Console.WriteLine(parser.UsageInfo.GetHeaderAsString(78))
        If options.Help Then
            Console.WriteLine(parser.UsageInfo.GetOptionsAsString(78))
            Return 0
        ElseIf parser.HasErrors Then
            Console.WriteLine(parser.UsageInfo.GetErrorsAsString(78))
            Return -1
        End If

        Try
            Dim aes As New RijndaelManaged
            aes.BlockSize = 128
            aes.KeySize = 256

            aes.Mode = CipherMode.CBC
            aes.Padding = PaddingMode.None
            aes.Key = Text.Encoding.ASCII.GetBytes(options.CipherKey)
            aes.IV = Text.Encoding.ASCII.GetBytes(options.CipherIV)

            Dim decrypto As ICryptoTransform = aes.CreateDecryptor
            Dim encryptedString As Byte() = Convert.FromBase64String(ReadFile(options.InputFilePath))
            Dim decryptedString = decrypto.TransformFinalBlock(encryptedString, 0, encryptedString.Length)
            Save(options.OutputFilePath, Text.Encoding.ASCII.GetString(decryptedString))
            Console.WriteLine(Text.Encoding.ASCII.GetString(decryptedString))
            Console.ReadLine()
        Catch ex As Exception
            Debug.WriteLine(ex.Message.ToString)
            Console.ReadLine()
        End Try
        Return 0
    End Function

    Sub Save(filepath As String, value As String)
        Dim info As New IO.FileInfo(filepath)
        Dim fs As IO.FileStream = info.Create()
        fs.Write(Text.Encoding.ASCII.GetBytes(value), 0, Text.Encoding.ASCII.GetBytes(value).Length)
        fs.Close()
        fs.Dispose()
    End Sub

    Function ReadFile(filepath As String) As String
        Dim fs As New IO.StreamReader(filepath, IO.FileMode.Open)
        ReadFile = fs.ReadToEnd()
        fs.Close()
        fs.Dispose()
    End Function

End Module
