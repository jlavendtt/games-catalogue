using GameCollection.Models.Auth;
using GameCollection.Repositories;
using GameCollection.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string name = "name=ConnectionStrings:Db3";
            //services.AddControllersWithViews();
            //services.AddControllersWithViews();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IUserRepo, DbUserRepo>();
            services.AddScoped<IGameRepo, DbGameRepo>();
            services.AddScoped<IUserRatingRepo, DbUserRatingRepo>();
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(o =>
            {
                o.Events = new JwtBearerEvents
                {
                    OnTokenValidated = (c =>
                    {
                        IUserService serv = c.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        int id = int.Parse(c.Principal.Claims.Single(claim => claim.Type == ClaimTypes.NameIdentifier.ToString()).Value);
                        User foundUser = serv.GetUserById(id);
                        if (foundUser == null)
                        {
                            c.Fail("Unauthorized User");
                        }
                        return Task.CompletedTask;
                    })


                };
                o.RequireHttpsMetadata = false; //For Development only. Turn off in production!!
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AppSettings.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false

                };
            });


            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: MyAllowSpecificOrigins,
            //                      builder =>
            //                      {
            //                          builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
            //                      });
            //});

            services.AddCors();


            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                
            });



            // ...

            services.AddDbContext<CollectionDbContext>((o) => o.UseSqlServer(name));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //app.UseCors(
       // options => options.WithOrigins("http://localhost:3000").AllowAnyMethod()
   // );

           

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

            app.UseRouting();

            //app.UseCors(MyAllowSpecificOrigins);

            app.UseCors(o => o.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();

            



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
