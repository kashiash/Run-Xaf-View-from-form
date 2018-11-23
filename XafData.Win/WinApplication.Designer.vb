Imports Microsoft.VisualBasic
Imports System

Partial Public Class XafDataWindowsFormsApplication
	''' <summary> 
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing

	''' <summary> 
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing AndAlso (Not components Is Nothing) Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

#Region "Component Designer generated code"

	''' <summary> 
	''' Required method for Designer support - do not modify 
	''' the contents of this method with the code editor.
	''' </summary>
	Private Sub InitializeComponent()
        Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
        Me.module2 = New DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule()
        Me.module3 = New XafData.[Module].XafDataModule()
        Me.module4 = New XafData.[Module].Win.XafDataWindowsFormsModule()
        Me.module5 = New DevExpress.ExpressApp.Validation.ValidationModule()
        Me.module6 = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
        Me.module7 = New DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule()
        Me.securityModule1 = New DevExpress.ExpressApp.Security.SecurityModule()
        Me.securitySimple1 = New DevExpress.ExpressApp.Security.SecuritySimple()
        Me.authenticationActiveDirectory1 = New DevExpress.ExpressApp.Security.AuthenticationActiveDirectory()
        Me.OleDbConnection1 = New System.Data.OleDb.OleDbConnection()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'module5
        '
        Me.module5.AllowValidationDetailsAccess = True
        '
        'securitySimple1
        '
        Me.securitySimple1.Authentication = Me.authenticationActiveDirectory1
        Me.securitySimple1.IsGrantedForNonExistentPermission = False
        Me.securitySimple1.UserType = GetType(DevExpress.Persistent.BaseImpl.SimpleUser)
        '
        'authenticationActiveDirectory1
        '
        Me.authenticationActiveDirectory1.CreateUserAutomatically = True
        Me.authenticationActiveDirectory1.LogonParametersType = Nothing
        '
        'XafDataWindowsFormsApplication
        '
        Me.ApplicationName = "XafData"
        Me.Connection = Me.OleDbConnection1
        Me.Modules.Add(Me.module1)
        Me.Modules.Add(Me.module2)
        Me.Modules.Add(Me.module6)
        Me.Modules.Add(Me.module3)
        Me.Modules.Add(Me.module4)
        Me.Modules.Add(Me.module5)
        Me.Modules.Add(Me.module7)
        Me.Modules.Add(Me.securityModule1)
        Me.Security = Me.securitySimple1
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

	Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
    Private module2 As DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule
	Private module3 As Global.XafData.Module.XafDataModule
	Private module4 As Global.XafData.Module.Win.XafDataWindowsFormsModule
	Private module5 As DevExpress.ExpressApp.Validation.ValidationModule
    Private module6 As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
    Private module7 As DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule
    Private securityModule1 As DevExpress.ExpressApp.Security.SecurityModule

	Private securitySimple1 As DevExpress.ExpressApp.Security.SecuritySimple
    Private authenticationActiveDirectory1 As DevExpress.ExpressApp.Security.AuthenticationActiveDirectory
    Friend WithEvents OleDbConnection1 As System.Data.OleDb.OleDbConnection
End Class
