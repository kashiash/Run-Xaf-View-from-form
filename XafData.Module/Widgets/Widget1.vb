Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation


Namespace Widgets
    <DefaultClassOptions()> _
    Public Class Widget1
        Inherits BaseObject



        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
    End Class
End Namespace