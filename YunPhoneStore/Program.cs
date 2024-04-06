using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanBichVanPS28709_ASM.DataAccess;
using QuanBichVanPS28709_ASM.DataAccess.Base;
using QuanBichVanPS28709_ASM.DataAccess.DataAccessImp;
using QuanBichVanPS28709_ASM.MappingProfiles;
using QuanBichVanPS28709_ASM.Services;
using QuanBichVanPS28709_ASM.Services.ServiceImp;
using Utility.IdentityHandler;
using Microsoft.AspNetCore.Identity;
using Persistence.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
//using Persistence.DbInitializer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("test")));

//builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
//options.SignIn.RequireConfirmedAccount = true)
//    .AddRoles<ApplicationUser>()
//    .AddEntityFrameworkStores<ApplicationDbContext>();
//Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

// đăng ký service cho productRepo và ProductService
//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();

builder.Services.AddDefaultIdentity<ApplicationUser>(option =>
option.SignIn.RequireConfirmedAccount = false)
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartRepo, CartRepo>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddMvc()
        .AddSessionStateTempDataProvider();
builder.Services.AddSession();
SetRolePolicy(builder.Services);

//ModelBuilderExtensions.Seed()

builder.Services.AddRazorPages();
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new ProductProfile()); 
    mc.AddProfile(new CategoryProfile()); 
    mc.AddProfile(new CartProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "HomeDefault",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "HomeDefault",
    pattern: "{area=admin}/{controller=Home}/{action=Index}/{id?}");
//app.MapControllerRoute(
//    name: "HomeAdmin",
//    pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
//seed data
//void SeedDatas()
//{
//    using var scope = app.Services.CreateScope();
//    var dbInitilizer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
//    dbInitilizer.Initialize();
//}

void SetRolePolicy(IServiceCollection services)
{
    services.AddAuthorization(options =>
    {
        options.AddPolicy("RequiredAdmin", policy => policy.RequireClaim("admin"));
        //options.AddPolicy("RequiredAdmin", policy => policy.RequireClaim("admin"));
    });
}
app.Run();
