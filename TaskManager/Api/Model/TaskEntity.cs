namespace Api.Model
{
	/// <summary>
	/// Таблица задач
	/// </summary>
	public class TaskEntity
	{
		/// <summary>
		/// Id задачи
		/// </summary>
		public Guid Id { get; set; }
		/// <summary>
		/// Название задачи
		/// </summary>
		public string Title { get; set; } = null!;
		/// <summary>
		/// Описание задачи
		/// </summary>
		public string Description { get; set; } = null!;
		/// <summary>
		/// Крайнее время выполнения задачи (дедлайн)
		/// </summary>
		public DateTime Deadline { get; set; }
		/// <summary>
		/// Время создания
		/// </summary>
		public DateTime CreatedAt { get; set; }
		/// <summary>
		/// Время начала выполнения задачи (если начато)
		/// </summary>
		public DateTime? StartedAt { get; set; }
		/// <summary>
		/// Время выполнения задачи (если выполнено)
		/// </summary>
		public DateTime? CompletedAt { get; set; }
		/// <summary>
		/// Статус задачи
		/// </summary>
		public TaskStatus Status { get; set; }
	}
}
