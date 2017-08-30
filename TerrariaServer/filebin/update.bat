call serverparams.cmd
call check_tshock.cmd

randomport -default -defaut -default
timeout /t 10
IF %tshock%==0 (
call "%USERPROFILE%\Desktop\TerrariaServer\createserver.bat"
) ELSE (
call "%USERPROFILE%\Desktop\TerrariaServer\createserver_tshock.bat"
)