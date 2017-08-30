# Form-to-Server-Automation
A Terraria website form-to-server setup

# TerrariaServer troubleshoot.txt
You can find the necessary Terraria server files for TShock and Vanilla Terraria at \
these sites:
https://github.com/Pryaxis/TShock/releases
http://terraria.org/ (the Dedicated Server link is at the very bottom)

Until I create a ".reg" file that registers the location of the directory, 
"TerrariaServer," keep "TerrariaServer" on your desktop or the internal directory 
calls will fail

To manually create a server based on the values in "chosenport.cmd" and 
"serverparams.cmd" located in "filebin," without editing the file, run 
"createserver.bat" or "createserver_tshock.bat;" these .bat will create the necessary
files for starting and restarting the server in the future

To run a specific server after it has been closed, simply run the "%name%_start.bat"
file

In order to change the values of a server, such as what world is used or the player
limit, simply edit them in the "%name%_config.txt" file (%name%_config_ts.txt for
TShock)

If the TShock server program isn't booted up by the automation, simply run the 
necessary "%name%_start_ts.bat"

# filebin troubleshoot.txt
In order to get the right "serverparams.cmd," make sure your website php form outputs
the values entered in the form to "serverparams.hmtl;" the programs read it and output
to the necessary ".cmd" file

Check the file, "check_tshock.cmd" to make sure it equals either 0 or 1; 
if neither, and a server creation request has been made but wasn't completed in a 
server startup, manually enter the desired # (either 0 or 1), then manually run 
"update.bat"

You can enter in the desired values in serverparams.cmd and serverid.cmd without
running "FileRead.exe" or "FileStream.exe," then run "update.bat," to start the server
creation process manually -- good for testing for incongruities

Make sure the arguments in both "fileread_start.bat" and "filestream_start.bat" are in
chronological order detailed in "fileapps_syntax.txt" or else the programs won't start

In order to keep the ports from exceeding the range of values (unlikely anyway),
keep a tab on "activeports.txt;" clear out the values of unused server ports every so
often
