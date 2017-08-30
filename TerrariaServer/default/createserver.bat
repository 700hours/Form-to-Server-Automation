set rootpath=%USERPROFILE%\desktop\TerrariaServer

call "%rootpath%\setname.cmd"
call "%rootpath%\setvars.cmd"

>"%rootpath%\%name%_set.cmd" ECHO set port=%port%
>>"%rootpath%\%name%_set.cmd" ECHO set players=%var2%
>>"%rootpath%\%name%_set.cmd" ECHO set autocreate=%var3%
>>"%rootpath%\%name%_set.cmd" ECHO set worldname=%var4%
>>"%rootpath%\%name%_set.cmd" ECHO set password=%var5%
>>"%rootpath%\%name%_set.cmd" ECHO set motd=%var6%
>>"%rootpath%\%name%_set.cmd" ECHO set lang=%var7%
>>"%rootpath%\%name%_set.cmd" ECHO set priority=%var8%
>>"%rootpath%\%name%_set.cmd" ECHO set name=%name%

call "%rootpath%\%name%_set.cmd"

>"%rootpath%\%name%_config.txt" ECHO maxplayers=%players%
>>"%rootpath%\%name%_config.txt" ECHO worldsize=%worldsize%
>>"%rootpath%\%name%_config.txt" ECHO world=%USERPROFILE%\Documents\My Games\Terraria\Worlds\%worldname%.wld
>>"%rootpath%\%name%_config.txt" ECHO port=%port%
>>"%rootpath%\%name%_config.txt" ECHO password=%password%
>>"%rootpath%\%name%_config.txt" ECHO motd=%motd%
>>"%rootpath%\%name%_config.txt" ECHO worldpath=%USERPROFILE%\Documents\My Games\Terraria\Worlds\
>>"%rootpath%\%name%_config.txt" ECHO secure=1
>>"%rootpath%\%name%_config.txt" ECHO lang=%lang%
>>"%rootpath%\%name%_config.txt" ECHO upnp=1
>>"%rootpath%\%name%_config.txt" ECHO priority=%priority%


>"%rootpath%\%name%_start.bat" ECHO IF EXIST "%USERPROFILE%\Documents\My Games\Terraria\Worlds\%worldname%.wld" (
>>"%rootpath%\%name%_start.bat" ECHO "%rootpath%\VanillaTerrariaServer" -config "%rootpath%\%name%_config.txt"
>>"%rootpath%\%name%_start.bat" ECHO ) ELSE (
>>"%rootpath%\%name%_start.bat" ECHO "%rootpath%\VanillaTerrariaServer" -port %port% -players %players% -world "%USERPROFILE%\Documents\My Games\Terraria\Worlds\%worldname%" -autocreate %autocreate% -worldname %worldname%
>>"%rootpath%\%name%_start.bat" ECHO )

call "%rootpath%\%name%_start.bat"