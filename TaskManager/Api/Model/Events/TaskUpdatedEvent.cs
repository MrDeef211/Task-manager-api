namespace Api.Model.Events
{
	/// <summary>
	/// Данные для события изменения данных задачи
	/// </summary>
	public class TaskUpdatedEvent
	{
		/// <summary>
		/// Id задачи
		/// </summary>
		public Guid TaskId { get; set; }
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
		/// Данные для события изменения данных задачи
		/// </summary>
		/// <param name="taskId">Id задачи</param>
		/// <param name="title">Название задачи</param>
		/// <param name="description">Описание задачи</param>
		/// <param name="deadline">Крайнее время выполнения задачи (дедлайн)</param>
		public TaskUpdatedEvent(Guid taskId, string title, string description, DateTime deadline)
		{
			TaskId = taskId;
			Title = title;
			Description = description;
			Deadline = deadline;
		}
	}
}
