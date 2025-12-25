namespace Api.App.Commands.CompleteTask
{
	/// <summary>
	/// Данные для выполнения задачи
	/// </summary>
	public class CompleteTask
	{
		/// <summary>
		/// Id задачи
		/// </summary>
		public Guid TaskId { get; set; }

		/// <summary>
		/// Данные для выполнения задачи
		/// </summary>
		/// <param name="taskId">Id задачи</param>
		public CompleteTask(Guid taskId)
		{
			TaskId = taskId;
		}
	}
}
