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
                Name = "EA",
                Address = new Address { City = "California", Country = "USA" }
            };
            var studio2 = new Studio
            {
                Name = "Valve",
                Address = new Address { City = "Seattle", Country = "USA" }
            };
            var studio3 = new Studio
            {
                Name = "Scottgames",
                Address = new Address { City = "Texas", Country = "USA" }
            };
            var studio4 = new Studio
            {
                Name = "11 Bit Studios",
                Address = new Address { City = "Warsaw", Country = "Poland" }
            };
            var studio5 = new Studio
            {
                Name = "Treyarch ",
                Address = new Address { City = "Los Angeles", Country = "USA" }
            };

            context.Studios.AddRange(studio1, studio2, studio3, studio4, studio5);
            context.SaveChanges();
        }

        if (!context.Categories.Any())
        {
            context.Categories.AddRange(
                new Category { Name = "Action",Image = "" },
                new Category { Name = "Strategy", Image = "" },
                new Category { Name = "RPG", Image = "" },
                new Category { Name = "Horror", Image = "" },
                new Category { Name = "FPS", Image = "" },
                new Category { Name = "Adventure", Image = "" },
                new Category { Name = "Simulation", Image = "" },
                new Category { Name = "Singleplayer", Image = "" },
                new Category { Name = "Co-op", Image = "" },
                new Category { Name = "Multiplayer", Image = "" }
            );
            context.SaveChanges();
        }

        if (!context.Products.Any())
        {
            var valveStudio = context.Studios.FirstOrDefault(s => s.Name == "Valve");
            var EAStudio = context.Studios.FirstOrDefault(s => s.Name == "EA");
            var scottGamesStudio = context.Studios.FirstOrDefault(s => s.Name == "ScottGames");
            var bitStudio = context.Studios.FirstOrDefault(s => s.Name == "11 Bit Studios");
            var treyarchStudio = context.Studios.FirstOrDefault(s => s.Name == "Treyarch");

            var actionCategory = context.Categories.FirstOrDefault(c => c.Name == "Action");
            var strategyCategory = context.Categories.FirstOrDefault(c => c.Name == "Strategy");
            var RPGCategory = context.Categories.FirstOrDefault(c => c.Name == "RPG");
            var HorrorCategory = context.Categories.FirstOrDefault(c => c.Name == "Horror");
            var FPSCategory = context.Categories.FirstOrDefault(c => c.Name == "FPS");
            var AdventureCategory = context.Categories.FirstOrDefault(c => c.Name == "Adventure");
            var SimulationCategory = context.Categories.FirstOrDefault(c => c.Name == "Simulation");
            var SingleplayerCategory = context.Categories.FirstOrDefault(c => c.Name == "Singleplayer");
            var CoopCategory = context.Categories.FirstOrDefault(c => c.Name == "Co-op");
            var MultiplayerCategory = context.Categories.FirstOrDefault(c => c.Name == "Multiplayer");


            var product1 = new Product
            {
                Name = "Red Alert 2",
                Image = "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/2229850/header.jpg?t=1738077874",
                Stars = 4.7F,
                Date = new DateTime(2000, 10, 24),
                Description = "A legendary Strategy game.",
                Studio = EAStudio,
                ProductCategories = new List<ProductCategory>()
                {
                    new ProductCategory { Category = MultiplayerCategory },
                    new ProductCategory { Category = actionCategory },
                    new ProductCategory { Category = strategyCategory }
                }
            };
            var product2 = new Product
            {
                Name = "Red Alert 3",
                Image = "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/17480/header.jpg?t=1741704738",
                Stars = 3.2F,
                Date = new DateTime(2008, 10, 30),
                Description = "A legendary Strategy game.",
                Studio = EAStudio,
                ProductCategories = new List<ProductCategory>()
                {
                    new ProductCategory { Category = MultiplayerCategory },
                    new ProductCategory { Category = actionCategory },
                    new ProductCategory { Category = strategyCategory }
                }
            };
            var product3 = new Product
            {
                Name = "Sims 4",
                Image = "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/1222670/header.jpg?t=1749122165",
                Stars = 4.7F,
                Date = new DateTime(2014, 9, 2),
                Description = "A legendary Strategy game.",
                Studio = EAStudio,
                ProductCategories = new List<ProductCategory>()
                {
                    new ProductCategory { Category = SimulationCategory },
                    new ProductCategory { Category = RPGCategory},
                    new ProductCategory { Category = SingleplayerCategory }
                }
            };
            var product4 = new Product
            {
                Name = "Plants VS Zomies",
                Image = "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/3590/header.jpg?t=1738970324",
                Stars = 4F,
                Date = new DateTime(2009, 5, 5),
                Description = "A legendary Strategy game.",
                Studio = EAStudio,
                ProductCategories = new List<ProductCategory>()
                {
                    new ProductCategory { Category = SingleplayerCategory },
                    new ProductCategory { Category = actionCategory },
                    new ProductCategory { Category = strategyCategory }
                }
            };
            var product5 = new Product
            {
                Name = "Five Nights at Freddy's",
                Image = "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/319510/header.jpg?t=1666889251",
                Stars = 4.3F,
                Date = new DateTime(2014, 8, 8),
                Description = "A legendary Horror game.",
                Studio = scottGamesStudio,
                ProductCategories = new List<ProductCategory>()
                {
                    new ProductCategory { Category = HorrorCategory},
                    new ProductCategory { Category = SingleplayerCategory }
                }
            };
            var product6 = new Product
            {
                Name = "Five Nights at Freddy's 2",
                Image = "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/332800/header.jpg?t=1579635993",
                Stars = 4.1F,
                Date = new DateTime(2014, 10, 11),
                Description = "A legendary Horror game.",
                Studio = scottGamesStudio,
                ProductCategories = new List<ProductCategory>()
                {
                    new ProductCategory { Category = HorrorCategory},
                    new ProductCategory { Category = SingleplayerCategory }
                }
            };
            var product7 = new Product
            {
                Name = "Help Wanted",
                Image = "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/732690/header.jpg?t=1686587846",
                Stars = 4.5F,
                Date = new DateTime(2019, 5, 28),
                Description = "A legendary Horror game.",
                Studio = scottGamesStudio,
                ProductCategories = new List<ProductCategory>()
                {
                    new ProductCategory { Category = HorrorCategory},
                    new ProductCategory { Category = SingleplayerCategory }
                }
            };
            var product8 = new Product
            {
                Name = "This War of Mine",
                Image = "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/282070/header.jpg?t=1749488980",
                Stars = 4.7F,
                Date = new DateTime(2014, 11, 14),
                Description = "A legendary RPG game.",
                Studio = bitStudio,
                ProductCategories = new List<ProductCategory>()
                {
                    new ProductCategory { Category = AdventureCategory },
                    new ProductCategory { Category = SingleplayerCategory },
                    new ProductCategory { Category = RPGCategory },
                    new ProductCategory { Category = strategyCategory }
                }
            };
            var product9 = new Product
            {
                Name = "Frostpunk",
                Image = "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/323190/203e8dc8347b10d3c7ccac604ce3d58f6c7cecaf/header_alt_assets_4_turkish.jpg?t=1748439240",
                Stars = 4.5F,
                Date = new DateTime(2018, 4, 24),
                Description = "A legendary RPG game.",
                Studio = bitStudio,
                ProductCategories = new List<ProductCategory>()
                {
                    new ProductCategory { Category = AdventureCategory },
                    new ProductCategory { Category = SingleplayerCategory },
                    new ProductCategory { Category = RPGCategory },
                    new ProductCategory { Category = strategyCategory }
                }
            };
            var product10 = new Product
            {
                Name = "Black Ops 2",
                Image = "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/202970/header.jpg?t=1748037715",
                Stars = 4.5F,
                Date = new DateTime(2012, 11, 11),
                Description = "A legendary RPG game.",
                Studio = treyarchStudio,
                ProductCategories = new List<ProductCategory>()
                {
                    new ProductCategory { Category = actionCategory },
                    new ProductCategory { Category = FPSCategory },
                    new ProductCategory { Category = MultiplayerCategory }
                }
            };
            var product11 = new Product
            {
                Name = "Modern Warfare",
                Image = "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/2000950/header.jpg?t=1678294805",
                Stars = 4.5F,
                Date = new DateTime(2019, 10, 24),
                Description = "A legendary RPG game.",
                Studio = treyarchStudio,
                ProductCategories = new List<ProductCategory>()
                {
                    new ProductCategory { Category = actionCategory },
                    new ProductCategory { Category = FPSCategory },
                    new ProductCategory { Category = MultiplayerCategory }
                }
            };
            var product12 = new Product
            {
                Name = "Portal",
                Image = "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/400/header.jpg?t=1745368554",
                Stars = 4.5F,
                Date = new DateTime(2007, 10, 10),
                Description = "A legendary RPG game.",
                Studio = valveStudio,
                ProductCategories = new List<ProductCategory>()
                {
                    new ProductCategory { Category = AdventureCategory },
                    new ProductCategory { Category = CoopCategory },
                    new ProductCategory { Category = strategyCategory }
                }
            };

            context.Products.AddRange(product1, product2, product3, product4, product5, product6, product7, product8, product9, product10, product11, product12);
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
