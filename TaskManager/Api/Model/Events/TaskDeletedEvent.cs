namespace Api.Model.Events
{
	/// <summary>
	/// Данные для события удаления задачи
	/// </summary>
	public class TaskDeletedEvent
	{
		/// <summary>
		/// Id начинаемой задачи
		/// </summary>
		public Guid TaskId { get; init; }

	}
}
