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
	}
}
