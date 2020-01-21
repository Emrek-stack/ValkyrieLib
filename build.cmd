rd /s /q ./build
dotnet pack src/Valkyrie.Core/Valkyrie.Core.csproj -o build -c Release --version-suffix 1.0.4
dotnet pack src/Valkyrie.Core.Data/Valkyrie.Data.Ef.csproj -o build -c Release --version-suffix 1.0.4
dotnet pack src/Valkyrie.Data.Mongo/Valkyrie.Data.Mongo.csproj -o build -c Release --version-suffix 1.0.4
dotnet pack src/Valkyrie.EventBus/Valkyrie.EventBus.csproj -o build -c Release --version-suffix 1.0.4
dotnet pack src/Valkyrie.Logging/Valkyrie.Logging.csproj -o build -c Release --version-suffix 1.0.4

