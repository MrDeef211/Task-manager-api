using Api.App.Interfaces;
using Api.Model.Events;
using MediatR;

namespace Api.App.Commands.StartTask
{
	/// <summary>
	/// Изменение статуса задачи на начатое
	/// Используется как прослойка между медиатором и сервисом
	/// </summary>
	public class StartTaskHandler
	{
		private readonly ITaskService _taskService;

		public StartTaskHandler(ITaskService taskService)
		{
			_taskService = taskService;
		}

		public async Task<Unit> Handle(StartTask taskData, CancellationToken ct)
		{
			await _taskService.StartAsync(taskData);
			return Unit.Value;
		}
	}
}
