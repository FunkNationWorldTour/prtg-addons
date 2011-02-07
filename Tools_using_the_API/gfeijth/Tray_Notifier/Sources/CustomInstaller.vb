Imports System.IO
Imports System.ComponentModel
Imports System.Reflection
Imports System.Configuration.Install


'//GF Note: the custom actions for the installer need to point to the 'Primary output' from the assembly
'//GF Set 'RunInstaller' attribute to true, so this class wil be picked up by the installer

<RunInstaller(True)> _
Public Class CustomInstaller
    Inherits Installer

    '//GF application to be launched after successful installation
    Private StartExe As String = "TrayNotifier.exe"

    Public Sub New()
        MyBase.New()
        ' Attach the 'Committing' event.
        AddHandler Me.Committing, AddressOf MyInstaller_Committing
        ' Attach the 'Committed' event.
        AddHandler Me.Committed, AddressOf MyInstaller_Committed
    End Sub 'New

    ' Event handler for 'Committing' event.
    Private Sub MyInstaller_Committing(ByVal sender As Object, ByVal e As InstallEventArgs)
        'Console.WriteLine("")
        'Console.WriteLine("Committing Event occured.")
        'Console.WriteLine("")
    End Sub

    ' Event handler for 'Committed' event.
    Private Sub MyInstaller_Committed(ByVal sender As Object, ByVal e As InstallEventArgs)
        Try
            'If MessageBox.Show("Start application now?", "Succesfully installed", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
            Process.Start(String.Format("{0}\{1}", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), StartExe))
            'End If
        Catch
            'Do nothing...
        End Try
    End Sub

    ' Override the 'Install' method.
    Public Overrides Sub Install(ByVal savedState As IDictionary)
        MyBase.Install(savedState)
    End Sub 'Install

    ' Override the 'Commit' method.
    Public Overrides Sub Commit(ByVal savedState As IDictionary)
        MyBase.Commit(savedState)
    End Sub 'Commit

    ' Override the 'Rollback' method.
    Public Overrides Sub Rollback(ByVal savedState As IDictionary)
        MyBase.Rollback(savedState)
    End Sub 'Rollback
    Public Shared Sub Main()
        'Console.WriteLine("Usage : installutil.exe Installer.exe ")
    End Sub 'Main
End Class
