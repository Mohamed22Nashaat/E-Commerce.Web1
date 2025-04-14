namespace Persistence
{
    public class DbInitializer(StoreDbContext context) : IDbInitializer
    {
        public async Task InitializeAsync()
        {
            try
            {
                // Production => Create Db + Seeding
                // Dev => Seeding
                //if((await context.Database.GetPendingMigrationsAsync()).Any())
                //{
                //    context.Database.MigrateAsync();
                //}

                if (!context.Set<ProductBrand>().Any())
                {
                    //Read from JSON file
                    var data = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\Seeding\brands.json");
                    //Convert to C# objects [Deserialize] 
                    var objects = JsonSerializer.Deserialize<List<ProductBrand>>(data);
                    // Save to db
                    if (objects is not null && objects.Any())
                    {
                        context.Set<ProductBrand>().AddRange(objects);
                        await context.SaveChangesAsync();
                    }
                }

                if (!context.Set<ProductType>().Any())
                {
                    //Read from JSON file
                    var data = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\Seeding\types.json");
                    //Convert to C# objects [Deserialize] 
                    var objects = JsonSerializer.Deserialize<List<ProductType>>(data);
                    // Save to db
                    if (objects is not null && objects.Any())
                    {
                        context.Set<ProductType>().AddRange(objects);
                        await context.SaveChangesAsync();
                    }
                }

                if (!context.Set<Product>().Any())
                {
                    //Read from JSON file
                    var data = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\Seeding\products.json");
                    //Convert to C# objects [Deserialize] 
                    var objects = JsonSerializer.Deserialize<List<Product>>(data);
                    // Save to db
                    if (objects is not null && objects.Any())
                    {
                        context.Set<Product>().AddRange(objects);
                        await context.SaveChangesAsync();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }




        }
    }
}
// E:\Route\Backend\Assginments\API\E - Commerce.Web1\Infrastructure\Persistence\Data\Seeding\brands.json