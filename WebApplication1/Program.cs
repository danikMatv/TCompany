    using BLL.IServices;
    using BLL.Services;
    using DAL.Repository;
    using DALEF.Conc;
    using DALEF.Ct;
    using DALEF.Mapping;
    using DALEF.Models;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.EntityFrameworkCore;

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddDbContext<ImdbContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        options.UseSqlServer(connectionString);
    });
    builder.Services.AddDbContext<R2024Context>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        options.UseSqlServer(connectionString);
    });

    builder.Services.AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(30); // Час життя сесії
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    });

    //Cookie
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    }).AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });



builder.Services.AddAutoMapper(typeof(Program));
    builder.Services.AddAutoMapper(typeof(MovieProfile));
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IGoodsService, GoodsService>();
    builder.Services.AddScoped<IUsers, UsersDalEf>();
    builder.Services.AddScoped<IGoods, GoodsDalEf>();
builder.Services.AddScoped<IManagersService, ManagersService>();
builder.Services.AddScoped<IManagers,ManagersDalEf>();
    
builder.Services.AddControllersWithViews();

    var app = builder.Build();

    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseSession();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Account}/{action=Login}/{id?}");

    app.Run();
