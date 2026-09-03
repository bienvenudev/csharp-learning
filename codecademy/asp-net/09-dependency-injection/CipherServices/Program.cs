using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using CipherServices.Data;
using CipherServices.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register new services here.
builder.Services.AddDbContext<MessageContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MessageContext")));
  
builder.Services.AddTransient<IDecrypter, Decrypter>();
builder.Services.AddTransient<IEncrypter, Encrypter>();

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var context =  serviceScope.ServiceProvider.GetRequiredService<MessageContext>();
    DbInitializer.Initialize(context);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();