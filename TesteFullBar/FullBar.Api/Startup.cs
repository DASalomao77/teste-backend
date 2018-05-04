﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullBar.Api.Models;
using FullBar.Api.Repository;
using FullBar.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FullBar.Api
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

            services.AddCors(o => o.AddPolicy("PolicyFree", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));


            services.AddMvc();

            services.AddTransient<IService<Aluno>, AlunoService>();
            services.AddTransient<IRepository<Aluno>, AlunoRepository>();

            services.AddTransient<IService<Curso>, CursoService>();
            services.AddTransient<IRepository<Curso>, CursoRepository>();

            services.AddTransient<IService<Periodo>, PeriodoService>();
            services.AddTransient<IRepository<Periodo>, PeriodoRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}