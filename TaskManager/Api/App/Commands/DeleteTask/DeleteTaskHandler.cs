using Api.App.Interfaces;
using Api.Model.Events;

namespace Api.App.Commands.DeleteTask
{
	/// <summary>
	/// Удаление задачи
	/// Используется как прослойка между медиатором и сервисом
	/// </summary>
	public class DeleteTaskHandler
	{
		private readonly ITaskService _taskService;

		public DeleteTaskHandler(ITaskService taskService)
		{
			_taskService = taskService;
		}

		public async Task Handle(DeleteTask taskData, CancellationToken ct)
		{
			await _taskService.DeleteAsync(taskData);
		}
	}
}
