﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Constant.Database;
using WS.Product.ApplicationService.ProductManagerModule.Abstracts;
using WS.Product.ApplicationService.ProductManagerModule.Implements;
using WS.Product.Infrastructure;
using WS.Shared.ApplicationService.User;

namespace WS.Product.ApplicationService.Startup
{
    public static class ProductStartup
    {
        public static void ConfigureProduct(this WebApplicationBuilder builder, string? assemblyName)
        {
            builder.Services.AddDbContext<ProductDbContext>(
                options =>
                {
                    options.UseSqlServer(
                        builder.Configuration.GetConnectionString("Default"),
                        options =>
                        {
                            options.MigrationsAssembly(assemblyName);
                            options.MigrationsHistoryTable(
                                DbSchema.TableMigrationsHistory,
                                DbSchema.Product
                            );
                        }
                    );
                },
                ServiceLifetime.Scoped
            );

            builder.Services.AddScoped<IProductService, ProductService>();
            //builder.Services.AddScoped<IUserInforService, UserInforService2>();
        }
    }
}
