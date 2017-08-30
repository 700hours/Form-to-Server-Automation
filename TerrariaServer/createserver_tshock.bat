set rootpath=%USERPROFILE%\desktop\TerrariaServer

call "%rootpath%\setname.cmd"
call "%rootpath%\setvars.cmd"

>"%rootpath%\%name%_set_ts.cmd" ECHO set port=%port%
>>"%rootpath%\%name%_set_ts.cmd" ECHO set players=%var2%
>>"%rootpath%\%name%_set_ts.cmd" ECHO set autocreate=%var3%
>>"%rootpath%\%name%_set_ts.cmd" ECHO set worldname=%var4%
>>"%rootpath%\%name%_set_ts.cmd" ECHO set password=%var5%
>>"%rootpath%\%name%_set_ts.cmd" ECHO set motd=%var6%
>>"%rootpath%\%name%_set_ts.cmd" ECHO set lang=%var7%
>>"%rootpath%\%name%_set_ts.cmd" ECHO set priority=%var8%
>>"%rootpath%\%name%_set_ts.cmd" ECHO set name=%name%

call "%rootpath%\%name%_set_ts.cmd"

>"%rootpath%\%name%_config_ts.txt" ECHO maxplayers=%players%
>>"%rootpath%\%name%_config_ts.txt" ECHO worldsize=%worldsize%
>>"%rootpath%\%name%_config_ts.txt" ECHO world=%USERPROFILE%\Documents\My Games\Terraria\Worlds\%worldname%.wld
>>"%rootpath%\%name%_config_ts.txt" ECHO port=%port%
>>"%rootpath%\%name%_config_ts.txt" ECHO password=%password%
>>"%rootpath%\%name%_config_ts.txt" ECHO motd=%motd%
>>"%rootpath%\%name%_config_ts.txt" ECHO worldpath=%USERPROFILE%\Documents\My Games\Terraria\Worlds\
>>"%rootpath%\%name%_config_ts.txt" ECHO secure=1
>>"%rootpath%\%name%_config_ts.txt" ECHO lang=%lang%
>>"%rootpath%\%name%_config_ts.txt" ECHO upnp=1
>>"%rootpath%\%name%_config_ts.txt" ECHO priority=%priority%

>"%rootpath%\%name%_start_ts.bat" ECHO IF EXIST "%USERPROFILE%\Documents\My Games\Terraria\Worlds\%worldname%" (
>>"%rootpath%\%name%_start_ts.bat" ECHO "%rootpath%\TerrariaServer" -config "%rootpath%\%name%_config_ts.txt"
>>"%rootpath%\%name%_start_ts.bat" ECHO ) ELSE (
>>"%rootpath%\%name%_start_ts.bat" ECHO "%rootpath%\TerrariaServer" -config -port %port% -players %players% -world "%USERPROFILE%\Documents\My Games\Terraria\Worlds\%worldname%.wld" -autocreate %autocreate% -worldname %worldname%.wld
>>"%rootpath%\%name%_start_ts.bat" ECHO )

call "%rootpath%\%name%_start_ts.bat"