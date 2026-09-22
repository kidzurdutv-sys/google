@echo off
echo Starting AllInOneMEP Uninstallation...
powershell -NoProfile -ExecutionPolicy Bypass -File "%~dp0uninstall.ps1"
pause
