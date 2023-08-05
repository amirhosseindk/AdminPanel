using AdminPanel.IServices;
using AdminPanel.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddHttpClient("MyHttpClientWithHeaders", c =>
{
    c.DefaultRequestHeaders.Add(".",".");
});
builder.Services.AddScoped<IBlogPostService, BlogPostService>();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();
builder.Services.AddScoped<IAirplaneService, AirplaneService>();
builder.Services.AddScoped<IBODService, BODService>();
builder.Services.AddScoped<ITextService, TextService>();
builder.Services.AddScoped<ISliderService, SliderService>();
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