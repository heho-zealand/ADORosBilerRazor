using ADORosBilerRazor.Repositories;
using ADORosBilerRazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<DBServiceBil>();
builder.Services.AddScoped<DBServiceKunde>();
builder.Services.AddScoped<BilRepo>();
builder.Services.AddScoped<KundeRepo>();
builder.Services.AddScoped<UIServiceBiler>();
builder.Services.AddScoped<UIServiceKunder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
