using Microsoft.EntityFrameworkCore;
using Api.Model.Entity;


namespace Api.Infrastructure.Data
{
	public class ApplicationDbContext : DbContext
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="options"></param>
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)	: base(options)
		{

		}

		/// <summary>
		/// Таблица задач
		/// </summary>
		private DbSet<TaskEntity> _tasks;
		/// <summary>
		/// История изменения таблицы задач
		/// </summary>
		private DbSet<TaskEventEntity> _taskEvents;

		/// <summary>
		/// Таблица задач
		/// </summary>
		public DbSet<TaskEntity> Tasks 
		{ 
			get { return _tasks; } 
			set { _tasks = value; }
		}
		/// <summary>
		/// История изменения таблицы задач
		/// </summary>
		public DbSet<TaskEventEntity> TaskEvents
		{
			get { return _taskEvents; } 
			set { _taskEvents = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Конфигурации будут здесь
		}
	}
}
