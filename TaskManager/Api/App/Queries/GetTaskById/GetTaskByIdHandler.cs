using Api.App.Commands.UpdateTask;
using Api.App.Interfaces;
using Api.App.Objects;
using Api.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;



namespace Api.App.Queries.GetTaskById
{
	/// <summary>
	/// Получить задачу по id
	/// Используется как прослойка между медиатором и сервисом
	/// </summary>
	public class GetTaskByIdHandler : IRequestHandler<GetTaskById, TaskDto>
	{
		private readonly ITaskQueryService _queryService;

		public GetTaskByIdHandler(ITaskQueryService QueryService)
		{
			_queryService = QueryService;
		}

		public async Task<TaskDto> Handle(GetTaskById taskData, CancellationToken ct)
		{
			var value = await _queryService.GetTaskByIdAsync(taskData);
			return value;
		}
	}
}
