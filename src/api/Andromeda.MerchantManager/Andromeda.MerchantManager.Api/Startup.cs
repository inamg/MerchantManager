using Andromeda.MerchantManager.Api.GraphQL;
using Andromeda.MerchantManager.Api.Infrastructure.Profiles;
using Andromeda.MerchantManager.Api.Services;
using Andromeda.MerchantManager.Data;
using Andromeda.MerchantManager.Data.Configurations;
using AutoMapper;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Andromeda.MerchantManager.Data.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Andromeda.MerchantManager.Api
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            
            services.AddControllers();
            services.AddScoped<IMerchantService, MerchantService>();
            services.AddScoped<IStorageService, FileStorageService>();

            services.Configure<MongoDbOptions>(Configuration.GetSection("MongoSettings"));
            services.AddDataServices();

            services.AddScoped<IDependencyResolver>(x =>
                new FuncDependencyResolver(x.GetRequiredService));

            services.AddScoped<MerchantQuery>();
            services.AddScoped<MerchantsSchema>();
            services.AddGraphQL(x => { x.ExposeExceptions = true; })
                .AddGraphTypes(ServiceLifetime.Scoped);
            services.AddGraphQLUpload();

            services.Configure<KestrelServerOptions>(options => { options.AllowSynchronousIO = true; });

            services.AddAutoMapper(c => { c.AddProfile<ModelEntityMappings>(); }, typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(MyAllowSpecificOrigins);
            
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()
            {
                Path = "/ui"
            });

            app.UseGraphQLUpload<MerchantsSchema>();
            app.UseGraphQL<MerchantsSchema>();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}