using Api.Model.Events;

namespace Api.App.Interfaces
{
	/// <summary>
	/// Интерфейс для работы с задачами
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
	}
}
