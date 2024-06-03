using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VendasWebAplication.Data;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using VendasWebAplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicione os serviços ao container.
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // Esta lambda determina se é necessário o consentimento do usuário para cookies não essenciais para uma determinada solicitação.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

// Configure o DbContext para usar MySQL
builder.Services.AddDbContext<VendasWebAplicationContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("VendasWebAplicationContext"), new MySqlServerVersion(new Version(8, 0, 23))));

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure o pipeline de solicitação HTTP.
var enUS = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(enUS),
    SupportedCultures = new List<CultureInfo> { enUS },
    SupportedUICultures = new List<CultureInfo> { enUS }
};

app.UseRequestLocalization(localizationOptions);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // O valor padrão de HSTS é de 30 dias. Você pode querer mudar isso para cenários de produção, veja https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Crie um escopo de serviços e chame o método Seed
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var seedingService = services.GetRequiredService<SeedingService>();
        seedingService.Seed();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocorreu um erro ao popular a base de dados.");
    }
}

app.Run();
