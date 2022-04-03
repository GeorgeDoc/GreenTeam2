
using PetShop.EF.Context;
using PetShop.EF.MockRepositories;
using PetShop.EF.Repositories;
using PetShop.Model;

var customer = new Customer()
{
    Name = "Jhon",
    Surname = "p",
    TIN = "123456789",
    Phone = 1234567890
};

var dbContext = new PetShopContext();
var repo = new CustomerRepo(dbContext);
await repo.AddAsync(customer);






var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PetShopContext>();
builder.Services.AddSingleton<IEntityRepo<PetFood>, MockPetFoodRepo>();

//builder.Services.AddScoped<IEntityRepo<PetFood>, PetFoodRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
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

app.Run();
