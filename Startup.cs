﻿using Fiap01.Data;
using Fiap01.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Fiap01
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;ConnectRetryCount=0";

            services.AddDbContext<PerguntasContext>(o => o.UseSqlServer(connection));

            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            #region exemplo de middleware
            //app.Use((context, next) =>
            //{
            //    context.Response.Headers.Add("X-Teste", "headerteste");
            //    return next();
            //});
            //app.Use(async (context, next) =>
            //{
            //    var teste = 123;
            //    await next.Invoke();
            //    var teste2 = 1234;
            //    //await context.Response.WriteAsync("teste");

            //});

            //app.Run(async context => {
            //    await context.Response.WriteAsync("boa noite");
            //});
            #endregion

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            //app.UseMiddleware<LogMiddleware>();
            app.UseMeuLog();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                 name: "default",
                 template: "{controller=Home}/{action=Index}/{id?}");

                //routes.MapRoute(
                //   name: "autor",
                //   template: "autor/{nome}",
                //   defaults: new { controller = "Autor", action = "Index" });

                //routes.MapRoute(
                //        name: "topicosdacategoria",
                //        template: "{categoria}/{topico}",
                //        defaults: new { controller = "Topicos", action = "Index" });

                //routes.MapRoute(
                //   name: "autoresDoAno",
                //   template: "{ano:int}/autor",
                //   defaults: new { controller = "Autor", action = "ListaDosAutoresDoAno" });
            });
        }
    }
}
