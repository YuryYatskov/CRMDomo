namespace WebServer.API.Data.Extensions;

public static class DatabaseExtentions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await SeedAsync(context);
    }

    private static async Task SeedAsync(ApplicationDbContext context)
    {
        bool isSave = false;

        IEnumerable<Counterparty>? counterparties = null;
        IEnumerable<Phone>? phones = null;

        if (!await context.Products.AnyAsync())
        {
            await context.Products.AddRangeAsync(InitialData.Products);
            isSave = true;
        }

        if (!await context.Counterparties.AnyAsync())
        {
            counterparties = InitialData.Counterparties;
            await context.Counterparties.AddRangeAsync(counterparties);
            isSave = true;
        }

        if (!await context.Phones.AnyAsync())
        {
            counterparties = counterparties?.Count() > 1 ? counterparties : InitialData.Counterparties;
            //context.Counterparties.AttachRange(counterparties);
            phones = InitialData.GetPreconfiguredPhones(counterparties);
            await context.Phones.AddRangeAsync(phones);
            isSave = true;
        }

        if (isSave)
            await context.SaveChangesAsync();

    }
}
