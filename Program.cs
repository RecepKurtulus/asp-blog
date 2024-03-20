using BuffBlog.Data.Abstract;
using BuffBlog.Data.Concrete;
using BuffBlog.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Viewler ile controllerların eşleşmesini sağladık
builder.Services.AddControllersWithViews();
// Veritabanı bağlantı yapılandırmasını eklemek için hizmet koleksiyonuna bir DbContext ekle
builder.Services.AddDbContext<BlogContext>(
    options => {
        // Konfigürasyon ayarlarına erişim sağla
        var config = builder.Configuration;
        // Bağlantı dizgisini konfigürasyon dosyasından al
        var connectionString = config.GetConnectionString("postgresql_connection");
        // SQLite veritabanını kullanacak şekilde DbContext seçeneklerini yapılandır
        options.UseNpgsql(connectionString);
    }
);
builder.Services.AddScoped<IPostRepository,EfPostRepository>();
builder.Services.AddScoped<ITagRepository,EfTagsRepository>();
//IPostRepository,EfPostRepository'i kullanmamızı sağlıyor.
var app = builder.Build();
SeedData.FillTestData(app);
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();