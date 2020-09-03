using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonusarakOgren.Quiz.Business.Abstract;
using KonusarakOgren.Quiz.Business.Concrete;
using KonusarakOgren.Quiz.DataAccess.Abstract;
using KonusarakOgren.Quiz.DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Werwa.MvcWebUI.Middlewares;

namespace KonusarakOgren.Quiz.MvcWebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<QuizContext>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDal,EfUserDal>();
            services.AddScoped<IExamService, ExamManager>();
            services.AddScoped<IExamDal, EfExamDal>();

            services.AddScoped<IAnswerService, AnswerManager>();
            services.AddScoped<IAnswerDal, EfAnswerDal>();

            services.AddScoped<IQuestionService, QuestionManager>();
            services.AddScoped<IQuestionDal, EfQuestionDal>();
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();
            app.UseStaticFiles();
            app.UseNodeModules(env.ContentRootPath);

            app.UseMvc(ConfigureRoutes);
        }
        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            //Home/INdex/1
            routeBuilder.MapRoute("Default", "{controller=Account}/{action=Login}");
        }
    }
}
