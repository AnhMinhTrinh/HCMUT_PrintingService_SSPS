using Printing_Service.Data;
using Microsoft.AspNetCore.Session;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Set session timeout as needed
    options.Cookie.HttpOnly = true;  // Only accessible via HTTP requests
    options.Cookie.IsEssential = true;  // Makes the cookie essential for session state
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<StudentData>();

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

app.UseSession();

app.UseRouting();



app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
