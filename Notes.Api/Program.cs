using Microsoft.EntityFrameworkCore;
using Notes.Api.Data;
using Notes.Api.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Version = "v1",
        Title = "NoteApi",
        Description = "Note test",
    });
});

//Изменить при полноценном использовании
builder.Services.AddDbContext<ApiDbContext>(options => options.UseInMemoryDatabase("MEMORY"));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(options =>
    {
        options.RoutePrefix = string.Empty;
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var scope = app.Services.CreateScope();


    ApiDbObject.Initial(scope.ServiceProvider.GetService<ApiDbContext>());


app.Run();
