using CRMWeb.Components;
using CRMWeb.Services.Catalog;
using Refit;
using Syncfusion.Blazor;
using Syncfusion.Licensing;

namespace CRMWeb.Extensions;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        // Add services to the container.

        SyncfusionLicenseProvider.RegisterLicense(builder.Configuration["ApiSettings:SyncfusionLicenseKey"]!);

        builder.Services.AddRefitClient<ICatalogService>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(builder.Configuration["ApiSettings:CatalogAPIAddress"]!);
            });

        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();

        builder.Services.AddSyncfusionBlazor();

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode()
            .AddInteractiveWebAssemblyRenderMode()
            .AddAdditionalAssemblies(typeof(CRMWeb.Client._Imports).Assembly);

        InitializeApp(app);

        return app;
    }

    private static void InitializeApp(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope();
        SelectiveServices.CatalogService = serviceScope.ServiceProvider.GetRequiredService<ICatalogService>();
    }
}

internal static class SelectiveServices
{
    public static ICatalogService? CatalogService { get; set; }
}