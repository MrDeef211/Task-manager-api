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

		/// <summary>
		/// Данные для события создания задачи
		/// </summary>
		/// <param name="taskId">Id создаваемой задачи</param>
		/// <param name="title">Название задачи</param>
		/// <param name="description">Описание задачи</param>
		/// <param name="deadline">Дедлайн задачи</param>
		/// <param name="createdAt">Время создания задачи</param>
		public TaskCreatedEvent(Guid taskId, string title, string description, DateTime deadline)
		{
			TaskId = taskId;
			Title = title;
			Description = description;
			Deadline = deadline;
		}
	}
}
