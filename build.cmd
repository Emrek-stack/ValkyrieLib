rd /s /q build
dotnet publish ../src/Valkyrie.Core/Valkyrie.Core.csproj -f netcoreapp2.0 -o ..\build -c Release
dotnet publish ../src/Valkyrie.Core/Valkyrie.Core.csproj -f netcoreapp2.1 -o ..\build -c Release
