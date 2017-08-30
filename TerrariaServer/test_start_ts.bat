IF EXIST "%UserProfile%\Documents\My Games\Terraria\Worlds\Dreamland" (
"%USERPROFILE%\desktop\TerrariaServer\TerrariaServer" -config "%USERPROFILE%\desktop\TerrariaServer\test_config_ts.txt"
Pause
) ELSE (
"%USERPROFILE%\desktop\TerrariaServer\TerrariaServer" -config -port 8001 -players 8 -world "%USERPROFILE%\Documents\My Games\Terraria\Worlds\Dreamland" -autocreate 1 -worldname Dreamland
Pause
)