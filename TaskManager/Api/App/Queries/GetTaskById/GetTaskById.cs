namespace Api.App.Queries.GetTaskById
{
	/// <summary>
	/// Данные для запроса задачи по id
	/// </summary>
	public class GetTaskById
	{
		/// <summary>
		/// Id задачи
		/// </summary>
		public Guid TaskId { get; init; }

		/// <summary>
		/// Данные для запроса задачи по id
		/// </summary>
		/// <param name="taskId">id запроса</param>
		public GetTaskById(Guid taskId)
		{
			TaskId = taskId;
		}
	}
}
