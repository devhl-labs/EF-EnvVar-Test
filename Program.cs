using EF_EnvVar_Test;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        // this is in appsettings
        string connection = context.Configuration.GetConnectionString("Foo");

        // this is in environment variable
        string connection2 = context.Configuration.GetConnectionString("Fizz");


        services.AddDbContext<FooDbContext>(o =>
        {
            // when running db-update.ps1, correctly produces an error for the wrong connection string format
            // System.ArgumentException: Format of the initialization string does not conform to specification starting at index 0.
            o.UseNpgsql(connection);

            // when running db-update.ps1, incorrectly produces an error for the connection string being null
            // System.ArgumentNullException: Value cannot be null. (Parameter 'connectionString')
            // when running in VS, the value is populated
            o.UseNpgsql(connection2);
        });
    })
    .Build();

await host.RunAsync();
