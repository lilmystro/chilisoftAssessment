using Microsoft.Extensions.DependencyInjection;
using UserMenu.Presentation;
using UserMenu.Utils;

public class Program
{
    public static void Main(string[] args)
    {
        var serviceProvider = ConfigureServices();

        var app = serviceProvider.GetRequiredService<IApp>();

        app.GenerateUserMenuPermissions(args);
    }

    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddTransient<IApp, App>();
        services.AddTransient<IModelBuilder, ModelBuilder>();
        services.AddTransient<IFileSystem, FileSystem>();
        services.AddTransient<IFileReader, FileReader>();

        return services.BuildServiceProvider();
    }
}