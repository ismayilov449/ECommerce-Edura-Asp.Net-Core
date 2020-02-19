using Edura.WebUI.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices
                .GetRequiredService<EduraContext>();

            context.Database.Migrate();

            if (!context.Products.Any())
            {
                var products = new[]
                {
                    new Product(){ ProductName="Photo Camera", Price=153, Image="product1.jpg",IsHome=true,IsApproved=true,IsFeatured=true, Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. Proin varius arcu metus.", HtmlContent="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-10)},
                    new Product(){ ProductName="Wood Chair", Price=99, Image="product2.jpg",IsHome=false,IsApproved=true,IsFeatured=true, Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. Proin varius arcu metus.", HtmlContent="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-20)},
                    new Product(){ ProductName="Comfortable Sofa", Price=526, Image="product3.jpg",IsHome=true,IsApproved=false,IsFeatured=true, Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. Proin varius arcu metus.", HtmlContent="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-30)},
                    new Product(){ ProductName="Hand Bag", Price=125, Image="product4.jpg",IsHome=true,IsApproved=true,IsFeatured=true, Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. Proin varius arcu metus.", HtmlContent="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-5)},
                    new Product(){ ProductName="Sofa", Price=250, Image="product3.jpg",IsHome=true,IsApproved=true,IsFeatured=true, Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. Proin varius arcu metus.", HtmlContent="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. <b>Proin varius arcu metus.</b>", DateAdded=DateTime.Now.AddDays(-2)},
                };

                context.Products.AddRange(products);

                var categories = new[]
                {
                    new Category(){ CategoryName="Electronics"},
                    new Category(){ CategoryName="Accessories"},
                    new Category(){ CategoryName="Furniture"}
                };

                context.Categories.AddRange(categories);

                var productcategories = new[]
                {
                    new ProductCategory(){ Product=products[0],Category=categories[0]},
                    new ProductCategory(){ Product=products[1],Category=categories[0]},
                    new ProductCategory(){ Product=products[3],Category=categories[2]},
                    new ProductCategory(){ Product=products[2],Category=categories[1]}
                };

                context.AddRange(productcategories);


                var images = new[]
                {
                    new Image(){ ImageName="product1.jpg", Product=products[0]},
                    new Image(){ ImageName="product2.jpg", Product=products[0]},
                    new Image(){ ImageName="product3.jpg", Product=products[0]},
                    new Image(){ ImageName="product4.jpg", Product=products[0]},

                    new Image(){ ImageName="product1.jpg", Product=products[1]},
                    new Image(){ ImageName="product2.jpg", Product=products[1]},
                    new Image(){ ImageName="product3.jpg", Product=products[1]},
                    new Image(){ ImageName="product4.jpg", Product=products[1]},

                    new Image(){ ImageName="product1.jpg", Product=products[2]},
                    new Image(){ ImageName="product2.jpg", Product=products[2]},
                    new Image(){ ImageName="product3.jpg", Product=products[2]},
                    new Image(){ ImageName="product4.jpg", Product=products[2]},

                    new Image(){ ImageName="product1.jpg", Product=products[3]},
                    new Image(){ ImageName="product2.jpg", Product=products[3]},
                    new Image(){ ImageName="product3.jpg", Product=products[3]},
                    new Image(){ ImageName="product4.jpg", Product=products[3]},

                    new Image(){ ImageName="product1.jpg", Product=products[4]},
                    new Image(){ ImageName="product2.jpg", Product=products[4]},
                    new Image(){ ImageName="product3.jpg", Product=products[4]},
                    new Image(){ ImageName="product4.jpg", Product=products[4]},
                };

                context.Images.AddRange(images);

                var attributes = new[]
                {
                    new ProductAttribute(){ Attribute="Display",Value="15.6", Product=products[0]},
                    new ProductAttribute(){ Attribute="Processor",Value="Intel i7", Product=products[0]},
                    new ProductAttribute(){ Attribute="RAM Memory",Value="8 GB", Product=products[0]},
                    new ProductAttribute(){ Attribute="Hard Disk",Value="1 TB", Product=products[0]},
                    new ProductAttribute(){ Attribute="Color",Value="Black", Product=products[0]},

                    new ProductAttribute(){ Attribute="Display",Value="15.6", Product=products[1]},
                    new ProductAttribute(){ Attribute="Processor",Value="Intel i7", Product=products[1]},
                    new ProductAttribute(){ Attribute="RAM Memory",Value="8 GB", Product=products[1]},
                    new ProductAttribute(){ Attribute="Hard Disk",Value="1 TB", Product=products[1]},
                    new ProductAttribute(){ Attribute="Color",Value="Black", Product=products[1]},


                    new ProductAttribute(){ Attribute="Display",Value="15.6", Product=products[2]},
                    new ProductAttribute(){ Attribute="Processor",Value="Intel i7", Product=products[2]},
                    new ProductAttribute(){ Attribute="RAM Memory",Value="8 GB", Product=products[2]},
                    new ProductAttribute(){ Attribute="Hard Disk",Value="1 TB", Product=products[2]},
                    new ProductAttribute(){ Attribute="Color",Value="Black", Product=products[2]},


                    new ProductAttribute(){ Attribute="Display",Value="15.6", Product=products[3]},
                    new ProductAttribute(){ Attribute="Processor",Value="Intel i7", Product=products[3]},
                    new ProductAttribute(){ Attribute="RAM Memory",Value="8 GB", Product=products[3]},
                    new ProductAttribute(){ Attribute="Hard Disk",Value="1 TB", Product=products[3]},
                    new ProductAttribute(){ Attribute="Color",Value="Black", Product=products[3]},


                    new ProductAttribute(){ Attribute="Display",Value="15.6", Product=products[4]},
                    new ProductAttribute(){ Attribute="Processor",Value="Intel i7", Product=products[4]},
                    new ProductAttribute(){ Attribute="RAM Memory",Value="8 GB", Product=products[4]},
                    new ProductAttribute(){ Attribute="Hard Disk",Value="1 TB", Product=products[4]},
                    new ProductAttribute(){ Attribute="Color",Value="Black", Product=products[4]},

                };

                context.Attributes.AddRange(attributes);


                context.SaveChanges();

            }
        }
    }
}
