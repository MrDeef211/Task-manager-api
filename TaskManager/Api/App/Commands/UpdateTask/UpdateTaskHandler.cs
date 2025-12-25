using Api.Model.Events;
using Api.App.Interfaces;

namespace Api.App.Commands.UpdateTask
{
	/// <summary>
	/// Обновление задачи
	/// Используется как прослойка между медиатором и сервисом
	/// </summary>
	public class UpdateTaskHandler
	{
		private readonly ITaskService _taskService;

		public UpdateTaskHandler(ITaskService taskService)
		{
			_taskService = taskService;
		}

		public async Task Handle(UpdateTask taskData, CancellationToken ct)
		{
			await _taskService.UpdateAsync(taskData);
		}
	}
}
