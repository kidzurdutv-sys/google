$ErrorActionPreference = "Stop"

$appData = [Environment]::GetFolderPath("ApplicationData")
$revitAddinsBase = Join-Path $appData "Autodesk\Revit\Addins"

$supportedVersions = @("2019")

foreach ($version in $supportedVersions) {
    Write-Host "Uninstalling from Revit $version..." -ForegroundColor Cyan
    $targetAddinDir = Join-Path $revitAddinsBase $version

    $appFolder = Join-Path $targetAddinDir "AllInOneMEP"
    $addinPath = Join-Path $targetAddinDir "AllInOneMEP.addin"

    if (Test-Path $appFolder) {
        Remove-Item -Path $appFolder -Recurse -Force
        Write-Host "Removed application folder: $appFolder"
    }

    if (Test-Path $addinPath) {
        Remove-Item -Path $addinPath -Force
        Write-Host "Removed addin manifest: $addinPath"
    }
}

Write-Host "Uninstallation Complete!" -ForegroundColor Green
