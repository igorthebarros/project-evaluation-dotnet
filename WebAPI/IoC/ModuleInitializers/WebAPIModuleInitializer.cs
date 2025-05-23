﻿using IoC.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.ModuleInitializers
{
    public class WebAPIModuleInitializer : IModuleInitializer
    {
        public void Initialize(WebApplicationBuilder builder) 
        {
            builder.Services.AddControllers();
            builder.Services.AddHealthChecks();
        }
    }
}
