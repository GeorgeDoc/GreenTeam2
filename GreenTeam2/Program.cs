//using PetShop.EF.Context;
//using PetShop.Model;



//var customer = new Customer()
//{
//    Name = "John",
//    Surname = "polyc",
//    Phone = 1234567890,
//    TIN = "123456789"
//};

//var context = new PetShopContext();
//context.Customers.Add(customer);
//context.SaveChanges();



//var pet = new Pet()
//{
//    Breed = "Breed",
//    AnimalType = AnimalType.Mammal,
//    PetStatus = PetStatus.OK,
//    Price = 50,
//    Cost = 40
//};
//context.Pets.Add(pet);
//context.SaveChanges();


//var petFood = new PetFood()
//{
//    AnimalType = AnimalType.Mammal,
//    Price = 5.5m,
//    Cost = 4.4m
//};

//context.PetFoods.Add(petFood);
//context.SaveChanges();

//var emp = new Employee()
//{
//    Name = "JohnEMP",
//    Surname = "polyc",
//    SallaryPerMonth = 400,
//    EmployeeType = EmployeeType.Manager
//};

//context.Employees.Add(emp);
//context.SaveChanges();

//int x = 2;
//var trans = new Transaction()
//{
//    Customer = customer,
//    Employee = emp,
//    Pet = pet,
//    PetFood= petFood,

//    PetFoodQty = x,
//    PetFoodPrice = petFood.Price * x,
//    TotalPrice = petFood.Price + pet.Price,
//    PetPrice = pet.Price

//};

//context.Transactions.Add(trans);
//context.SaveChanges();





//context.Transactions.Remove(trans);
//context.SaveChanges();











var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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





