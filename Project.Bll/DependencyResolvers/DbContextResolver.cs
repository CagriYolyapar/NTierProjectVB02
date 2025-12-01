using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Dal.ContextClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DependencyResolvers
{
    //Extension metodumuz olan AddDbContextService icin bir static class actık...
    public static class DbContextResolver
    {
        //Todo : Manager sistemi hazırlama aşamasında kaldık...
        public static void AddDbContextService(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider(); //Servis saglayıcınız sizin farklı assembly'lerdeki configuration yapılarını tanımlamanız icin ihtiyacınız olan bir tiptir...

            IConfiguration configuration = provider.GetRequiredService<IConfiguration>(); //görüldügü üzere yukarıda build edilmiş olan tipiniz sayesinde elinize bir IConfiguration tipi gecer ve bu sayede siz ConnectionString'e ulasım saglarsınız...

            services.AddDbContext<MyContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies()); //LazyLoading aktifleştirilmesi icin Proxies kütüphanesinden gelen UseLazyLoadingProxies metodu burada gözlemlenir...
        }
    }
}
