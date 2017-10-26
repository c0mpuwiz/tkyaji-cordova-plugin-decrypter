Imports Plossum.CommandLine

<CommandLineManager(ApplicationName:="tkyaji decrypt utility",
                    Copyright:="Copyright (c) Vikram Kumar 2017")>
Class Options
    <CommandLineOption(Description:="Displays this help text")>
    Public Help As Boolean = False

    <CommandLineOption(Description:="Specifies the input file path", MinOccurs:=1)>
    Public Property InputFilePath() As String
        Get
            Return mInputFilePath
        End Get
        Set
            If [String].IsNullOrEmpty(Value) Then
                Throw New InvalidOptionValueException("The input file path must not be empty", False)
            End If
            mInputFilePath = Value
        End Set
    End Property

    <CommandLineOption(Description:="Specifies the Cipher Key", MinOccurs:=1)>
    Public Property CipherKey() As String
        Get
            Return mCipherKey
        End Get
        Set
            If [String].IsNullOrEmpty(Value) Then
                Throw New InvalidOptionValueException("The Cipher Key must not be empty", False)
            End If
            mCipherKey = Value
        End Set
    End Property

    <CommandLineOption(Description:="Specifies the Cipher IV", MinOccurs:=1)>
    Public Property CipherIV() As String
        Get
            Return mCipherIV
        End Get
        Set
            If [String].IsNullOrEmpty(Value) Then
                Throw New InvalidOptionValueException("The Cipher IV must not be empty", False)
            End If
            mCipherIV = Value
        End Set
    End Property

    <CommandLineOption(Description:="Specifies the output file path", MinOccurs:=1)>
    Public Property OutputFilePath() As String
        Get
            Return mOutputFilePath
        End Get
        Set
            If [String].IsNullOrEmpty(Value) Then
                Throw New InvalidOptionValueException("The output file path must not be empty", False)
            End If
            mOutputFilePath = Value
        End Set
    End Property

    Private mInputFilePath As String
    Private mCipherKey As String
    Private mCipherIV As String
    Private mOutputFilePath As String
End Class
