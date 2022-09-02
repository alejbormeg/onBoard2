using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Net.Http.Headers;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using JsonProjectBE.DBRepo;

namespace JSonProjectBE.Tests
{
    public class WebApplicationFactory
    {
        [Fact]
        public async Task HelloWorldTest()
        {
            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.AddControllers().AddNewtonsoftJson();
                        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                       services.AddEndpointsApiExplorer();
                       services.AddSingleton<Mongo>();
                       services.AddScoped<IDBRepo, Mongo>();

                    });
                });

            var client = application.CreateClient();
            //...
        }
    }
}
