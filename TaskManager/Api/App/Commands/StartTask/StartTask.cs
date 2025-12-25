using MediatR;

namespace Api.App.Commands.StartTask
{
	/// <summary>
	/// Данные для начала выполнения задачи
	/// </summary>
	public class StartTask : IRequest
	{
		/// <summary>
		/// Id задачи
		/// </summary>
		public Guid TaskId { get; set; }

		/// <summary>
		/// Данные для начала выполнения задачи
		/// </summary>
		/// <param name="taskId">Id задачи</param>
		public StartTask(Guid taskId)
		{
			TaskId = taskId;
		}	
	}
}
