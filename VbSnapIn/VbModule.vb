Imports System.Windows.Forms
Imports CommonSnappableTypes

<CompanyInfo(CompanyName:="Chucky's Software", CompanyUrl:="www.chuckysoft.com")>
Public Class VbModule
    Implements IAppFunctionality

    Public Sub DoIt() Implements IAppFunctionality.DoIt
        MessageBox.Show("You have just used the VB snap in!")
    End Sub
End Class
