using ForumWebApp.Data;
using ForumWebApp.Models;

public class Seed
{
    public static void SeedData(IApplicationBuilder applicationBuilder)
    {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

        context.Database.EnsureCreated();

        if (!context.Studios.Any())
        {
            var studio1 = new Studio
            {
                Name = "Valve",
                Address = new Address { City = "Seattle", Country = "USA" }
            };
            var studio2 = new Studio
            {
                Name = "CD Projekt",
                Address = new Address { City = "Warsaw", Country = "Poland" }
            };

            context.Studios.AddRange(studio1, studio2);
            context.SaveChanges();
        }

        if (!context.Categories.Any())
        {
            context.Categories.AddRange(
                new Category { Name = "Action" },
                new Category { Name = "Strategy" },
                new Category { Name = "RPG" }
            );
            context.SaveChanges();
        }

        if (!context.Products.Any())
        {
            var valveStudio = context.Studios.FirstOrDefault(s => s.Name == "Valve");
            var actionCategory = context.Categories.FirstOrDefault(c => c.Name == "Action");
            var strategyCategory = context.Categories.FirstOrDefault(c => c.Name == "Strategy");

            var product = new Product
            {
                Name = "Red Alert 2",
                Image = "https://images.app.goo.gl/EWGFbEBorUcMV8hp8",
                Stars = 5,
                Date = new DateTime(2004, 11, 16),
                Description = "A legendary FPS game.",
                Studio = valveStudio,
                ProductCategories = new List<ProductCategory>()
                {
                    new ProductCategory { Category = actionCategory },
                    new ProductCategory { Category = strategyCategory }
                }
            };

            context.Products.Add(product);
            context.SaveChanges();
        }

        if (!context.AppUsers.Any())
        {
            context.AppUsers.Add(new AppUser
            {
                UserName = "Gordon Freeman"
            });
            context.SaveChanges();
        }

        if (!context.Comments.Any() && !context.Reviews.Any())
        {
            var user = context.AppUsers.First();
            var product = context.Products.First();

            var comment = new Comment
            {
                Title = "Amazing Game",
                Content = "Still holds up!",
                AppUserId = user.Id 
            };

            context.Comments.Add(comment);
            context.SaveChanges(); 

            var review = new Review
            {
                CommentId = comment.Id,
                ProductId = product.Id
            };

            context.Reviews.Add(review);
            context.SaveChanges();
        }
    }
}
