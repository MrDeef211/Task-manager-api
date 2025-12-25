using MediatR;

namespace Api.App.Commands.CreateTask
{
	/// <summary>
	/// Данные для вызова создания задачи
	/// </summary>
	public class CreateTask : IRequest
	{
		/// <summary>
		/// Название задачи
		/// </summary>
		public string Title { get; set; } = null!;
		/// <summary>
		/// Описание задачи
		/// </summary>
		public string Description { get; set; } = null!;
		/// <summary>
		/// Крайнее время выполнения задачи (дедлайн)
		/// </summary>
		public DateTime Deadline { get; set; }
	}
}
