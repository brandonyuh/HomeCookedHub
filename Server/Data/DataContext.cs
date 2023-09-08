namespace HomeCookedHub.Server.Data
{
	public class DataContext : DbContext
	{
		// cd server
		// dotnet ef migrations add 
		// dotnet ef database update
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}
		public DbSet<User> Users { get; set; }
	}
}
