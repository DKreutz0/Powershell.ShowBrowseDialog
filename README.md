# Powershell.ShowBrowseDialog
Powershell.ShowBrowseDialog -  Show a Windows folder picker dialog from PowerShell using your custom C# DLL. 
This DLL resolves the issue where the ShowDialog window opens behind other screens.

![Example](https://github.com/DKreutz0/Powershell.ShowBrowseDialog/blob/main/Powershell.ShowBrowseDialog.png)

Powershell.ShowBrowseDialog/
├── Powershell.ShowBrowseDialog Example
│   └── Powershell.ShowBrowseDialog.dll
│   └── Powershell.ShowBrowseDialog.ps1
├── Powershell.ShowBrowseDialog
│   └── Debug/
│       └── Powershell.ShowBrowseDialog.sln
│           └── Powershell.ShowBrowseDialog
│               └── ShowBrowseDialog.cs
│               └── Powershell.ShowBrowseDialog.csproj
├── Powershell.ShowBrowseDialog.png
└── README.md
You can pass ALL parameters!
------------------------------------------------------------------------------------------------------------------------------------------------------

-Description

-RootFolder (e.g., Desktop, MyDocuments, MyComputer, etc.)

-SelectedPath

-ShowNewFolderButton

-UseDescriptionForTitle


------------------------------------------------------------------------------------------------------------------------------------------------------
Usage:

[string]$DllPath = "$PSScriptRoot\Powershell.ShowBrowseDialog.dll" Just put the DLL in the scriptfolder or change the location for yourself.

Powershell 5x just run de script in powershell
powershell 7

cd "\Powershell.ShowBrowseDialog Example\" to the path where the script has been placed
.\Powershell.ShowBrowseDialog.ps1

------------------------------------------------------------------------------------------------------------------------------------------------------

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
