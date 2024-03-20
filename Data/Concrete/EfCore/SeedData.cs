using Microsoft.EntityFrameworkCore;

namespace BuffBlog.Data.Concrete.EfCore
{
    public class SeedData
    {
        public static void FillTestData(IApplicationBuilder app){
            var context=app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();
            if(context!=null){
                if(context.Database.GetPendingMigrations().Any()){
                    context.Database.Migrate();
                }
                if(!context.Tags.Any()){
                    context.Tags.AddRange(
                        new Entity.Tag {TText="Oyun"},
                        new Entity.Tag {TText="Dizi"},
                        new Entity.Tag {TText="Film"}

                    );
                    context.SaveChanges();
                }
                if(!context.Users.Any()){
                    context.Users.AddRange(
                        new Entity.User {
                            UserId=1,
                            UserName="Recep",
                            UserMail="Recep@gmail.com",
                            UserPosts=context.Posts.Take(2).ToList(),
                            
                        }

                    );
                    context.SaveChanges();
                }
                if(!context.Posts.Any()){
                    context.Posts.AddRange(
                        new Entity.Post {
                            PostId=1,
                            PTitle="Diablo 4 nasıl olmuş? Yıllardır beklediğimize değdi mi?",
                            PIsActive=true,
                            PContent="Yayıncılığını ve geliştiricliğini Blizzard'ın yaptığı Diablo serisinin yeni oyunu 6 Haziran'da çıkışını yapacak. Biz de oyunu artı ve eksileriyle bu videoda konuştuk. Özellikle direkt olarak inceleme tarzında olmasını istemedik çünkü oyunun geçtiğimiz aylarda birkaç kez betası oyuncuların erişimine açıldı. Bu yüzden daha çok artı ve eksileriyle değerlendirdik.Diablo IV Windows®PC, Xbox Series X|S, Xbox One, PlayStation®5 ve PlayStation 4'te üzerinden Türkçe dil desteği ile birlikte oynanabilir olacak.",
                            PPublishedOn=DateTime.UtcNow.AddDays(-10),
                            Tags= context.Tags.Take(1).ToList(),
                            UserId=1, 
                        },
                        new Entity.Post {
                            PostId=2,
                            PTitle="The Witcher 3'ün yeni nesil güncellemesi nasıl olmuş? Oyuna dönmeye değer mi? ",
                            PIsActive=true,
                            PContent="Yayıncılığını ve geliştiriciliğini CD Projekt Red'in yaptığı The Witcher 3 Wild Hunt'ın yeni nesil güncellemesi PS5, Xbox Series ve PC için çıkışını yaptı. Peki bu güncelleme nasıl olmuş oyuna dönmeye değer mi? Bu videomuzda bunu tartışıyoruz.The Witcher 3 çıkıtğı yıldan bu yana sürekli konuşulan ve oyun dünyasına adını altın harflarle yazdıran bir oyun. Yeni nesil güncellemesiyle birlikte oyunun değiştiği en büyük bölüm yansımalar. İyileştirilmiş ayrıntılar, daha hızlı yükleme süreleri, topluluk tarafından üretilmiş ve oyun için yeni geliştirilmiş sayısız mod, gerçek zamanlı ışın izleme (ray tracing) ve çok daha fazlasını içeren birçok görsel ve teknik iyileştirmelerle dolu bir güncelleme. Ancak ne yazık ki performans anlamında şu anda bir sorun olduğunu söyleyebiliriz. Tüm bu detayları ve daha fazlasını da videomuzda tartışıyoruz. Bu güncellemenin oyuna sahip olanlara ücretsiz olarak sunulduğunu da belirtelim.",
                            PPublishedOn=DateTime.UtcNow.AddDays(-8),
                            Tags= context.Tags.Take(1).ToList(),
                            UserId=1, 
                        }

                    );
                    context.SaveChanges();
                }
            }
        }
    }
}