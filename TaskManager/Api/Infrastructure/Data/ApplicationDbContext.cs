using Microsoft.EntityFrameworkCore;
using Api.Model.Entity;


namespace Api.Infrastructure.Data
{
	public class ApplicationDbContext : DbContext
	{
		/// <summary>
		/// Контекст базы данных
		/// </summary>
		/// <param name="options"></param>
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)	: base(options)
		{

		}

		/// <summary>
		/// Таблица задач
		/// </summary>
		public DbSet<TaskEntity> Tasks { get; set; }
		/// <summary>
		/// История изменения таблицы задач
		/// </summary>
		public DbSet<TaskEventEntity> TaskEvents { get; set; }

		/// <summary>
		/// Конфигурация модели
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		}
	}
}
