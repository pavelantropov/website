var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseExceptionHandler("/error");
app.UseHsts();
app.UseStaticFiles();
app.MapGet("/error", () => Results.Problem("Произошла непредвиденная ошибка."));
app.MapFallbackToFile("index.html");

app.Run();
