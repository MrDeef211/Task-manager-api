namespace Api.App.Interfaces
{
	/// <summary>
	/// Интерфейс для работы с запросами
	/// </summary>
	public interface ITaskEventRepository
	{
		/// <summary>
		/// Создать запрос
		/// </summary>
		/// <typeparam name="TEvent">Данные для запроса</typeparam>
		/// <param name="domainEvent">Данные текущего запроса</param>
		/// <returns></returns>
		Task AddAsync<TEvent>(TEvent domainEvent);
	}
}
