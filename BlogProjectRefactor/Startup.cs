using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlogProject.Database;
using BlogProject.Web.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BlogProject.Services.Configuration;
using BlogProject.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Azure;

namespace BlogProject.Web;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<JwtConfiguration>(options => _configuration.GetSection("Jwt").Bind(options));
        services.Configure<AzureStorageConfiguration>(options => _configuration.GetSection("AzureStorage").Bind(options));

        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString.ToString()));

        services.AddAutomapper();
        services.AddServices();

        services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>() // it's for db using ef core
                .AddDefaultTokenProviders();  // it's for jwt token

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddAzureClients(options =>
        {
            options.AddBlobServiceClient(_configuration["AzureStorage:ConnectionString"]);
        });

        // Adding Authentication
        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = false;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                };

                //ValidateIssuerSigningKey =  If IssuerSigningKeyValidator is set, it will be called                                      regardless of whether this property is true or false. The  default is false.
            });

        services.AddControllersWithViews();
        services.AddRazorPages();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        // user auth must be after UserRouting and before UseEndpoints
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
