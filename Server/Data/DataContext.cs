namespace HomeCookedHub.Server.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasData(
				new User
				{ Id = 1, Name = "Brandon Yuh", Email = "brandonyuh@gmail.com", Password = "123", UserType = "admin" },
				new User
				{ Id = 2, Name = "Jane Smith", Email = "janesmith@example.com", Password = "123", UserType = "user" }
				);
		}
		public DbSet<User> Users { get; set; }
	}
}
