﻿using Application.Pocos;
using Application.Services;
using Domain.Contracts.Services;
using IoC.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.ModuleInitializers
{
    public class ApplicationModuleInitializer : IModuleInitializer
    {
        public void Initialize(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IOrderService, OrderService>();

            builder.Services.Configure<FeatureFlags>(
                builder.Configuration.GetSection("FeatureFlags"));
        }
    }
}
