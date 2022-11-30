using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stripe;
using Stripe.Issuing;
using SubUrbanClothes.Database;
using SubUrbanClothes.Services;
using SubUrbanClothes.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SubUrbanClothesDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<SubUrbanClothesDbContext>();

// Add services to the container.
builder.Services.AddSingleton<ChargeService>(new ChargeService());
builder.Services.AddSingleton<TransactionService>(new TransactionService());

builder.Services.AddControllersWithViews();

StripeConfiguration.SetApiKey(builder.Configuration["Stripe:TestSecretKey"]);
//StripeConfiguration.ApiKey = builder.Configuration["Stripe:TestSecretKey"];

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddDistributedMemoryCache();

builder.Services.Configure<CookiePolicyOptions>(o =>
{
    o.CheckConsentNeeded = context => false;
    o.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

//app.UseMvc();
//app.Run(context => {
//    return context.Response.WriteAsync("Hello World!");
//});
