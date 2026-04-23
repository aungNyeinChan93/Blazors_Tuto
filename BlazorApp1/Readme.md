# Blazors_Tuto

Minimal, ready-to-run Blazor sample project: `BlazorApp1`.

Goals
- Provide a simple Blazor starter you can run, extend, and deploy.
- Show where to add services, components, and pages.

Prerequisites
- .NET 10 SDK
- Visual Studio 2026 or the `dotnet` CLI

Quick start
1. Restore and build from workspace root:
   - `dotnet restore`
   - `dotnet build`
2. Run the app:
   - `dotnet run --project BlazorApp1`
3. Open the URL printed in the console (usually `https://localhost:5xxx`).

Open in Visual Studio
- Open the solution or folder and press F5 to debug (use launch profile IIS Express or Project).

Project layout (important paths)
- `BlazorApp1/Pages` — page components and routes
- `BlazorApp1/Components` — reusable UI components
- `BlazorApp1/Shared` — layouts, nav, and shared pieces
- `BlazorApp1/wwwroot` — static assets (CSS, images, JS)
- `BlazorApp1/Program.cs` — startup and DI registration

Services & common features
- Built-in helpers: `HttpClient`, `NavigationManager`, `IJSRuntime`, `IStringLocalizer`, `IOptions<T>`.
- Common features to add: authentication, state management, forms/validation, API clients, SignalR, PWA (WebAssembly).

Example: register services in `Program.cs`
```csharp
// inside Program.cs, before builder.Build()
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<MyAppState>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<IWeatherService, WeatherService>();
```

Development notes
- Add a page: create `Pages/YourPage.razor` with `@page "/your-route"`.
- Inject services in components: `@inject IWeatherService WeatherService` or `[Inject]` in code-behind.
- Hot reload: `dotnet watch run --project BlazorApp1` (if supported).

Build & publish
- Release build: `dotnet build -c Release`
- Publish: `dotnet publish -c Release -o ./publish --project BlazorApp1`
- Deploy according to hosting: Azure Static Web Apps, App Service, IIS, or static host for WebAssembly.

Troubleshooting
- HTTPS certificate: run `dotnet dev-certs https --trust` and restart the browser.
- Port conflict: change port in `Properties/launchSettings.json` or stop conflicting process.
- Restore issues: run `dotnet restore` and verify NuGet sources.

TODO (short-term)
- Add example `IWeatherService` + `WeatherService` and register it.
- Create sample components demonstrating `HttpClient`, `IJSRuntime`, and local storage.
- Add a minimal authentication example and a SignalR demo.
- Add CI workflow and a `LICENSE` file.

Author & contact
- `aungNyeinChan93` — GitHub: `https://github.com/aungNyeinChan93/Blazors_Tuto`

License
- No license included. Add one (e.g. MIT) if you plan to publish.

If you want, I can add the sample `IWeatherService` and register it in `Program.cs` next.
