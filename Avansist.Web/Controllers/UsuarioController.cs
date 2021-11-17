using Avansist.Models.Entities;
using Avansist.Web.Models.Email;
using Avansist.Web.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Avansist.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UserManager<UsuarioIdentity> _userManager;
        private readonly SignInManager<UsuarioIdentity> _signInManager;
        private readonly ILogger<UsuarioViewModel> _logger;
        private readonly IEmailSender _emailSender;

        public UsuarioController(UserManager<UsuarioIdentity> userManager, SignInManager<UsuarioIdentity> signInManager, ILogger<UsuarioViewModel> logger, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(UsuarioController), "Login");
            }
        }



        //public string ReturnUrl { get; set; }

        //public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _userManager.Users.ToListAsync();
            var listaUsuariosViewModel = new List<UsuarioViewModel>();

            foreach (var usuario in usuarios)
            {
                var usuarioViewModel = new UsuarioViewModel()
                {
                    Nombre = usuario.Nombre,
                    Email = usuario.Email,
                    CambiarEstado = usuario.CambiarEstado                    
                };
                listaUsuariosViewModel.Add(usuarioViewModel);
            }
            return View(listaUsuariosViewModel);
        }

        //**********************************|-----|**********************************
        //**********************************|LOGIN|**********************************
        //**********************************|-----|**********************************

        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl = null)
        {
            returnUrl ??= Url.Content("/Home/Index");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();            

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);                
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email,
                                                                      loginViewModel.Password,
                                                                      loginViewModel.RecordarMe,
                                                                      lockoutOnFailure: false);
                if (user != null && result.Succeeded)
                {
                    if (await _userManager.IsEmailConfirmedAsync(user))
                    {
                        _logger.LogInformation("User logged in.");
                        return LocalRedirect(returnUrl);
                    }
                }
                else if(user == null)
                {                    
                    ModelState.AddModelError(string.Empty, "Usuario o contraseña invalidos");
                    return View(loginViewModel);
                }
                else if (user != null && (!await _userManager.IsEmailConfirmedAsync(user)))
                {
                    ModelState.AddModelError(string.Empty, "Cuenta sin confirmar, revisa tú correo");
                    return View(loginViewModel);
                }                
            }

            // If we got this far, something failed, redisplay form
            return View(loginViewModel);
        }

        //**********************************|---------------------|**********************************
        //**********************************|CREAR USUARIO EXTERNO|**********************************
        //**********************************|---------------------|**********************************

        public IActionResult CrearUsuarioExterno()
        {
            //ViewData["Roles"] = new SelectList(await _roleManager.Roles.ToListAsync(), "Name", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearUsuarioExterno(UsuarioViewModel usuarioViewModel)
        {
            //returnUrl ??= Url.Content("/Usuario/Login");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var userTem = await _userManager.FindByEmailAsync(usuarioViewModel.Email);
                if (userTem == null)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var user = new UsuarioIdentity 
                    { 
                        Nombre = usuarioViewModel.Nombre,
                        CambiarEstado = usuarioViewModel.CambiarEstado = true,
                        UserName = usuarioViewModel.Email,
                        Email = usuarioViewModel.Email 
                    };

                    var result = await _userManager.CreateAsync(user, usuarioViewModel.Password);
                    if (result.Succeeded)
                    {
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = Url.Action("ConfirmarEmailPost", "Usuario", new
                        {
                            token = code,
                            email = usuarioViewModel.Email
                        }, Request.Scheme);

                        await _emailSender.SendEmailAsync(usuarioViewModel.Email, "Confirmar correo eléctronico",
                            $"<h1>¡Bienvenid@!</h1></br></br>" +
                            $"<p>Estimado usuario, en el siguiente enlace podra activar su cuenta" +
                            $" y tener acceso al aplicativo <b>Avansist</b>, gracias por realizar el registro.</p></br></br> " +
                            $"<p>Por favor confirma tú cuenta</p><a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clic aquí</a>.");

                        //ViewBag para abrir modal en la vista de registrarUsuarioExterno
                        ViewBag.Succeeded = 200;
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "El correo eléctronico ya existe");
                }                
            }

            // If we got this far, something failed, redisplay form
            return View(usuarioViewModel);
        }

        //**********************************|----------------|**********************************
        //**********************************|CONFIRMAR CORREO|**********************************
        //**********************************|----------------|**********************************

        public IActionResult ConfirmarEmail()
        {
            return View();
        }

        public async Task<IActionResult> ConfirmarEmailPost(string token, string email)
        {
            if (email == null || token == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
            var user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (user != null && result.Succeeded)
            {
                return RedirectToAction("ConfirmarEmail", "Usuario");
            }

            return NotFound();
        }

        //**********************************|---------------|**********************************
        //**********************************|FORGOT PASSWORD|**********************************
        //**********************************|---------------|**********************************

        public IActionResult RecuperarPassword()
        {
            return View();
        }

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
                    var callbackUrl = Url.Action("RestablecerPassword", "Usuario", new
                    {
                        token = code,
                        email = user
                    }, Request.Scheme);                    

                    await _emailSender.SendEmailAsync(
                        email,
                        "Restablecer Contraseña",
                        $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

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
                return RedirectToAction("RestablecerPassword", "Usuario");
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

        public IActionResult ReenviarCorreoConfirmacion()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReenviarCorreoConfirmacion(string email)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

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

            //var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Action("ConfirmarEmailPost", "Usuario", new
            {
                token = code,
                email = user
            }, Request.Scheme);

            await _emailSender.SendEmailAsync(email, "Confirmar correo eléctronico",
                $"<h1>¡Bienvenid@!</h1></br></br>" +
                $"<p>Estimado usuario, en el siguiente enlace podra activar su cuenta" +
                $" y tener acceso al aplicativo <b>Avansist</b>, gracias por realizar el registro.</p></br></br> " +
                $"<p>Por favor confirma tú cuenta</p><a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clic aquí</a>.");            

            ModelState.AddModelError(string.Empty, "Verifica tu bandeja de correo electrónico");
            return View();
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction("Login", "Usuario");
        }
    }
}
