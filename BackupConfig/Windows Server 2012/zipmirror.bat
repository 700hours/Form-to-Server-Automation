call getdate.cmd

set year=%DATE:~10,4%
set day=%DATE:~7,2%
set mnt=%DATE:~4,2%
set hr=%TIME:~0,2%
set min=%TIME:~3,2%

IF %day% LSS 10 SET day=0%day:~1,1%
IF %mnt% LSS 10 SET mnt=0%mnt:~1,1%
IF %hr% LSS 10 SET hr=0%hr:~1,1%
IF %min% LSS 10 SET min=0%min:~1,1%

set backuptime=%year%-%day%-%mnt%-%hr%-%min%
echo %backuptime%

C:\7za a -tzip "%USERPROFILE%\Desktop\BackupConfig\tempWorldStorage\freeslots_%backuptime%.zip" "%USERPROFILE%\Documents\My Games\Terraria\Worlds\*.*" -mx5
robocopy %USERPROFILE%\Desktop\BackupConfig\tempWorldStorage\ C:\test *.zip*
forfiles /p %USERPROFILE%\Desktop\BackupConfig\tempWorldStorage\ /m *.zip*/s /d -7 /c "cmd /c del @FILE"