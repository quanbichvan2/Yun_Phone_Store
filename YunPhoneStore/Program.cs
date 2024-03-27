using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistence;
using QuanBichVanPS28709_ASM.DataAccess;
using QuanBichVanPS28709_ASM.DataAccess.Base;
using QuanBichVanPS28709_ASM.DataAccess.DataAccessImp;
using QuanBichVanPS28709_ASM.MappingProfiles;
using QuanBichVanPS28709_ASM.Services;
using QuanBichVanPS28709_ASM.Services.ServiceImp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("test")));

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

// đăng ký service cho productRepo và ProductService
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IProductService, ProductService>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new ProductProfile());
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
