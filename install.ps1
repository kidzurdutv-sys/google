$ErrorActionPreference = "Stop"

# Detect if dotnet CLI is installed
try {
    $dotnetVersion = & dotnet --version 2>$null
    if ($LASTEXITCODE -ne 0) { throw "dotnet not found" }
} catch {
    Write-Host "============================================================" -ForegroundColor Red
    Write-Host "ERROR: The '.NET SDK' is not installed or not in your PATH." -ForegroundColor Red
    Write-Host "This add-in requires the .NET SDK to compile the source code." -ForegroundColor Red
    Write-Host "Please download and install it from:" -ForegroundColor Yellow
    Write-Host "https://dotnet.microsoft.com/en-us/download" -ForegroundColor Yellow
    Write-Host "After installing, please restart your command prompt / computer and try again." -ForegroundColor Yellow
    Write-Host "============================================================" -ForegroundColor Red
    return
}

# Detect Revit Versions
$appData = [Environment]::GetFolderPath("ApplicationData")
$revitAddinsBase = Join-Path $appData "Autodesk\Revit\Addins"

$supportedVersions = @("2019")
$installedVersions = @()

foreach ($version in $supportedVersions) {
    $versionPath = Join-Path $revitAddinsBase $version
    if (Test-Path $versionPath) {
        $installedVersions += $version
    }
}

if ($installedVersions.Count -eq 0) {
    Write-Host "No supported Revit versions (2019) found on this system. Installing for 2019 by default." -ForegroundColor Yellow
    $installedVersions = $supportedVersions
}

$scriptDir = $PSScriptRoot
if ([string]::IsNullOrEmpty($scriptDir)) {
    $scriptDir = Get-Location
}
$slnPath = Join-Path $scriptDir "AllInOneMEP"

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

    # We only have one target framework now
    $tfm = "net472"

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
