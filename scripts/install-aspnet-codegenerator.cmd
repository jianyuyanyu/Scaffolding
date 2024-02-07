set VERSION=8.0.1
set DEFAULT_NUPKG_PATH=C:\Nuget
set SRC_DIR=%cd%
set NUPKG=artifacts/packages/Debug/Shipping/
call taskkill /f /im dotnet.exe
call rd /Q /S artifacts
call build
call dotnet tool uninstall -g dotnet-aspnet-codegenerator

call cd %DEFAULT_NUPKG_PATH%
call C:
call rd /Q /S microsoft.visualstudio.web.codegeneration
call rd /Q /S microsoft.dotnet.scaffolding.shared
call rd /Q /S microsoft.visualstudio.web.codegeneration.core
call rd /Q /S microsoft.visualstudio.web.codegeneration.design
call rd /Q /S microsoft.visualstudio.web.codegeneration.entityframeworkcore
call rd /Q /S microsoft.visualstudio.web.codegeneration.templating
call rd /Q /S microsoft.visualstudio.web.codegeneration.utils
call rd /Q /S microsoft.visualstudio.web.codegenerators.mvc
call D:
call cd  %SRC_DIR%/%NUPKG%
call dotnet tool install -g dotnet-aspnet-codegenerator --add-source %SRC_DIR%\%NUPKG% --version %VERSION%
call cd %SRC_DIR%
call taskkill /f /im dotnet.exe
