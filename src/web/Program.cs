using Azure.Identity;
using Microsoft.Extensions.Azure;

namespace Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        // builder.Services.AddAzureClients(builder=> {
        //     builder.AddBlobServiceClient(new Uri("https://edc24radixworkshop.blob.core.windows.net"));

        //     // Use DefaultAzureCredential when debugging locally, otherwise WorkloadIdentityCredential
        //     builder.UseCredential((provider) => provider.GetService<IWebHostEnvironment>()!.IsDevelopment() ? new DefaultAzureCredential() : new WorkloadIdentityCredential());
        // });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();
        
        app.MapControllers();

        app.Run();
    }
}
