using Api.App.Commands.CompleteTask;
using Api.App.Commands.CreateTask;
using Api.App.Commands.StartTask;
using Api.App.Commands.UpdateTask;

namespace Api.App.Interfaces
{
	/// <summary>
	/// Интерфейс сервиса работы с задачами
	/// </summary>
	public interface ITaskService
	{
		// Я оставил и обработчики команд, и сервис для работы с задачами,
		// Сюда можно ещё добавить какую-то бизнес-логику, если потребуется
		// А обработчики для парса команд

		/// <summary>
		/// Создать задачу
		/// </summary>
		/// <param name="command">Данные для создания задачи</param>
		/// <returns></returns>
		Task CreateAsync(CreateTask command);
		/// <summary>
		/// Начать выполнение задачи
		/// </summary>
		/// <param name="command">Данные для указания задачи, как начатое</param>
		/// <returns></returns>
		Task StartAsync(StartTask command);
		/// <summary>
		/// Пометить задачу, как выполненную
		/// </summary>
		/// <param name="command">Данные для указания задачи, как выполненное</param>
		/// <returns></returns>
		Task CompleteAsync(CompleteTask command);
		/// <summary>
		/// Обновить задачу
		/// </summary>
		/// <param name="command">Данные для обновления задачи</param>
		/// <returns></returns>
		Task UpdateAsync(UpdateTask command);
	}
}
