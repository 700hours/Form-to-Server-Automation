IF EXIST %USERPROFILE%\Desktop\TerrariaServer\filebin\serverparams.cmd (
call %USERPROFILE%\Desktop\TerrariaServer\filebin\chosenport.cmd

set var1=%port%

call %USERPROFILE%\Desktop\TerrariaServer\filebin\serverparams.cmd

set var2=%players%
set var3=1
set var4=%worldname%
set var5=%password%
set var6=%motd%
set var7=%language%
set var8=1
) ELSE (
set var1=8001
set var2=8
set var3=1
set var4=Dreamland
set var5=
set var6=Public 1.2.0.2 Server
set var7=1
set var8=1
)