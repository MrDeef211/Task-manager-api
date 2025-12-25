using Api.Model.Enums;

namespace Api.App.Objects
{
	/// <summary>
	/// Data Transfer Object для задачи
	/// Нужен только для передачи данных
	/// </summary>
	public class TaskDto
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
		public string Status { get; set; } = null!;
	}
}
