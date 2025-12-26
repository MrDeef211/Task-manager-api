using Api.Model.Entity;
using Api.Model.Events;

namespace Api.App.Interfaces
{
	/// <summary>
	/// Интерфейс для работы с базой данных задач
	/// </summary>
	public interface ITaskRepository
	{
		/// <summary>
		/// Создать задачу
		/// </summary>
		/// <param name="event">Данные из события создания задачи</param>
		/// <returns></returns>
		Task ApplyAsync(TaskCreatedEvent @event);
		/// <summary>
		/// Начать выполнение задачи
		/// </summary>
		/// <param name="event">Данные из события начала выполнения задачи</param>
		/// <returns></returns>
		Task ApplyAsync(TaskStartedEvent @event);
		/// <summary>
		/// Закончить выполнение задачи
		/// </summary>
		/// <param name="event">Данные из события окончания выполнения задачи</param>
		/// <returns></returns>
		Task ApplyAsync(TaskCompletedEvent @event);
		/// <summary>
		/// Обновить задачу
		/// </summary>
		/// <param name="event">Данные из события обновления задачи</param>
		/// <returns></returns>
		Task ApplyAsync(TaskUpdatedEvent @event);
		/// <summary>
		/// Удалить задачу
		/// </summary>
		/// <param name="event">Данные из события для удаления</param>
		/// <returns></returns>
		Task ApplyAsync(TaskDeletedEvent @event);
		/// <summary>
		/// Получить задачу по идентификатору
		/// </summary>
		/// <remarks> 
		/// Без этого метода не получится сделать валидацию в service
		/// </remarks>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<TaskEntity?> GetByIdAsync(Guid id);
	}
}
