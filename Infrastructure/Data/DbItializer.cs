namespace Infrastructure.Data
{
    public class DbItializer
    {
        public static void Initialize(EventAppDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
        }
    }
}
