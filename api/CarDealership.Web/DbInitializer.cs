using Microsoft.EntityFrameworkCore;

namespace WebCarDealership
{
    public static class DbInitializer
    {
        public static void Initialize(DealershipDbContext context)
        {
            
            context.Database.Migrate();
        }
    }
}