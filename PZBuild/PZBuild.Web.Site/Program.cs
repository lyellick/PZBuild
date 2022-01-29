using Microsoft.EntityFrameworkCore;
using PZBuild.Common.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PZBuildContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
