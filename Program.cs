using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proiect_Medii_Programare.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});
// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Rezervări");
    options.Conventions.AllowAnonymousToPage("/Rezervări/Index");
    options.Conventions.AllowAnonymousToPage("/Rezervări/Details");
    options.Conventions.AuthorizeFolder("/Specii");
    options.Conventions.AllowAnonymousToPage("/Specii/Index");
    options.Conventions.AllowAnonymousToPage("/Specii/Details");
    options.Conventions.AuthorizeFolder("/Servicii");
    options.Conventions.AllowAnonymousToPage("/Servicii/Index");
    options.Conventions.AllowAnonymousToPage("/Servicii/Details");
    options.Conventions.AuthorizeFolder("/Camere");
    options.Conventions.AllowAnonymousToPage("/Camere/Index");
    options.Conventions.AllowAnonymousToPage("/Camere/Details");
    options.Conventions.AuthorizeFolder("/Membri", "AdminPolicy");
});

builder.Services.AddDbContext<Proiect_Medii_ProgramareContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect_Medii_ProgramareContext") ?? throw new InvalidOperationException("Connection string 'Proiect_Medii_ProgramareContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect_Medii_ProgramareContext") ?? throw new InvalidOperationException("Connection string 'Proiect_Medii_ProgramareContext' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
 .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configurează pipeline-ul pentru cererile HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
