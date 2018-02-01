using CloudShellUI.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudShellUI.Models
{
    public class SeedData
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public SeedData (ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async void EnsureSeedData ()
        {
            if (!_context.ApplicationUser.Any())
            {
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.FistName = "Admin";
                applicationUser.LastName = "Admin";
                applicationUser.Email = "admin@example.com";
                applicationUser.EmailConfirmed = true;
                applicationUser.CreatedOn = DateTime.Now;
                applicationUser.isEnabled = false;
                applicationUser.NormalizedEmail = "ADMIN@EXAMPLE.COM";
                applicationUser.NormalizedUserName = applicationUser.NormalizedEmail;
                applicationUser.UserName = applicationUser.Email;
                applicationUser.CreatedBy = "SYSTEM";
                applicationUser.ModifiedBy = "SYSTEM";
                applicationUser.ModifiedOn = DateTime.Now;
                applicationUser.ChangePassword = false;

                var user = await _userManager.CreateAsync(applicationUser, "Admin@123");
            }
        }
    }
}
