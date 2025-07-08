function Show-BrowseDialog {
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
    [CmdletBinding()]
    param (
        [string]$Description,
        [string]$RootFolder = "Desktop",
        [string]$SelectedPath,
        [bool]$ShowNewFolderButton = $true,
        [bool]$UseDescriptionForTitle = $false,
        [string]$DllPath = "$PSScriptRoot\Powershell.ShowBrowseDialog.dll"
    )

    # Ensure the DLL is loaded (idempotent)
    if (-not ("Powershell.ShowBrowseDialog.DialogHelper" -as [type])) {
        Add-Type -Path $DllPath
    }

    try {
        $folder = [Powershell.ShowBrowseDialog.DialogHelper]::ShowBrowseDialog(
            $Description,
            $RootFolder,
            $SelectedPath,
            $ShowNewFolderButton,
            $UseDescriptionForTitle
        )
        if ($folder) {
            Write-Output $folder
        }
    } catch {
        Write-Warning $_.Exception.Message
        return $null
    }
}
# Dot-source or import the function, then run:
$selected = Show-BrowseDialog -Description "Choose your project folder" -RootFolder Desktop -ShowNewFolderButton $true

if ($selected) {
    Write-Host "You selected: $selected" -ForegroundColor Green
} else {
    Write-Host "No folder selected." -ForegroundColor Yellow
}
