using ForumWebApp.Data;
using ForumWebApp.Interfaces;
using ForumWebApp.Models;
using ForumWebApp.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ForumWebApp.Interfaces.ICategoryRepository, ForumWebApp.Repository.CategoryRepository>();
builder.Services.AddScoped<ForumWebApp.Interfaces.IProductRepository, ForumWebApp.Repository.ProductRepository>();
builder.Services.AddScoped<ForumWebApp.Interfaces.IStudioRepository, ForumWebApp.Repository.StudioRepository>();
builder.Services.AddScoped<ForumWebApp.Interfaces.IAppUserRepository, ForumWebApp.Repository.AppUserRepository>();
builder.Services.AddScoped<ForumWebApp.Interfaces.ICommentRepository, ForumWebApp.Repository.CommentRepository>();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    await Seed.SeedUsersAndRolesAsync(app);
    //Seed.SeedData(app);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

