using MediatR;
using System.Text.Json.Serialization;

namespace Api.App.Commands.UpdateTask
{
	/// <summary>
	/// Данные для изменения задачи
	/// </summary>
	public class UpdateTask : IRequest
	{
		/// <summary>
		/// Id задачи
		/// </summary>
		/// <remarks>
		/// Игнорируется при десериализации из тела запроса.
		/// Загружается через присваивание через headers 
		/// </remarks>
		[JsonIgnore]
		public Guid TaskId { get; set; }
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
