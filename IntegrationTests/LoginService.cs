using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class LoginService
    {
        [Fact]
        public async Task LogsInSampleUser()
        {
            var services = new ServiceCollection()
                                .AddEntityFrameworkInMemoryDatabase();

            services.AddDbContext<AlfonsoContext>(options =>
            {
                options.UseInMemoryDatabase("Identity");
            });

            var serviceProvider = new ServiceCollection()
                    .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;

                try
                {
                    //// seed sample user data
                    //var userManager = scopedServices.GetRequiredService<UserManager<ApplicationUser>>();

                    //AppIdentityDbContextSeed.SeedAsync(userManager).Wait();

                    //var signInManager = scopedServices.GetRequiredService<SignInManager<ApplicationUser>>();

                    //var email = "demouser@microsoft.com";
                    //var password = "Pass@word1";

                    //var result = await signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
                    //Assert.True(result.Succeeded);
                }
                catch (Exception)
                {
                    throw;
                }


            }
        }
    }
}
