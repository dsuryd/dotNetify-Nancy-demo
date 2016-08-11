##Steps to create this solution structure:

###1. Create the class library project.

- Install package using Nuget:
```
Install-Package Microsoft.Owin.Hosting
Install-Package Nancy.Owin
Install-Package DotNetify
```

- Enable TypeScript by adding the following to .csproj:
```
<Import Project="$(MSBuildExtensionsPath32)\Microsoft\VisualStudio\v$(VisualStudioVersion)\TypeScript\Microsoft.TypeScript.targets" /> 
```
*Note: TypeScript files are only built on save - as a workaround, include the transpiled JS files in the solution.*

- Set the output path to a common folder for all projects:
   - Debug build: ..\bin\debug
   - Release build: ..\bin\release

- In post-build event, copy all static content files to the output path:
```
xcopy /E /Y "$(ProjectDir)Views" "$(ProjectDir)$(OutDir)Views\*"
xcopy /E /Y "$(ProjectDir)Content" "$(ProjectDir)$(OutDir)Content\*"
xcopy /E /Y "$(ProjectDir)Scripts" "$(ProjectDir)$(OutDir)Scripts\*"
```

###2. Create the self-hosted console app project.

- Install package using Nuget:
```
Install-Package Microsoft.Owin.Host.HttpListener
```

- Set the output path to a common folder for all projects:
   - Debug build: ..\bin\debug
   - Release build: ..\bin\release

- Include reference to the class library.

###3. Create the windows service project.

- Install package using Nuget:
```
Install-Package Microsoft.Owin.Host.HttpListener
```

- Set the output path to a common folder for all projects:
   - Debug build: ..\bin\debug
   - Release build: ..\bin\release

- Include reference to the class library.

- On the service design, add ProjectInstaller.

- On ProjectInstaller design, serviceInstaller properties, set the service name and description.

- On ProjectInstaller design, serviceProcessInstaller properties, set account to **LocalSystem**.

- Register the service with InstallUtil.exe.


