using LolHolmes.Core;
using LolHolmes.Infrastructure;
using LolHolmes.UI.Pages.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddSingleton(_ => Factories.CreateAccountRepository());
builder.Services.AddSingleton(_ => Factories.CreateNameRepository());
builder.Services.AddSingleton(_ => Factories.CreateImageRepository());

builder.Services.AddScoped<MainViewModel>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(LolHolmes.UI.Pages._Imports).Assembly);

app.UseStaticFiles();
app.Run();
