namespace Api.Model.Events
{
	/// <summary>
	/// Данные для события завершения задачи
	/// </summary>
	public class TaskCompleted
	{
		/// <summary>
		/// Id задачи
		/// </summary>
		public Guid Id { get; set; }
		/// <summary>
		/// Время выполнения задачи
		/// </summary>
		public DateTime? CompletedAt { get; set; }

	}
}
