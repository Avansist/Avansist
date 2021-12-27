using Avansist.Models.Entities;
using Avansist.Web.Models;
using Avansist.Web.Models.Email;
using Avansist.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Avansist.Web.Controllers
{
    //[Authorize(Roles = "Administrador")]
    public class ConfiguracionController : Controller
    {

        private readonly UserManager<UsuarioIdentity> _userManager;
        private readonly SignInManager<UsuarioIdentity> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<UsuarioViewModel> _logger;
        private readonly IEmailSender _emailSender;

        public ConfiguracionController(
            UserManager<UsuarioIdentity> userManager,
            SignInManager<UsuarioIdentity> signInManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<UsuarioViewModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> Index()
        {
            var usuariosList = await _userManager.Users.ToListAsync();
            var listaUsuariosViewModel = new List<UsuarioViewModel>();

            foreach (var usuario in usuariosList)
            {
                var usuarioViewModel = new UsuarioViewModel()
                {
                    Id = usuario.Id,
                    Nombre = usuario.Nombre,
                    CambiarEstado = usuario.CambiarEstado,
                    Email = usuario.Email,
                    Rol = await ObtenerRolUsuario(usuario)
                };
                listaUsuariosViewModel.Add(usuarioViewModel);
            }
            return View(listaUsuariosViewModel);
        }

        //**********************************|------------------|**********************************
        //**********************************|GESTIÓN DE USUARIO|**********************************
        //**********************************|------------------|**********************************
        // --------------------------Petición GET del CrearUsuario-------------------------
        public async Task<IActionResult> CrearUsuario()
        {
            ViewData["Roles"] = new SelectList(await _roleManager.Roles.ToListAsync(), "Name", "Name");
            return View();
        }

        // --------------------------Petición POST del CrearUsuario-------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearUsuario(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var userTem = await _userManager.FindByEmailAsync(usuarioViewModel.Email);
                if (userTem == null)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var user = new UsuarioIdentity
                    {
                        Nombre = usuarioViewModel.Nombre,
                        CambiarEstado = usuarioViewModel.CambiarEstado,
                        UserName = usuarioViewModel.Email,
                        Email = usuarioViewModel.Email
                    };

                    var result = await _userManager.CreateAsync(user, usuarioViewModel.Password);
                    if (result.Succeeded)
                    {
                        //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        //var callbackUrl = Url.Action("ConfirmarEmailPost", "Configuracion", new
                        //{
                        //    token = code,
                        //    email = usuarioViewModel.Email
                        //}, Request.Scheme);

                        //await _emailSender.SendEmailAsync(usuarioViewModel.Email, "Confirmar correo eléctronico",
                        //    $"<h1>¡Bienvenid@!</h1></br></br>" +
                        //    $"<p>Estimad@ {usuarioViewModel.Nombre}, estas son las credenciales que debe utilizar para el inicio de sesión</p>" +
                        //    $"<p>Usuario: <b>{usuarioViewModel.Email}</b></p>" +
                        //    $"<p>Contraseña: <b>{usuarioViewModel.Password}</b></p></br>" +
                        //    $"<p>En el siguiente enlace podra activar la cuenta" +
                        //    $" y tener acceso al aplicativo <b>Avansist</b>.</br>" +
                        //    $"<a style='font-size:13px' href='{HtmlEncoder.Default.Encode(callbackUrl)}'>Clic aquí</a>.");

                        await _userManager.AddToRoleAsync(user, usuarioViewModel.RolSeleccionado);
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
        // --------------------------Petición GET del ConfirmarEmail-------------------------
        public IActionResult ConfirmarEmail()
        {
            return View();
        }

        // --------------------------Petición POST del ConfirmarEmailPost-------------------------
        public async Task<IActionResult> ConfirmarEmailPost(string token, string email)
        {
            if (email == null || token == null)
            {
                return RedirectToAction("Login", "Acceso");
            }

            token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
            var user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (user != null && result.Succeeded)
            {
                return RedirectToAction("ConfirmarEmail", "Configuracion");
            }

            return NotFound();
        }

        //**********************************|--------------|**********************************
        //**********************************|EDITAR USUARIO|**********************************
        //**********************************|--------------|**********************************
        // --------------------------Petición GET del EditarUsuario-------------------------
        public async Task<IActionResult> EditarUsuario(string id)
        {
            var usuario = await _userManager.FindByIdAsync(id);
            if (usuario == null)
            {
                ViewBag.ErrorMessage = $"El usuario con id {id} no se encontró";
                return View("Error2");
            }

            // Una lista de las notificaciones
            var usuarioClaims = await _userManager.GetClaimsAsync(usuario);
            // GetRolesAsync returns the list of user Roles
            var usuarioRoles = await _userManager.GetRolesAsync(usuario);

            var model = new EditarUsuarioViewModel
            {
                Id = usuario.Id,
                NombreUsuario = usuario.Nombre,
                CambiarEstado = usuario.CambiarEstado,
                Notificaciones = usuarioClaims.Select(c => c.Value).ToList(),
                Roles = usuarioRoles
            };
            return View(model);
        }

        // --------------------------Petición POST del EditarUsuario-------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarUsuario(EditarUsuarioViewModel editarUsuarioViewModel)
        {
            var usuario = await _userManager.FindByIdAsync(editarUsuarioViewModel.Id);
            if (usuario == null)
            {
                ViewBag.ErrorMessage = $"El usuario con id {editarUsuarioViewModel.Id} no se encontró";
                return View("Error2");
            }
            else
            {
                usuario.Nombre = editarUsuarioViewModel.NombreUsuario;
                usuario.CambiarEstado = editarUsuarioViewModel.CambiarEstado;

                var result = await _userManager.UpdateAsync(usuario);

                if (result.Succeeded)
                {
                    ViewBag.Succeeded = 200;
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(editarUsuarioViewModel);
            }

            //if (ModelState.IsValid)
            //{
            //    //var userTem = await _userManager.FindByEmailAsync(usuarioViewModel.Email);
            //    //if (userTem == null)
            //    //{
            //    var user = new UsuarioIdentity
            //    {
            //        Nombre = usuarioViewModel.Nombre,
            //        CambiarEstado = usuarioViewModel.CambiarEstado
            //    };

            //    var result = await _userManager.UpdateAsync(user);
            //    if (result.Succeeded)
            //    {
            //        //ViewBag para abrir modal en la vista de registrarUsuarioExterno
            //        ViewBag.Succeeded = 200;
            //        return RedirectToAction("Index", "Configuracion");
            //    }
            //    else
            //    {
            //        foreach (var error in result.Errors)
            //        {
            //            ModelState.AddModelError(string.Empty, error.Description);
            //        }
            //    }
            //    //}
            //    //else
            //    //{
            //    //    ModelState.AddModelError(string.Empty, "El correo eléctronico ya existe");
            //    //    return View(usuarioViewModel);
            //    //}                
            //}
            //ModelState.AddModelError(string.Empty, "No se pudo actualizar, intentalo de nuevo");
            //return View(usuarioViewModel);
        }

        //**********************************|----------------|**********************************
        //**********************************|ELININAR USUARIO|**********************************
        //**********************************|----------------|**********************************
        // --------------------------Petición POST del EliminarUsuario-------------------------
        public async Task<IActionResult> EliminarUsuario(string id)
        {
            var usuario = await _userManager.FindByIdAsync(id);
            if (usuario == null)
            {
                ViewBag.ErrorMessage = $"El usuario con id {id} no se encontró";
                return View("Error2");
            }
            else
            {
                try
                {
                    var result = await _userManager.DeleteAsync(usuario);
                    if (result.Succeeded)
                    {
                        //ViewData["Succeeded"] = "200";
                        //ViewBag.Succeeded = 200;
                        return RedirectToAction("Index", "Configuracion");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                catch (DbUpdateException ex)
                {
                    //Pasamos el titulo del error y el mensaje
                    ViewBag.ErrorTitle = $"Usuario {usuario.UserName} está siendo utilizado";
                    ViewBag.ErrorMessage = $"El usuario{usuario.UserName} no se puede eliminar porque esta en uso, " +
                        $"remueva el rol de este usuario para eliminarlo";
                    return View("ErrorGenerico");
                }
            }

            return RedirectToAction("Index", "Configuracion");
        }


        /*************************************GESTIÓN DE ROLES******************************************************/

        //**********************************|----------------|**********************************
        //**********************************|GESTIÓN DE ROLES|**********************************
        //**********************************|----------------|**********************************
        // ------------------------Petición GET del ObtenerRolUsuario-------------------------
        private async Task<List<string>> ObtenerRolUsuario(UsuarioIdentity usuario)
        {
            return new List<string>(await _userManager.GetRolesAsync(usuario));
        }

        //**********************************|---------|**********************************
        //**********************************|CREAR ROL|**********************************
        //**********************************|---------|**********************************
        // ------------------------Petición GET de CrearRol-------------------------
        public IActionResult CrearRol()
        {
            return View();
        }

        // ------------------------Petición POST del CrearRol-------------------------
        [HttpPost]
        public async Task<IActionResult> CrearRol(RolViewModel rolViewModel)
        {
            if (ModelState.IsValid)
            {

                IdentityRole rol = new()
                {
                    Name = rolViewModel.NombreRol
                };

                var result = await _roleManager.CreateAsync(rol);
                if (result.Succeeded)
                {
                    ViewBag.Succeeded = 200;
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(rolViewModel);
        }

        //**********************************|---------|**********************************
        //**********************************|LISTAR ROL|**********************************
        //**********************************|---------|**********************************
        public IActionResult ListarRoles()
        {

            var listaRoles = _roleManager.Roles;
            return View(listaRoles);
        }

        //**********************************|----------|**********************************
        //**********************************|EDITAR ROL|**********************************
        //**********************************|----------|**********************************
        // ------------------------Petición GET del EditarRol-------------------------
        public async Task<IActionResult> EditarRol(string id)
        {
            var rol = await _roleManager.FindByIdAsync(id);
            if (rol == null)
            {
                ViewBag.ErrorMessage = $"El usuario con id {id} no se encontró";
                return View("Error2");
            }

            // Una lista de las notificaciones
            var rolClaims = await _roleManager.GetClaimsAsync(rol);

            var model = new EditarRolViewModel
            {
                Id = rol.Id,
                NombreRol = rol.Name,
                Notificaciones = rolClaims.Select(c => c.Value).ToList()
            };

            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, rol.Name))
                {
                    model.Usuarios.Add(user.UserName);
                }
            }

            return View(model);


            //var rol = await _roleManager.FindByIdAsync(id);
            //if (rol == null)
            //{
            //    ViewBag.ErrorMessage = $"El rol con id {id} no se encontró";
            //    return View("Error2");
            //}
            //var editarRolViewModel = new EditarRolViewModel
            //{
            //    Id = rol.Id,
            //    NombreRol = rol.Name
            //};

            //foreach (var user in _userManager.Users)
            //{
            //    if (await _userManager.IsInRoleAsync(user, rol.Name))
            //    {
            //        editarRolViewModel.Usuarios.Add(user.UserName);
            //    }

            //}
            //return View(editarRolViewModel);
        }

        // ------------------------Petición GET del EditarRol-------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarRol(EditarRolViewModel editarRolViewModel)
        {
            if (ModelState.IsValid)
            {
                var rol = await _roleManager.FindByIdAsync(editarRolViewModel.Id);
                if (rol == null)
                {
                    ViewBag.ErrorMessage = $"El rol con id {editarRolViewModel.Id} no se encontró";
                    return View("Error2");
                }
                else
                {
                    rol.Name = editarRolViewModel.NombreRol;
                    var result = await _roleManager.UpdateAsync(rol);
                    if (result.Succeeded)
                    {
                        ViewBag.Succeeded = 200;
                        //return RedirectToAction("ListarRoles");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);

                    }
                }
            }

            return View(editarRolViewModel);
        }

        public async Task<IActionResult> DetalleRol(string id)
        {
            var rol = await _roleManager.FindByIdAsync(id);
            if (rol == null)
            {
                ViewBag.ErrorMessage = $"El usuario con id {id} no se encontró";
                return View("Error2");
            }

            var model = new EditarRolViewModel
            {
                Id = rol.Id,
                NombreRol = rol.Name
            };

            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, rol.Name))
                {
                    model.Usuarios.Add(user.UserName);
                }
            }

            return View(model);
        }
        //// ------------------------Petición GET del EditarUsuarioRol-------------------------
        //public async Task<IActionResult> EditarUsuarioRol(string rolId)
        //{
        //    ViewBag.roleId = rolId;

        //    var role = await _roleManager.FindByIdAsync(rolId);

        //    if (role == null)
        //    {
        //        ViewBag.ErrorMessage = $"Rol con el Id = {rolId} no fue encontrado";
        //        return View("Error2");
        //    }

        //    var model = new List<UsuarioRolViewModel>();

        //    foreach (var user in _userManager.Users)
        //    {
        //        var usuarioRolModelo = new UsuarioRolViewModel
        //        {
        //            UsuarioId = user.Id,
        //            UsuarioNombre = user.UserName
        //        };

        //        if (await _userManager.IsInRoleAsync(user, role.Name))
        //        {
        //            usuarioRolModelo.EstaSeleccionado = true;
        //        }
        //        else
        //        {
        //            usuarioRolModelo.EstaSeleccionado = false;
        //        }

        //        model.Add(usuarioRolModelo);
        //    }
        //    return View(model);
        //}

        //// ------------------------Petición POST del EditarUsuarioRol-------------------------
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditarUsuarioRol(List<UsuarioRolViewModel> model, string rolId)
        //{
        //    var rol = await _roleManager.FindByIdAsync(rolId);

        //    if (rolId == null)
        //    {
        //        ViewBag.ErrorMessage = $"Rol con el Id {rolId} no fue encontrado";
        //        return View("Error");
        //    }

        //    for (int i = 0; i < model.Count; i++)
        //    {
        //        var user = await _userManager.FindByIdAsync(model[i].UsuarioId);

        //        IdentityResult result = null;

        //        if (model[i].EstaSeleccionado && !(await _userManager.IsInRoleAsync(user, rol.Name)))
        //        {
        //            result = await _userManager.AddToRoleAsync(user, rol.Name);
        //        }
        //        else if (!model[i].EstaSeleccionado && await _userManager.IsInRoleAsync(user, rol.Name))
        //        {
        //            result = await _userManager.RemoveFromRoleAsync(user, rol.Name);
        //        }
        //        else
        //        {
        //            continue;
        //        }

        //        if (result.Succeeded)
        //        {
        //            if (i < (model.Count - 1))
        //            {
        //                continue;
        //            }
        //            else
        //            {
        //                return RedirectToAction("EditarRol", new { Id = rolId });
        //            }
        //        }
        //    }
        //    return RedirectToAction("EditarRol", new { Id = rolId });
        //}

        //**********************************|------------|**********************************
        //**********************************|ELIMINAR ROL|**********************************
        //**********************************|------------|**********************************
        // ------------------------Petición POST del EliminarRol-------------------------        
        public async Task<IActionResult> EliminarRol(string id)
        {
            var rol = await _roleManager.FindByIdAsync(id);
            if (rol == null)
            {
                ViewBag.ErrorMessage = $"Usuario con Id = {id} no fue encontrado";
                return View("Error2");
            }
            else
            {
                try
                {
                    var result = await _roleManager.DeleteAsync(rol);
                    if (result.Succeeded)
                    {
                        return ViewBag.Succeeded = 200;
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                catch (DbUpdateException ex)
                {
                    //Pasamos el titulo del error y el mensaje
                    ViewBag.ErrorTitle = $"Rol {rol.Name} está siendo utilizado";
                    ViewBag.ErrorMessage = $"El rol {rol.Name} no se puede eliminar porque esta en uso, " +
                        $"remueva los usuarios de este rol para eliminarlo";
                    return View("ErrorGenerico");
                }

            }

            return RedirectToAction("ListarRoles", "Configuracion");
        }

        //**********************************|--------------------|**********************************
        //**********************************|GESTIONAR ROLUSUARIO|**********************************
        //**********************************|--------------------|**********************************
        // ------------------------Petición GET del GestionarRolesUsuario-------------------------
        public async Task<IActionResult> GestionarRolesUsuario(string idUsuario)
        {
            ViewBag.IdUsuario = idUsuario;

            var user = await _userManager.FindByIdAsync(idUsuario);

            if (user == null)
            {
                return NotFound();
            }

            var model = new List<RolUsuarioViewModel>();

            foreach (var rol in _roleManager.Roles)
            {
                var rolUsuarioViewModel = new RolUsuarioViewModel
                {
                    RolId = rol.Id,
                    RolNombre = rol.Name
                };

                if (await _userManager.IsInRoleAsync(user, rol.Name))
                {
                    rolUsuarioViewModel.EstaSeleccionado = true;
                }
                else
                {
                    rolUsuarioViewModel.EstaSeleccionado = false;
                }

                model.Add(rolUsuarioViewModel);
            }
            return View(model);
        }

        // ------------------------Petición POST del GestionarRolesUsuario-------------------------
        [HttpPost]
        public async Task<IActionResult> GestionarRolesUsuario(List<RolUsuarioViewModel> model, string IdUsuario)
        {
            var usuario = await _userManager.FindByIdAsync(IdUsuario);

            if (usuario == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(usuario);
            //if (PasswordValidator<IdentityRole> != 1)
            //{
            //    throw new Exception("Solo se puede tener un rol por usuario");
            //}
            var result = await _userManager.RemoveFromRolesAsync(usuario, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "No podemos borrar usuario con roles");
                return View(model);
            }

            result = await _userManager.AddToRolesAsync(usuario,
                model.Where(x => x.EstaSeleccionado).Select(y => y.RolNombre));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "No podemos añadir los roles al usuario seleccionado");
            }

            return RedirectToAction("EditarUsuario", new { Id = IdUsuario });
        }

        //**********************************|-----------------------|**********************************
        //**********************************|GESTIONAR USUARIOCLAIMS|**********************************
        //**********************************|-----------------------|**********************************
        // ------------------------Petición GET del GestionarUsuarioClaims-------------------------
        public async Task<IActionResult> GestionarUsuarioClaims(string IdUsuario)
        {
            var usuario = await _userManager.FindByIdAsync(IdUsuario);

            if (usuario == null)
            {
                ViewBag.ErrorMessage = $"El usuario con id = {IdUsuario} no se encontro";
                return View("Error");
            }

            //Obtenemos todos los claims del usuario actual
            var existingUserClaims = await _userManager.GetClaimsAsync(usuario);

            var model = new UsuarioClaimsViewModel
            {
                idUsuario = IdUsuario
            };

            //Recorremos los claims de nuestra aplicación
            foreach (Claim claim in AlmacenClaims.todosLosClaims)
            {
                UsuarioClaim usuarioClaim = new()
                {
                    tipoClaim = claim.Type
                };

                // si el usuario tiene el claim que estamos recorriendo en este momento lo seleccionamos
                if (existingUserClaims.Any(c => c.Type == claim.Type))
                {
                    usuarioClaim.estaSeleccionado = true;
                }

                model.Claims.Add(usuarioClaim);
            }
            return View(model);
        }

        // ------------------------Petición POST del GestionarUsuarioClaims-------------------------
        [HttpPost]
        public async Task<IActionResult> GestionarUsuarioClaims(UsuarioClaimsViewModel modelo)
        {
            var usuario = await _userManager.FindByIdAsync(modelo.idUsuario);

            if (usuario == null)
            {
                ViewBag.ErrorMessage = $"El usuario con id = {modelo.idUsuario} no se encontro";
                return View("Error");
            }

            //Obtenemos los claims del usuario y los borramos
            var claims = await _userManager.GetClaimsAsync(usuario);
            var result = await _userManager.RemoveClaimsAsync(usuario, claims);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "No se pueden borrar los claims de este usuario");
                return View(modelo);
            }

            // Volvemos a asociar los seleccionados en la interfaz grafica
            result = await _userManager.AddClaimsAsync(usuario,
                modelo.Claims.Where(c => c.estaSeleccionado).Select(c => new Claim(c.tipoClaim, c.tipoClaim)));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "No se puede agregar el claim a este usuario");
                return View(modelo);
            }

            return RedirectToAction("EditarUsuario", new { Id = modelo.idUsuario });
        }





















        //public async Task<IActionResult> GestionarRolClaims(string IdRol)
        //{
        //    var rol = await _roleManager.FindByIdAsync(IdRol);

        //    if (rol == null)
        //    {
        //        ViewBag.ErrorMessage = $"El usuario con id = {IdRol} no se encontro";
        //        return View("Error");
        //    }

        //    //Obtenemos todos los claims del usuario actual
        //    var existingUserClaims = await _roleManager.GetClaimsAsync(rol);

        //    var model = new RolClaimsViewModel
        //    {
        //        idUsuario = IdRol
        //    };

        //    //Recorremos los claims de nuestra aplicación
        //    foreach (Claim claim in AlmacenClaims.todosLosClaims)
        //    {
        //        RolClaim rolClaim = new()
        //        {
        //            tipoClaim = claim.Type
        //        };

        //        // si el usuario tiene el claim que estamos recorriendo en este momento lo seleccionamos
        //        if (existingUserClaims.Any(c => c.Type == claim.Type))
        //        {
        //            rolClaim.estaSeleccionado = true;
        //        }

        //        model.Claims.Add(rolClaim);
        //    }
        //    return View(model);
        //}


        //[HttpPost]
        //public async Task<IActionResult> GestionarRolClaims(RolClaimsViewModel modelo)
        //{
        //    var rol = await _roleManager.FindByIdAsync(modelo.idUsuario);

        //    if (rol == null)
        //    {
        //        ViewBag.ErrorMessage = $"El usuario con id = {modelo.idUsuario} no se encontro";
        //        return View("Error");
        //    }

        //    //Obtenemos los claims del usuario y los borramos
        //    var claims = await _roleManager.GetClaimsAsync(rol);
        //    var result = await _roleManager.RemoveClaimAsync(rol, IEnumerable<claims> claims);

        //    if (!result.Succeeded)
        //    {
        //        ModelState.AddModelError("", "No se pueden borrar los claims de este usuario");
        //        return View(modelo);
        //    }

        //    // Volvemos a asociar los seleccionados en la interfaz grafica
        //    result = await _roleManager.AddClaimAsync(rol, Claim claim));

        //    if (!result.Succeeded)
        //    {
        //        ModelState.AddModelError("", "No se puede agregar el claim a este rol");
        //        return View(modelo);
        //    }

        //    return RedirectToAction("EditarRol", new { Id = modelo.idUsuario });
        //}
    }
}
