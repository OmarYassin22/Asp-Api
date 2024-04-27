﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Access.Models;
using Talabat.Repos.Data.Contexts;

namespace Talabat.Repos.Helpers
{
    public static class Data
    {
        public static async Task ReadAsync(StoreDbContext context)
        {
            if (context.Brands?.Count() == 0)
            {
                var BrandData = File.ReadAllText("D:\\courses\\C#\\Route\\Matrial\\03-C#\\7-API\\WebApplication1\\Talabat.Repos\\Data\\InitalData\\brands.json");
                var brands = JsonSerializer.Deserialize<List<Brand>>(BrandData);
                if (brands is not null)
                {

                    foreach (var brand in brands)
                    {
                        context.Add(brand);
                    }
                    await context.SaveChangesAsync();
                }

            }
            if (context.Categories?.Count() == 0)
            {

                var CatData = File.ReadAllText("..\\Talabat.Repos\\InitalData\\categories.json");
                var cats = JsonSerializer.Deserialize<List<Category>>(CatData);
                if (cats is not null)
                {
                    foreach (var cat in cats)
                    {
                        context.Add(cat);

                    }
                    context.SaveChanges();
                }



            }
            if (context.Products?.Count() == 0)
            {
                var ProData = File.ReadAllText("D:\\courses\\C#\\Route\\Matrial\\03-C#\\7-API\\WebApplication1\\Talabat.Repos\\Data\\InitalData\\products.json");
                var Pros = JsonSerializer.Deserialize<List<Product>>(ProData);
                if (Pros is not null)
                {
                    foreach (var Pro in Pros)
                    {
                        context.Add(Pro);

                    }
                    context.SaveChanges();
                }




            }

        }
    }
}