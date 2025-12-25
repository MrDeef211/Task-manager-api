namespace Api.App.Interfaces
{
	/// <summary>
	/// Интерфейс для работы с действиями
	/// </summary>
	public interface ITaskEventRepository
	{
		/// <summary>
		/// Создать запрос
		/// </summary>
		/// <typeparam name="TEvent">Данные для действия</typeparam>
		/// <param name="domainEvent">Данные текущего действия</param>
		/// <returns></returns>
		Task AddAsync<TEvent>(TEvent domainEvent);
	}
}
