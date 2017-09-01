cd %WINDIR%/Microsoft.net/Framework64/v4.0.30319
csc /r:System.dll /r:System.Net.dll /r:Microsoft.VisualBasic.dll /r:System.Windows.Forms.dll /t:exe %userprofile%\Desktop\source\fs_AssemblyInfo.cs %userprofile%\Desktop\source\FileServe.cs
pause