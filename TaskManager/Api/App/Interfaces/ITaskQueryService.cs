using Api.App.Queries.GetTaskById;
using Api.App.Queries.GetTasks;

namespace Api.App.Interfaces
{
	/// <summary>
	/// Интерфейс для сервиса запросов
	/// </summary>
	public interface ITaskQueryService
	{
		// Я оставил и обработчики команд, и сервис для работы с задачами,
		// Сюда можно ещё добавить какую-то бизнес-логику, если потребуется
		// А обработчики для парса команд

		/// <summary>
		/// Получить задачи
		/// </summary>
		/// <param name="query">Данные задач для запроса</param>
		/// <returns></returns>
		Task<List<Objects.TaskDto>> GetTasksAsync(GetTasks query);

		/// <summary>
		/// Получить задачу по id
		/// </summary>
		/// <param name="query">Данные задач для запроса</param>
		/// <returns></returns>
		Task<Objects.TaskDto?> GetTaskByIdAsync(GetTaskById query);
	}
}
