##Steps to set up the solution structure:

###1. Create the class library.

- Install package using Nuget:
```
Install-Package Microsoft.Owin.Hosting
Install-Package Nancy.Owin
```

- Enable TypeScript by adding the following to .csproj:
```
<Import Project="$(MSBuildExtensionsPath32)\Microsoft\VisualStudio\v$(VisualStudioVersion)\TypeScript\Microsoft.TypeScript.targets" > 
```

- Set the output path to:
   - Debug build: ..\bin\debug
   - Release build: ..\bin\release

- On post-build event, copy the static content files to the output path:
```
xcopy /E /Y "$(ProjectDir)Views" "$(ProjectDir)$(OutDir)Views\*"
xcopy /E /Y "$(ProjectDir)Content" "$(ProjectDir)$(OutDir)Content\*"
xcopy /E /Y "$(ProjectDir)Scripts" "$(ProjectDir)$(OutDir)Scripts\*"
```

###2. Create the self-hosted console app.

- Install package using Nuget:
```
Install-Package Microsoft.Owin.Host.HttpListener
```

- Set output path to:
   - Debug build: ..\bin\debug
   - Release build: ..\bin\release

- Include reference to the class library.

###3. Create the windows service.

- Install package using Nuget:
```
Install-Package Microsoft.Owin.Host.HttpListener
```

- Set output path to:
   - Debug build: ..\bin\debug
   - Release build: ..\bin\release

- Include reference to the class library.

- From the service design, add ProjectInstaller.

- On ProjectInstaller design, serviceInstaller properties, set service name.

- On ProjectInstaller design, serviceProcessInstaller properties, set account to LocalSystem.

- Register the service with InstallUtil.exe.


