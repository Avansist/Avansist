using Avansist.DAL;
using Avansist.Models.Entities;
using Avansist.Services.Abstract;
using Avansist.Services.Servicies;
using Avansist.Web.Models;
using Avansist.Web.Models.Email;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avansist.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AvansistDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            //services.AddMvc(options => 
            //{
            //    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            //    options.Filters.Add(new AuthorizeFilter(policy));
            //}).AddXmlSerializerFormatters();

            //Configuracion para envio de correos
            services.Configure<EmailSenderOptions>(Configuration.GetSection("EmailSenderOptions"));
            services.AddSingleton<IEmailSender, EmailSender>();

            // Configuración libreria Identity
            services.AddIdentity<UsuarioIdentity, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddErrorDescriber<ErroresCastellano>()
                .AddEntityFrameworkStores<AvansistDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<UsuarioIdentity>>(TokenOptions.DefaultProvider);
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Acceso/Login");
                options.LoginPath = new PathString("/Acceso/Login");
                options.Cookie.Name = "Cookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("BorrarRolPolicy", policy => policy.RequireClaim("Borrar Rol"));
            });

            //Servicios para las inyecciones de dependencias
            services.AddScoped<IPreinscripcionServices, PreinscripcionServices>();
            services.AddScoped<IPadrinoServices, PadrinoServices>();
            services.AddScoped<ICalendarioServices, CalendarioServices>();
            services.AddScoped<IControlAsistenciaServices, ControlAsistenciaServices>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions d = new()
                {
                    SourceCodeLineCount = 2
                };
                app.UseDeveloperExceptionPage(d);

            }else if(env.IsProduction() || env.IsStaging())
            {
                app.UseExceptionHandler("/Error2");
                app.UseStatusCodePagesWithRedirects("/Error2/{0}");
            }
            else
            {
                //app.UseStatusCodePagesWithRedirects("/Error2/{0}");
                //app.UseExceptionHandler("/Home/Error");
                ////// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Acceso}/{action=Login}/{id?}");
            });
        }
    }
}
