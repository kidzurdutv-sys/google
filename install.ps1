$ErrorActionPreference = "Stop"

# Detect Revit Versions
$appData = [Environment]::GetFolderPath("ApplicationData")
$revitAddinsBase = Join-Path $appData "Autodesk\Revit\Addins"

$supportedVersions = @("2024", "2025")
$installedVersions = @()

foreach ($version in $supportedVersions) {
    $versionPath = Join-Path $revitAddinsBase $version
    if (Test-Path $versionPath) {
        $installedVersions += $version
    }
}

if ($installedVersions.Count -eq 0) {
    Write-Host "No supported Revit versions (2024 or 2025) found on this system. Installing for both by default." -ForegroundColor Yellow
    $installedVersions = $supportedVersions
}

$scriptDir = $PSScriptRoot
if ([string]::IsNullOrEmpty($scriptDir)) {
    $scriptDir = Get-Location
}
$slnPath = Join-Path $scriptDir "AllInOneMEP\AllInOneMEP.sln"

# Compile the solution to get the DLLs
Write-Host "Compiling AllInOneMEP Solution..." -ForegroundColor Cyan
dotnet build $slnPath -c Release

if ($LASTEXITCODE -ne 0) {
    Write-Host "Build failed. Aborting installation." -ForegroundColor Red
    return
}

foreach ($version in $installedVersions) {
    Write-Host "Installing for Revit $version..." -ForegroundColor Cyan

    $targetAddinDir = Join-Path $revitAddinsBase $version
    if (!(Test-Path $targetAddinDir)) {
        New-Item -ItemType Directory -Path $targetAddinDir -Force | Out-Null
    }

    $appFolder = Join-Path $targetAddinDir "AllInOneMEP"
    if (!(Test-Path $appFolder)) {
        New-Item -ItemType Directory -Path $appFolder -Force | Out-Null
    }

    # Determine which target framework to use based on version
    $tfm = if ($version -eq "2024") { "net48" } else { "net8.0-windows" }

    $sourceDir = Join-Path $scriptDir "AllInOneMEP\src\AllInOneMEP.Revit\bin\Release\$tfm"

    if (!(Test-Path $sourceDir)) {
        Write-Host "Source directory not found: $sourceDir. Did the build fail?" -ForegroundColor Red
        continue
    }

    # Copy DLLs
    Copy-Item -Path "$sourceDir\*" -Destination $appFolder -Recurse -Force

    # Generate or copy .addin file
    $addinPath = Join-Path $targetAddinDir "AllInOneMEP.addin"
    $dllPath = Join-Path $appFolder "AllInOneMEP.Revit.dll"

    $addinContent = @"
<?xml version="1.0" encoding="utf-8"?>
<RevitAddIns>
  <AddIn Type="Application">
    <Name>All-in-One MEP Automation Suite</Name>
    <Assembly>$dllPath</Assembly>
    <AddInId>12345678-1234-1234-1234-123456789012</AddInId>
    <FullClassName>AllInOneMEP.Revit.Application.App</FullClassName>
    <VendorId>JULES</VendorId>
    <VendorDescription>Jules AI</VendorDescription>
  </AddIn>
</RevitAddIns>
"@

    Set-Content -Path $addinPath -Value $addinContent -Encoding UTF8
    Write-Host "Successfully installed AllInOneMEP for Revit $version." -ForegroundColor Green
}

Write-Host "Installation Complete!" -ForegroundColor Green
