namespace Api.Model.Events
{
	/// <summary>
	/// Данные для события начала выполнения задачи
	/// </summary>
	public class TaskStartedEvent
	{
		/// <summary>
		/// Id начинаемой задачи
		/// </summary>
		public Guid TaskId { get; init; }
		/// <summary>
		/// Время начала выполнения задачи (если начато)
		/// </summary>
		public DateTime? StartedAt { get; set; }
	}
}
