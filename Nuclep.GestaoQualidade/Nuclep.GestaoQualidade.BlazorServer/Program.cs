using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddRadzenComponents();

builder.Services.AddServerSideBlazor();
builder.Services.AddHttpContextAccessor();



//Configuração para API principal a ser consumida
builder.Services.AddScoped(x => new HttpClient { BaseAddress = new Uri("http://localhost:5175/") });  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


app.Run();
