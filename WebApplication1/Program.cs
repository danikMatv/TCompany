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

    // Налаштування підключення до бази даних
    builder.Services.AddDbContext<ImdbContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        options.UseSqlServer(connectionString);  // Налаштування бази даних через DI
    });// Рекомендується реєструвати лише один контекст:
    builder.Services.AddDbContext<R2024Context>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        options.UseSqlServer(connectionString);  // Налаштування підключення до бази даних через DI
    });


    // Додавання служб для сесій
    builder.Services.AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(30); // Час життя сесії
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    });

    // Налаштування аутентифікації з використанням Cookie
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    }).AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });


    // Додавання AutoMapper
    builder.Services.AddAutoMapper(typeof(Program));
    builder.Services.AddAutoMapper(typeof(MovieProfile));
    // Реєстрація залежностей
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IGoodsService, GoodsService>();
    builder.Services.AddScoped<IUsers, UsersDalEf>();
    builder.Services.AddScoped<IGoods, GoodsDalEf>();

    // Додавання MVC
    builder.Services.AddControllersWithViews();

    var app = builder.Build();

    // Конфігурація Middleware
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    // Використання аутентифікації та сесій
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseSession();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Account}/{action=Login}/{id?}");

    app.Run();
