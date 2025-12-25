namespace Api.App.Commands.StartTask
{
	/// <summary>
	/// Данные для начала выполнения задачи
	/// </summary>
	public class StartTask
	{
		/// <summary>
		/// Id задачи
		/// </summary>
		public Guid TaskId { get; set; }
	}
}
