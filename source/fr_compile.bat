cd %WINDIR%/Microsoft.net/Framework/v4.0.30319
csc /r:System.dll /t:exe %userprofile%\Desktop\source\fr_AssemblyInfo.cs %userprofile%\Desktop\source\FileRead.cs
pause