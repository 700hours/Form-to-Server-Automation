cd %WINDIR%/Microsoft.net/Framework/v4.0.30319
csc /r:System.dll /r:mscorlib.dll /t:exe %userprofile%\Desktop\source\rnd_AssemblyInfo.cs %userprofile%\Desktop\source\RandomPort.cs
pause