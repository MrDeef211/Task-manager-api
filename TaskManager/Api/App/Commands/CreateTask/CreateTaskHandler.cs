using Api.Model.Events;
using Api.App.Interfaces;

namespace Api.App.Commands.CreateTask
{
	/// <summary>
	/// Создание задачи
	/// Используется как прослойка между медиатором и сервисом
	/// </summary>
	public class CreateTaskHandler
	{
		private readonly ITaskService _taskService;

		public CreateTaskHandler(ITaskService taskService)
		{
			_taskService = taskService;
		}

		public async Task Handle(CreateTask taskData, CancellationToken ct)
		{
			await _taskService.CreateAsync(taskData);
		}
	}
}
