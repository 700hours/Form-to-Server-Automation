IF EXIST %USERPROFILE%\Desktop\TerrariaServer\filebin\serverparams.cmd (
call %USERPROFILE%\Desktop\TerrariaServer\filebin\serverparams.cmd
set name="%name%"
) ELSE (
set name=test
)