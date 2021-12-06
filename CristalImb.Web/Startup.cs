using CristalImb.Business.Abstract;
using CristalImb.Business.Business;
using CristalImb.Model.DAL;
using CristalImb.Model.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web
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
            services.AddControllersWithViews();
            services.AddControllersWithViews();

            var conexion = Configuration["ConnectionStrings:conexion_sqlServer"];
            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(conexion));

            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IPropietarioService, PropietarioService>();

            services.AddScoped<IInmuebleService, InmuebleService>();

            services.AddScoped<IEmpleadoService, EmpleadoService>();

            services.AddScoped<ICitaService, CitaService>();

            services.AddScoped<ITipoInmuebleService, TipoInmuebleService>();
            services.AddScoped<IZonaService, ZonaService>();
            services.AddScoped<IServiciosInmuebleService, ServiciosInmuebleService>();
            services.AddScoped<IEstadoCitaService, EstadoCitaService>();
            services.AddScoped<IEstadosInmuebleService, EstadosInmuebleService>();
            services.AddScoped<IInmPropietariosService, InmPropietariosService>();
            services.AddScoped<IUsuariosService, UsuariosService>();

            //password config
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.User.RequireUniqueEmail = true;
            });

            services.AddIdentity<UsuarioIdentity, Rol>(options => options.SignIn.RequireConfirmedAccount = false)
               .AddDefaultUI()
               .AddDefaultTokenProviders()
               .AddEntityFrameworkStores<AppDbContext>();


            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Admin/NoAutorizado");
                options.Cookie.Name = "Cookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
                options.LoginPath = new PathString("/Usuarios/Login");
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });
            services.AddRazorPages().AddRazorRuntimeCompilation();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Landing}/{action=IndexLanding}/{id?}");
            });
        }
    }
}
