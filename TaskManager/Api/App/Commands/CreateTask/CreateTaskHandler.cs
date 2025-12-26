using Api.App.Interfaces;
using Api.Model.Events;
using MediatR;

namespace Api.App.Commands.CreateTask
{
	/// <summary>
	/// Создание задачи
	/// Используется как прослойка между медиатором и сервисом
	/// </summary>
	public class CreateTaskHandler : IRequestHandler<CreateTask, Guid>
	{
		private readonly ITaskService _taskService;

		public CreateTaskHandler(ITaskService taskService)
		{
			_taskService = taskService;
		}

		public async Task<Guid> Handle(CreateTask taskData, CancellationToken ct)
		{
			var value = await _taskService.CreateAsync(taskData);
			return value;
		}
	}
}
