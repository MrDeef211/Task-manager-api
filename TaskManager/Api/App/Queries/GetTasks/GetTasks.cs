using Api.App.Objects;
using MediatR;

namespace Api.App.Queries.GetTasks
{
	/// <summary>
	/// Данные для запроса таблицы задач
	/// </summary>
	public class GetTasks : IRequest<List<TaskDto>>
	{
		/// <summary>
		/// Статус задачи
		/// </summary>
		public string? Status { get; init; }
		/// <summary>
		/// Начиная с этой даты
		/// </summary>
		public DateTime? FromDate { get; init; }
		/// <summary>
		/// До этой даты
		/// </summary>
		public DateTime? ToDate { get; init; }
		/// <summary>
		/// По тексту в названии/описании
		/// Не работает, если HardSearch не пустой
		/// </summary>
		public string? Search { get; init; }
		/// <summary>
		/// По тексту только в названии 
		/// </summary>
		public string? HardSearch { get; init; }
	}
}
