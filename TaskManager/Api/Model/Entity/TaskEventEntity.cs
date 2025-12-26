namespace Api.Model.Entity
{
	/// <summary>
	/// История изменения таблицы задач
	/// </summary>
	public class TaskEventEntity
	{
		/// <summary>
		/// Id действия
		/// </summary>
		public Guid Id { get; set; }
		/// <summary>
		/// Id задачи, над которой выполнено действие
		/// </summary>
		public Guid TaskId { get; set; }
		/// <summary>
		/// Тип действия
		/// </summary>
		public string EventType { get; set; } = null!;
		/// <summary>
		/// Данные для действия
		/// </summary>
		public string EventData { get; set; } = null!;
		/// <summary>
		/// Время создания запроса на действие
		/// </summary>
		public DateTime CreatedAt { get; set; }
	}
}
