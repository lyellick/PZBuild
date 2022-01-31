using Microsoft.EntityFrameworkCore;
using PZBuild.Common.Data;
using PZBuild.Common.Repositories;
using PZBuild.Common.Repositories.IRepositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PZBuildContext>(options => options.UseSqlServer(connection));

builder.Services
    .AddScoped<IOccupationRepository, OccupationRepository>()
    .AddScoped<IOccupationSkillRepository, OccupationSkillRepository>()
    .AddScoped<ISkillRepository, SkillRepository>()
    .AddScoped<ITraitRepository, TraitRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
