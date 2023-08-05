using AdminPanel;
using AdminPanel.IServices;
using AdminPanel.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDbForTesting"));
builder.Services.AddDefaultIdentity<ApplicationUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddHttpClient("MyHttpClientWithHeaders", c =>
{
    c.DefaultRequestHeaders.Add("api-key", ".");
});
builder.Services.AddScoped<IBlogPostService, BlogPostService>();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();
builder.Services.AddScoped<IAirplaneService, AirplaneService>();
builder.Services.AddScoped<IBODService, BODService>();
builder.Services.AddScoped<ITextService, TextService>();
builder.Services.AddScoped<ISliderService, SliderService>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login";
});

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    var defaultUser = new ApplicationUser { UserName = ".", Email = "." };
    if (context.Users.All(u => u.Id != defaultUser.Id))
    {
        var result = await userManager.CreateAsync(defaultUser, ".");
        if (!result.Succeeded)
        {
            throw new Exception(string.Join("\n", result.Errors));
        }
    }
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.Run();