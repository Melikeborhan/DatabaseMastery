using DatabseMastery.TransportMongoDb.Services.BrandServices;
using DatabseMastery.TransportMongoDb.Services.SliderServices;
using DatabseMastery.TransportMongoDb.Services.OfferServices;
using DatabseMastery.TransportMongoDb.Services.AboutServices;
using DatabseMastery.TransportMongoDb.Settings;
using Microsoft.Extensions.Options;
using System.Reflection;
using DatabseMastery.TransportMongoDb.Services.GetInTouchServices;
using DatabseMastery.TransportMongoDb.Services.HowItWorksServices;
using DatabseMastery.TransportMongoDb.Services.TestimonialServices;
using DatabseMastery.TransportMongoDb.Services.ProjectSectionServices;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IGetInTouchService, GetInTouchService>();
builder.Services.AddScoped<IHowItWorksServices, HowItWorksServices>();
builder.Services.AddScoped<ITestimonialServices, TestimonialServices>();
builder.Services.AddScoped<IProjectSectionService, ProjectSectionService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());



builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettingsKey"));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});


// Add services to the container.
builder.Services.AddControllersWithViews();

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
