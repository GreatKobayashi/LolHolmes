using LolHolmes.Domain;
using LolHolmes.Infrastructure;
using LolHolmes.UI.Pages;
using LolHolmes.UI.Pages.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddSingleton(_ => Factories.CreateAccountRepository(Shared.ApiKey));
builder.Services.AddSingleton(_ => Factories.CreateNameRepository(Shared.ApiKey));

builder.Services.AddSingleton<HomeViewModel>();

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
    .AddInteractiveServerRenderMode();

app.Run();
