using Api.App.Interfaces;
using Api.Model.Events;
using MediatR;

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

		public async Task<Unit> Handle(CreateTask taskData, CancellationToken ct)
		{
			await _taskService.CreateAsync(taskData);
			return Unit.Value;
		}
	}
}
