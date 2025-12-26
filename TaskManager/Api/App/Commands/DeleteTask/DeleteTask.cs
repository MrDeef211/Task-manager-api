using MediatR;

namespace Api.App.Commands.DeleteTask
{
	/// <summary>
	/// Данные для удаления задачи
	/// </summary>
	public class DeleteTask : IRequest
	{
		/// <summary>
		/// Id задачи
		/// </summary>
		public Guid TaskId { get; set; }

		/// <summary>
		/// Данные для удаления задачи
		/// </summary>
		/// <param name="taskId">Id задачи</param>
		public DeleteTask(Guid taskId)
		{
			TaskId = taskId;
		}
	}
}
