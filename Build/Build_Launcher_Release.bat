@ECHO OFF
REM http://stackoverflow.com/questions/5669765/build-visual-studio-project-through-the-command-line

SET msBuildDir=%WINDIR%\Microsoft.NET\Framework\v4.0.30319
SET msBuild=%msBuildDir%\MSBuild.exe

SET launcherDir=.\..\Development\Launcher
SET solution=%launcherDir%\XYWE.sln

SET configuration=Release
SET log=build_launcher.log

CALL %msBuild% %solution% /p:Configuration=%configuration% /l:FileLogger,Microsoft.Build.Engine;logfile=%log%

PAUSE