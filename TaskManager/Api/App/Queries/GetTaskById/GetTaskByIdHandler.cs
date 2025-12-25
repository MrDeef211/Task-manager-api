using Api.App.Commands.UpdateTask;
using Api.App.Interfaces;
using Api.App.Objects;
using Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;



namespace Api.App.Queries.GetTaskById
{
	/// <summary>
	/// Получить задачу по id
	/// Используется как прослойка между медиатором и сервисом
	/// </summary>
	public class GetTaskByIdHandler
	{
		private readonly ITaskQueryService _queryService;

		public GetTaskByIdHandler(ITaskQueryService QueryService)
		{
			_queryService = QueryService;
		}

		public async Task Handle(GetTaskById taskData, CancellationToken ct)
		{
			await _queryService.GetTaskByIdAsync(taskData);
		}
	}
}
