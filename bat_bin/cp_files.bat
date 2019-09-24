 
set "__BAT_FILE=%~0"
set "__NAME=%~n0"

set "REMOTE_HOST=\\TP-ROGAP-VT01"
set "PROJECT_NAME=Framework452template"

set  BOT_FOLDER=D:\Publish\%PROJECT_NAME%
set  Bot_WebConfig_Path=D:\Publish\%PROJECT_NAME%\Web.config

set  Release_ProjectPath=%REMOTE_HOST%\WebSite\%PROJECT_NAME%
set  Release_WebConfig_Path=%REMOTE_HOST%\WebSite\%PROJECT_NAME%\Web.config
set  Release_Packages_Path=%REMOTE_HOST%\WebSite\%PROJECT_NAME%\packages.config

net use %REMOTE_HOST%
if exist %Release_Packages_Path% (
    fc /b Microsoft.PowerShell.Core\FileSystem::%Release_WebConfig_Path% %Bot_WebConfig_Path% > null
    if errorlevel 1 (
        robocopy %BOT_FOLDER%_Publish\ %Release_ProjectPath% /IS /S
    ) else (
        robocopy %BOT_FOLDER%_Publish\ %Release_ProjectPath% /IS /S /XD Web.config
    )
) else (
    robocopy %BOT_FOLDER%_Publish\ %Release_ProjectPath% /IS /S
)
(robocopy src dst) ^& IF %ERRORLEVEL% LSS 8 SET ERRORLEVEL = 0
