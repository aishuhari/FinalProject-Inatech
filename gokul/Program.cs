using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using gokul.Areas.Identity.Data;
using Microsoft.Extensions.DependencyInjection;
using gokul.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<gokulContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("gokulContext") ?? throw new InvalidOperationException("Connection string 'gokulContext' not found.")));
var connectionString = builder.Configuration.GetConnectionString("DatagokulContextConnection") ?? throw new InvalidOperationException("Connection string 'DatagokulContextConnection' not found.");

builder.Services.AddDbContext<DatagokulContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<gokulUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DatagokulContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
