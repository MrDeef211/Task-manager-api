using Api.App.Commands.CompleteTask;
using Api.App.Commands.CreateTask;
using Api.App.Commands.DeleteTask;
using Api.App.Commands.StartTask;
using Api.App.Commands.UpdateTask;

namespace Api.App.Interfaces
{
	/// <summary>
	/// Интерфейс сервиса работы с задачами
	/// </summary>
	public interface ITaskService
	{

		/// <summary>
		/// Создать задачу
		/// </summary>
		/// <param name="taskData">Данные для создания задачи</param>
		/// <returns></returns>
		Task<Guid> CreateAsync(CreateTask taskData);
		/// <summary>
		/// Начать выполнение задачи
		/// </summary>
		/// <param name="taskData">Данные для указания задачи, как начатое</param>
		/// <returns></returns>
		Task StartAsync(StartTask taskData);
		/// <summary>
		/// Пометить задачу, как выполненную
		/// </summary>
		/// <param name="taskData">Данные для указания задачи, как выполненное</param>
		/// <returns></returns>
		Task CompleteAsync(CompleteTask taskData);
		/// <summary>
		/// Обновить задачу
		/// </summary>
		/// <param name="taskData">Данные для обновления задачи</param>
		/// <returns></returns>
		Task UpdateAsync(UpdateTask taskData);
		/// <summary>
		/// Удалить задачу
		/// </summary>
		/// <param name="taskData">Данные для удаления задачи</param>
		/// <returns></returns>
		Task DeleteAsync(DeleteTask taskData);
	}
}
