Imports DevExpress.ExpressApp
Imports XafData.Module
Imports System.IO
Imports DevExpress.ExpressApp.Win
Imports System.ComponentModel

Public Class Form1

    Private app As XafData.Win.XafDataWindowsFormsApplication
    Private Sub sBtnShowView1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowView1.Click

        Dim oSpace As ObjectSpace = app.CreateObjectSpace
        Dim svp As New ShowViewParameters

        svp.CreatedView = app.CreateListView(oSpace, GetType(Widgets.Widget1), True)
        svp.TargetWindow = TargetWindow.NewWindow
        '******************************
        'If I use NewModalWindow my application stays open after I close the window
        'If I use NewWindow my application closes when I close the window
        '******************************

        app.ShowViewStrategy.ShowView(svp, New ShowViewSource(app.CreateFrame(TemplateContext.ApplicationWindow), Nothing))

    End Sub

    Private Sub sBtnShowView2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sBtnShowView2.Click

        Dim oSpace As IObjectSpace = app.CreateObjectSpace
        Dim svp As New ShowViewParameters

        svp.CreatedView = app.CreateListView(oSpace, GetType(Widgets.Widget1), True)
        svp.TargetWindow = TargetWindow.NewModalWindow
        '******************************
        'If I use NewModalWindow my application stays open after I close the window
        'If I use NewWindow my application closes when I close the window
        '******************************

        app.ShowViewStrategy.ShowView(svp, New ShowViewSource(app.CreateFrame(TemplateContext.ApplicationWindow), Nothing))

    End Sub


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dbName As String = Path.Combine(Path.GetTempPath, "ShowXafWindowFromForm.accdb")
        app = New XafData.Win.XafDataWindowsFormsApplication
        app.ConnectionString = DevExpress.Xpo.DB.AccessConnectionProvider.GetConnectionStringACE(dbName, Nothing)
        app.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways
        app.ShowViewStrategy = New MyShowViewStrategy(app)
        app.Setup()
        If app.SplashScreen.IsStarted Then
            app.SplashScreen.Stop()
        End If
    End Sub
End Class

Public Class MyShowViewStrategy
    Inherits ShowInMultipleWindowsStrategy
    Public Sub New(ByVal app As XafApplication)
        MyBase.New(app)
    End Sub

    Protected Overrides Sub ShowWindow(ByVal window As WinWindow)
        If (Not Me.Windows.Contains(window)) Then
            AddHandler window.Closed, AddressOf window_Closed
            AddHandler window.Closing, AddressOf window_Closing
            'Me.windows.Add(window)
            Dim fi As Reflection.FieldInfo = Me.GetType().GetField("windows", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
            DirectCast(fi.GetValue(Me), List(Of WinWindow)).Add(window)
            If Me.IsExplorer(window) Then
                Me.Explorers.Add(window)
            Else
                Me.Inspectors.Add(window)
            End If
            Me.BeforeShowWindow(window)
            window.Show()
        Else
            Me.ActivateForm(window.Form)
        End If
    End Sub
    Private Sub window_Closing(ByVal sender As Object, ByVal e As CancelEventArgs)
        If (Not e.Cancel) Then
            Me.OnWindowClosing(CType(sender, WinWindow), e)
        End If
    End Sub
    Private Sub window_Closed(ByVal sender As Object, ByVal e As EventArgs)
        Dim window As WinWindow = CType(sender, WinWindow)
        RemoveHandler window.Closed, AddressOf window_Closed
        Me.OnWindowClosed(window)
    End Sub
End Class
