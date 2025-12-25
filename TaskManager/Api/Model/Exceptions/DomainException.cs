namespace Api.Model.Exceptions
{
	public class DomainException : Exception
	{
		public DomainException(string message) : base(message) { }
	}
}
