using DI.Interfaces.Tests.Integrations.Managers;
using DI.Interfaces.Tests.Interfaces;
using DI.Interfaces.Tests.Manager;
using DI.Interfaces.Tests.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped(typeof(IBaseManager<,,>), typeof(BaseManager<,,>)); // <<< For abstract implementations
builder.Services.AddScoped<ISalesChannelRepository, SalesChannelRepository>();
builder.Services.AddScoped<IPublicationRepository, PublicationRepository>();

builder.Services.AddScoped<IntegrationManager>();
builder.Services.AddScoped<IPublicationManager, PublicationManager>();
builder.Services.AddScoped<ISalesChannelManager, SalesChannelManager>();

builder.Services.AddScoped<AmazonManager>();
builder.Services.AddScoped<MercadolibreManager>();
builder.Services.AddScoped<ShopifyManager>();
builder.Services.AddScoped<IntegrationManager>();

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

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
