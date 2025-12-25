using Api.App.Interfaces;
using Api.App.Objects;
using Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.App.Queries.GetTasks
{
	/// <summary>
	/// Получить задачи
	/// Используется как прослойка между медиатором и сервисом
	/// </summary>
	public class GetTasksHandler
	{
		private readonly ITaskQueryService _queryService;

		public GetTasksHandler(ITaskQueryService QueryService)
		{
			_queryService = QueryService;
		}

		public async Task Handle(GetTasks taskData, CancellationToken ct)
		{
			await _queryService.GetTasksAsync(taskData);
		}
	}
}
