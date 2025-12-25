using Api.App.Interfaces;
using Api.Model.Events;
using MediatR;

namespace Api.App.Commands.CompleteTask
{
	/// <summary>
	/// Изменение статуса задачи на выполненное
	/// Используется как прослойка между медиатором и сервисом
	/// </summary>
	public class CompleteTaskHandler : IRequestHandler<CompleteTask>
	{
		private readonly ITaskService _taskService;

		public CompleteTaskHandler(ITaskService taskService)
		{
			_taskService = taskService;
		}

		public async Task Handle(CompleteTask taskData, CancellationToken ct)
		{
			await _taskService.CompleteAsync(taskData);
		}
	}
}
