using FormForTestWithMongo.DbContext;
using MongoDB.Bson;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

//Mongo CONNECTION //
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString == null)
{
    Environment.Exit(0);
}
var settings = MongoClientSettings.FromConnectionString(connectionString);
settings.ServerApi = new ServerApi(ServerApiVersion.V1);
var client = new MongoClient(settings);

try
{
    var db = client.GetDatabase("Users");

    builder.Services.AddScoped<FormDbContext>(sp =>
        FormDbContext.Create(db)
    );
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}


// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Index}/{id?}");

app.Run();
