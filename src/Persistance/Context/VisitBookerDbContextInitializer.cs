using Domain.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistance.Context
{
    public class VisitBookerDbContextInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly VisitBookerDbContext _dbContext;
        private readonly IConfiguration _configuration;


        public VisitBookerDbContextInitializer(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            VisitBookerDbContext dbContext,
             IConfiguration configuration)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public void Seed()
        {
            if (_dbContext.Database.GetPendingMigrations().Any())
                _dbContext.Database.Migrate();

            if (!_dbContext.Roles.Any())
            {
                var defaultAdminRole = new IdentityRole(ApplicationRoles.DefaultAdmin);
                var owner = new IdentityRole(ApplicationRoles.Owner);
                var customer = new IdentityRole(ApplicationRoles.Customer);

                _roleManager.CreateAsync(defaultAdminRole).Wait();
                _roleManager.CreateAsync(owner).Wait();
                _roleManager.CreateAsync(customer).Wait();
            }

            if (!_dbContext.Users.Any())
            {
                var user = new ApplicationUser
                {
                    UserName = _configuration["AuthorizationInit:DefaultEmail"],
                    Email = _configuration["AuthorizationInit:DefaultEmail"],
                    SecurityStamp = Guid.NewGuid().ToString()
                };
               
                _userManager.CreateAsync(user, _configuration["AuthorizationInit:DefaultPass"]).Wait();

                var role = _roleManager.FindByNameAsync(ApplicationRoles.DefaultAdmin);
                _userManager.AddToRoleAsync(user, role.Result.Name).Wait();
            }
        }
    }
}
