# All-in-One Revit MEP Automation Suite

This repository contains a Clean Architecture & MVVM-based solution for automating Mechanical, Electrical, and Documentation processes in Autodesk Revit (built specifically for Revit 2019).

## Prerequisites
- **Revit Version**: Autodesk Revit 2019.
- **SDK/Runtime**: .NET Framework 4.7.2 (Included with Windows 10/11) and the .NET SDK (to build the project).

## Installation

We provide two easy ways to install the Add-in on your system:

### Option 1: Quick Install (Batch File)
1. Double-click the `install.bat` file located in the root directory.
2. The script will automatically invoke the PowerShell script, compile the code, and place it in your local `%APPDATA%\Autodesk\Revit\Addins\2019` directory.
3. Wait for the success message to appear, then press any key to close the window.
4. Restart Revit.

### Option 2: PowerShell Install
1. Open PowerShell as Administrator (optional but recommended to bypass local execution policies).
2. Navigate to this directory.
3. Run the installation script:
   ```powershell
   .\install.ps1
   ```
4. The script will target Revit 2019, compile the C# code (`dotnet build -c Release`), and copy the DLLs and `.addin` manifest file to your Revit Addins folder.
5. Restart Revit.

## Uninstallation
To remove the add-in completely:
- Double-click the `uninstall.bat` file, **OR**
- Run `.\uninstall.ps1` from PowerShell.

## Troubleshooting
- **"Execution of scripts is disabled on this system"**: If you receive this error when running the PowerShell scripts, Windows execution policy is blocking it. Run `install.bat` instead, which attempts to bypass this via `-ExecutionPolicy Bypass`, or manually open an Admin PowerShell and run: `Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass`.
- **"dotnet : The term 'dotnet' is not recognized"**: You need to install the [.NET SDK](https://dotnet.microsoft.com/en-us/download). Make sure to restart your console after installing.
- **Add-in doesn't show up in Revit**: Ensure you restart Revit after installation. Verify that the files exist in `%APPDATA%\Autodesk\Revit\Addins\2019\AllInOneMEP` and that the `.addin` file is located at `%APPDATA%\Autodesk\Revit\Addins\2019\AllInOneMEP.addin`.
