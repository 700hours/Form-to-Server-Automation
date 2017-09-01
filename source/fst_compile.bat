cd %WINDIR%/Microsoft.net/Framework/v4.0.30319
csc /r:System.dll /r:System.Net.dll /t:exe %userprofile%\Desktop\source\fst_AssemblyInfo.cs %userprofile%\Desktop\source\FileStream.cs
pause