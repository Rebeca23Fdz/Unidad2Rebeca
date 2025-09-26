var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

var app = builder.Build();

app.UseDeveloperExceptionPage();

app.MapDefaultControllerRoute();
app.UseStaticFiles();

app.Run();
