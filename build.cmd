rd /s /q ./build
dotnet publish src/Valkyrie.Core/Valkyrie.Core.csproj -f netstandard2.0 -o build/Valkyrie.Core/netstandard2.0 -c Release
dotnet publish src/Valkyrie.Core/Valkyrie.Core.csproj -f netstandard2.1 -o build/Valkyrie.Core/netstandard2.1 -c Release
