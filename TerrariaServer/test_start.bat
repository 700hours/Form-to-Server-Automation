IF EXIST "C:\Users\Nolan\Documents\My Games\Terraria\Worlds\Dreamland.wld" (
"C:\Users\Nolan\desktop\TerrariaServer\VanillaTerrariaServer" -config "C:\Users\Nolan\desktop\TerrariaServer\test_config.txt"
) ELSE (
"C:\Users\Nolan\desktop\TerrariaServer\VanillaTerrariaServer" -port 8001 -players 8 -world "C:\Users\Nolan\Documents\My Games\Terraria\Worlds\Dreamland" -autocreate 1 -worldname Dreamland
)
