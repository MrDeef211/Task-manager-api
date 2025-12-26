using Api.App.Interfaces;
using Api.App.Objects;
using Api.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.App.Queries.GetTasks
{
	/// <summary>
	/// Получить задачи
	/// Используется как прослойка между медиатором и сервисом
	/// </summary>
	public class GetTasksHandler : IRequestHandler<GetTasks, List<TaskDto>>
	{
		private readonly ITaskQueryService _queryService;

		public GetTasksHandler(ITaskQueryService QueryService)
		{
			_queryService = QueryService;
		}

		public async Task<List<TaskDto>> Handle(GetTasks taskData, CancellationToken ct)
		{
			var value = await _queryService.GetTasksAsync(taskData);
			return value;
		}
	}
}
