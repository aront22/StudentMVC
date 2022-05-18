using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentGrades.Areas.Identity.Data;
using StudentGrades.DAL.efDBContext;

[assembly: HostingStartup(typeof(StudentGrades.Areas.Identity.IdentityHostingStartup))]
namespace StudentGrades.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthDbContext>(options =>
                    options.UseInMemoryDatabase(
                        context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddAuthorization(options =>
                {
                    options.AddPolicy("RequireAdministratorRole",
                         policy => policy.RequireRole("Administrator"));
                });

                services.AddDefaultIdentity<StudentGradesUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<AuthDbContext>();

                services.Configure<IdentityOptions>(options =>
                {
                    // Password settings.
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 1;

                    // User settings.
                    options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    options.User.RequireUniqueEmail = false;
                });
            });
        }
    }
}