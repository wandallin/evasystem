
set "__BAT_FILE=%~0"
set "__NAME=%~n0"

set "PROJECT_NAME=Framework452template"

set  BOT_FOLDER=D:\Publish\%PROJECT_NAME%
set  DotNetSln_Path=.\%PROJECT_NAME%.sln

if exist %BOT_FOLDER% (
    rmdir -r %BOT_FOLDER%
    md -p %BOT_FOLDER%
) else (
    md -p %BOT_FOLDER%
)
powershell C:\nuget.exe restore %DotNetSln_Path%

powershell msbuild %DotNetSln_Path% /p:Configuration=Debug /p:VisualStudioVersion=14.0 /p:OutDir=%BOT_FOLDER%
