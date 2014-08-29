namespace Jive.Linq.Models
{
	public class OnBehalfOf
	{
		public string Email { get; set; }
		public string Name { get; set; }
		public JivePerson Person { get; private set; }
	}
}