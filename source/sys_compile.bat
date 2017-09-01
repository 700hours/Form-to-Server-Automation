cd %WINDIR%/Microsoft.net/Framework/v4.0.30319
csc /r:System.dll /r:system.componentmodel.dataannotations.dll /r:system.core.dll /r:system.data.dll /r:system.data.datasetextensions.dll /t:exe %userprofile%\Desktop\source\sys_AssemblyInfo.cs %userprofile%\Desktop\source\SysResource.cs
pause