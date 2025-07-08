# Powershell.ShowBrowseDialog
Powershell.ShowBrowseDialog -  Show a Windows folder picker dialog from PowerShell using your custom C# DLL. 
This DLL resolves the issue where the ShowDialog window opens behind other screens.

![Example](https://github.com/DKreutz0/Powershell.ShowBrowseDialog/blob/main/Powershell.ShowBrowseDialog.png)


| File / Folder                                            | Description                                                                |
|----------------------------------------------------------|----------------------------------------------------------------------------|
| [.github/](.github/)                                     | GitHub workflows and configuration (e.g. Actions)                          |
| [.vscode/](.vscode/)                                     | Visual Studio Code workspace settings                                      |
| [bin/](bin/)                                             | Output folder for compiled DLLs and binaries                               |
| [obj/](obj/)                                             | Build intermediate files (auto-generated, can be ignored)                  |
| [Properties/](Properties/)                               | .NET project properties (AssemblyInfo, etc.)                               |
| [Powershell.ShowBrowseDialog.csproj](Powershell.ShowBrowseDialog.csproj) | .NET project file                                              |
| [Powershell.ShowBrowseDialog.sln](Powershell.ShowBrowseDialog.sln)         | Visual Studio solution file                                 |
| [README.md](README.md)                                   | Project documentation (this file)                                          |
| [ShowBrowseDialog.cs](ShowBrowseDialog.cs)               | Main source file: `DialogHelper` for Windows FolderBrowserDialog           |
| [LICENSE](LICENSE)                                       | License file                                                               |
| [.gitignore](.gitignore)                                 | Git ignore file           

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
