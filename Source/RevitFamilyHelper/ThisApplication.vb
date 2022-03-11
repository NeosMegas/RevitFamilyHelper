'
' Created by SharpDevelop.
' User: Neo
' Date: 11.03.2022
' Time: 14:41
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System
Imports Autodesk.Revit.UI
Imports Autodesk.Revit.DB
Imports Autodesk.Revit.UI.Selection
Imports System.Collections.Generic
Imports System.Linq
imports Microsoft.VisualBasic

<Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)> _
<Autodesk.Revit.DB.Macros.AddInId("3680AE23-D7FA-4B76-B314-E51447E4584C")> _
Partial Public Class ThisApplication

    Private Sub Module_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
	
    End Sub
	
    Private Sub Module_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown
	
    End Sub
    
Public Sub RemoveAllTypes()
Dim Transaction As Autodesk.Revit.DB.Transaction = New Autodesk.Revit.DB.Transaction(ActiveUIDocument.Document, "RemoveAllTypes")
Transaction.Start()
Dim fm As FamilyManager=ActiveUIDocument.Document.FamilyManager
Dim i As Integer = 0, j As Integer = 0, k As Integer = 0
Dim	fTypeI As FamilyTypeSetIterator=fm.Types.ForwardIterator
Dim existingTypes As New List(Of FamilyType)
Dim t1 As Date = Now, t2 As Date, dt As TimeSpan
fTypeI.Reset
Dim fType As FamilyType
While fTypeI.MoveNext
	fType = TryCast(fTypeI.Current,FamilyType)
	If fType.Name<>"default" Then
		existingTypes.Add(fType)
	End If
End While
For Each t As FamilyType In existingTypes
	If fm.Types.Size = 1 Then Exit For	
	fm.CurrentType=t
	fm.DeleteCurrentType
	k+=1
Next
fTypeI = fm.Types.ForwardIterator
fTypeI.Reset
fTypeI.MoveNext
fType = TryCast(fTypeI.Current,FamilyType)
fm.CurrentType=fType
Transaction.Commit
t2=Now()
dt=New TimeSpan(t2.ticks - t1.ticks)
TaskDialog.Show("Title", k & " types deleted." & vbCrLf & dt.Seconds.ToString & " seconds.")
End Sub 	

End Class
