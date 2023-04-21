using BLOG.Data;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddDbContext<User>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDB")));

builder.Services.AddDbContext<Creator>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDB")));

builder.Services.AddDbContext<Content>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDB")));

builder.Services.AddDbContext<Comments>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDB")));

builder.Services.AddDbContext<UserPostLikes>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDB")));
builder.Services.AddDbContext<UT>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDB")));






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

app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
