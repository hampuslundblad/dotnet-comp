# How tf do i start this.


### Bulding
```bash
dotnet build
```


### Notes

Initial db setup
```bash
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update
```


### Docker

### VS Code settings

If there's any issues with the C# dev kit languager server then add this in `.vscode/settings.json`

```bash
{
  "dotnet.dotnetPath": "pathtodotnet"
}

```