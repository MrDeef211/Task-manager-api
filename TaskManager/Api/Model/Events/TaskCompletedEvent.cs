namespace Api.Model.Events
{
	/// <summary>
	/// Данные для события завершения задачи
	/// </summary>
	public class TaskCompletedEvent
	{
		/// <summary>
		/// Id задачи
		/// </summary>
		public Guid TaskId { get; set; }
		/// <summary>
		/// Время выполнения задачи
		/// </summary>
		public DateTime? CompletedAt { get; set; }
	}
}
