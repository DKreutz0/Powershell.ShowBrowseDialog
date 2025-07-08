# Powershell.ShowBrowseDialog
Powershell.ShowBrowseDialog -  Show a Windows folder picker dialog from PowerShell using your custom C# DLL. 
This DLL resolves the issue where the ShowDialog window opens behind other screens.

<#
.SYNOPSIS
    Show a Windows folder picker dialog from PowerShell using your custom C# DLL.

.PARAMETER Description
    Optional dialog window description/title.

.PARAMETER RootFolder
    Start browsing from this special folder. Default: Desktop.
    Options: Desktop, MyComputer, MyDocuments, etc.

.PARAMETER SelectedPath
    The initial selected folder path. Must exist or will fall back.

.PARAMETER ShowNewFolderButton
    Show the "New Folder" button. Default: $true.

.PARAMETER UseDescriptionForTitle
    Use description as window title (Windows Vista/.NET 4.5+ only). Default: $false.

.EXAMPLE
    Show-BrowseDialog -Description "Pick a folder" -RootFolder MyComputer -SelectedPath "C:\Temp"

.NOTES
    Requires Powershell.ShowBrowseDialog.dll built from your C# code.
#>
