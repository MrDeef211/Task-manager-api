namespace Api.Model.Events
{
	/// <summary>
	/// Данные для события создания задачи
	/// </summary>
	public class TaskCreatedEvent
	{
		/// <summary>
		/// Id создаваемой задачи
		/// </summary>
		public Guid TaskId { get; init; }
		/// <summary>
		/// Название задачи
		/// </summary>
		public string Title { get; init; } = null!;
		/// <summary>
		/// Описание задачи
		/// </summary>
		public string Description { get; init; } = null!;
		/// <summary>
		/// Дедлайн задачи
		/// </summary>
		public DateTime Deadline { get; init; }
		/// <summary>
		/// Время создания задачи
		/// </summary>
		public DateTime CreatedAt { get; init; }

	}
}
