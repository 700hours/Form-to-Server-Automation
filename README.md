# Form-to-Server-Automation
A Terraria website form-to-server setup

# Important (main subject)
I recommend reading the two troubleshoot.txt in the directories to familiarize yourself with the files

To get started, download both the Terraria dedicated server programs for TShock and Vanilla:
https://github.com/Pryaxis/TShock/releases ; 
http://terraria.org/ (the Dedicated Server link is at the very bottom)

It is necessary to rename the dedicated server .exe file from the Terraria site to... "VanillaTerrariaServer", and keep the TShock server .exe as "TerrariaServer" -- in this way, the server programs will be distinguished correctly

And last but not least, until (if) I get the directories registered using a .reg file, you'll need to keep the "TerrariaServer" directory on your desktop -- you'll notice it won't work otherwise

# HTML Template Addition
I've included some skeleton HTML files that I made based on the originals from my website. If you host this on a webhost, and direct the necessary arguments in the "filestream_start.bat" to your website url, "FileStream.exe" will download the files submitted through the form every so many seconds, and once it recognizes a new batch of files, it will start the server creation process etc. etc.
