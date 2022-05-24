using Microsoft.EntityFrameworkCore;
using SanaWebTest.Storage;
using SanaWebTest.Storage.EFSqlServer;
using SanaWebTest.Storage.EFSqlServer.Repository;
using SanaWebTest.Storage.Entities;
using SanaWebTest.Storage.InMemory;
using SanaWebTest.Storage.InMemory.Repository;
using SanaWebTest.Storage.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

Console.WriteLine("Tests");


//Register for dynamic storage
builder.Services
    .StorageConfigure(typeof(IMemoryRepository<>), typeof(IEFSqlServerRepository<>)) //Add type of Storage to use (Allways the first is the default storage type)
    .ConfigureMemoryStorage() //Configure initial database memory storage
    .ConfigureEntityFrameworkSqlServer<SanaTestDbContext>("name=ConnectionStrings:SqlServerDefault", typeof(SanaTestEFRepository<>)); //Configure Entity Framework Storage (The database name must exists)



var app = builder.Build();

#region Automatic migration
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SanaTestDbContext>();
    if(dbContext !=null)
    {
        dbContext.Database.Migrate();
    }
}
#endregion

#region Seed Memory Storage
var memoryCategoryRepo = app.Services.GetService<IMemoryRepository<Category>>();
if(memoryCategoryRepo != null)
{
    memoryCategoryRepo.Insert(new Category()
    {
        Name = "Category Memory Storage 1",
    });
    memoryCategoryRepo.Insert(new Category()
    {
        Name = "Category Memory Storage 2",
    });

}

#endregion

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
