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

		/// <summary>
		/// Данные для события начала выполнения задачи
		/// </summary>
		/// <param name="taskId">Id начинаемой задачи</param>
		/// <param name="startedAt">Время начала выполнения задачи (если начато)</param>
		public TaskStartedEvent(Guid taskId)
		{
			TaskId = taskId;
		}
	}
}
