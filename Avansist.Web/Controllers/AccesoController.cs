using Avansist.Models.Entities;
using Avansist.Web.Models.Email;
using Avansist.Web.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Avansist.Web.Controllers
{
    public class AccesoController : Controller
    {
        private readonly UserManager<UsuarioIdentity> _userManager;
        private readonly SignInManager<UsuarioIdentity> _signInManager;
        private readonly ILogger<UsuarioViewModel> _logger;
        private readonly IEmailSender _emailSender;

        public AccesoController(
            UserManager<UsuarioIdentity> userManager,
            SignInManager<UsuarioIdentity> signInManager,
            ILogger<UsuarioViewModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        // Direccionamiento al inicio del aplicativo
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        //**********************************|-----|**********************************
        //**********************************|LOGIN|**********************************
        //**********************************|-----|**********************************
        // --------------------------Petición GET del Login--------------------------
        public IActionResult Login(string returnUrl)        
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // --------------------------Petición POST del Login-------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel,string returnUrl = null)
        {
            //returnUrl ??= Url.Content("/Home/Index");            

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(
                    loginViewModel.Email,
                    loginViewModel.Password,
                    loginViewModel.RecordarMe,
                    lockoutOnFailure: false);
                //var estado = await _userManager.FindByIdAsync(usuarioIdentity.Id);
                if (user != null && result.Succeeded)
                {
                    if (await _userManager.IsEmailConfirmedAsync(user) && user.CambiarEstado == true)
                    {
                        _logger.LogInformation("User logged in.");
                        return RedirectToLocal(returnUrl);
                    }
                    else if (user.CambiarEstado == false)
                    {
                        ModelState.AddModelError(string.Empty, "Lo sentimos no puede ingresar, comuniquese con el administrador");
                    }                    
                }
                else if (user != null && (!await _userManager.IsEmailConfirmedAsync(user)))
                {
                    ModelState.AddModelError(string.Empty, "Cuenta sin confirmar, revisa tú correo");
                    return View(loginViewModel);
                }
                else if (user == null || !result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos");
                    return View(loginViewModel);
                }
                
            }

            // If we got this far, something failed, redisplay form
            return View(loginViewModel);
        }

        //**********************************|---------------|**********************************
        //**********************************|FORGOT PASSWORD|**********************************
        //**********************************|---------------|**********************************
        // ------------------------Peticion GET Recuperar contraseña---------------------------
        public IActionResult RecuperarPassword()
        {
            return View();
        }

        // ------------------------Peticion POST Recuperar contraseña---------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RecuperarPassword(string email)
        {

            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(email))
                {
                    ModelState.AddModelError(string.Empty, "Correo electrónico requerido");
                    return View();
                }

                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "El correo eléctronico no existe");
                    return View();
                }

                if (user != null || (await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // For more information on how to enable account confirmation and password reset please 
                    // visit https://go.microsoft.com/fwlink/?LinkID=532713
                    var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Action("RestablecerPassword", "Acceso", new
                    {
                        token = code,
                        email = user
                    }, Request.Scheme);

                    await _emailSender.SendEmailAsync(
                        email,
                        "Restablecer Contraseña",
                        $"Para restablecer su contraseña " +
                        $"por favor ingrese al siquiente enlace " +
                        $"<a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clic aquí</a>.");

                    ViewBag.Succeeded = 200;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "El correo eléctronico no existe");
                }

            }

            return View();
        }

        //**********************************|--------------|**********************************
        //**********************************|RESET PASSWORD|**********************************
        //**********************************|--------------|**********************************
        // ------------------------Peticion GET Restablecer contraseña---------------------------
        public IActionResult RestablecerPassword(string email, string token)
        {
            var model = new ResetPassViewModel
            {
                Email = email,
                Token = token
            };
            return View(model);

            //return View();
        }

        // ------------------------Peticion POST Restablecer contraseña---------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RestablecerPassword(ResetPassViewModel resetPassViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPassViewModel);
            }

            var user = await _userManager.FindByEmailAsync(resetPassViewModel.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                ModelState.AddModelError(string.Empty, "El correo eléctronico no existe");
                return RedirectToAction("RestablecerPassword", "Acceso");
            }

            if (user != null)
            {
                var token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(resetPassViewModel.Token));
                var result = await _userManager.ResetPasswordAsync(user, token, resetPassViewModel.Password);
                if (result.Succeeded)
                {
                    ViewBag.Succeeded = 200;
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View();
        }

        //**********************************|-------------|**********************************
        //**********************************|CERRAR SESION|**********************************
        //**********************************|-------------|**********************************
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction("Login", "Acceso");
        }
    }
}
