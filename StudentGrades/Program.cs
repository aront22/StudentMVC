using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StudentGrades.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGrades
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            using (var serviceScope = host.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<DAL.efDBContext.StudentsDbContext>();
                context.Database.EnsureCreated();

                RoleManager<IdentityRole> roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                roleManager.CreateAsync(new IdentityRole(config["AdminRole"]));
                
                UserManager<StudentGradesUser> userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<StudentGradesUser>>();
                userManager.CreateAsync(new StudentGradesUser() { UserName = config["AdminCredentials:Username"], EmailConfirmed = true, }, config["AdminCredentials:Password"]);
                StudentGradesUser admin = userManager.FindByNameAsync(config["AdminCredentials:Username"]).GetAwaiter().GetResult();
                userManager.AddToRoleAsync(admin, config["AdminRole"]);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
