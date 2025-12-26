namespace Api.Model.Exceptions
{
	/// <summary>
	/// Исключения для валидации входных данных
	/// </summary>
	public class DomainException : Exception
	{
		public DomainException(string message) : base(message) { }
	}
}
