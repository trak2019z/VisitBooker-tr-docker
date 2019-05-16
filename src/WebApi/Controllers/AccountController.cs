using Application.Account.Models;
using Domain.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, SignedUpAt = DateTime.UtcNow };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var role = await _roleManager.FindByNameAsync(ApplicationRoles.StandardUser);
                    await _userManager.AddToRoleAsync(user, role.Name);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Ok();
                }

                return BadRequest(this.GetFirstIdentityError(result.Errors));
            }

            return BadRequest(this.GetFirstModelStateError());

        }

        private string GetFirstModelStateError(string errorActionDescription = "create account")
        {
            foreach (var modelState in ModelState.Values)
            {
                if (modelState.Errors.Any())
                {
                    return modelState.Errors.First().ErrorMessage;
                }
            }
            return $"Unable to {errorActionDescription}. Please contact with system administrator.";
        }


        private string GetFirstIdentityError(IEnumerable<IdentityError> errors, string errorActionDescription = "create account")
        {
            if (errors.Any())
            {
                return errors.First().Description;
            }
            return $"Unable to {errorActionDescription}. Please contact with system administrator.";
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("changePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(this.GetFirstModelStateError("change password"));

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with '{model.Email}'.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                AddErrors(changePasswordResult);
                return BadRequest(this.GetFirstIdentityError(changePasswordResult.Errors, "change password"));
            }

            await _signInManager.SignInAsync(user, isPersistent: false);
            return Ok();
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
