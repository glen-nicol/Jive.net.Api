using Jive.Linq.Serialization;

namespace Jive.Linq.Models
{
	public interface IJiveContent : IJiveApiObject
	{
		[JiveApiReadOnly]
		string ContentId { get; }
		JiveContentType Type { get; }
		JiveBody Body { get; set; }
		string Subject { get; set; }
	}

	public enum JiveContentType
	{
		Discussion,
		Document,
		File,
		Poll,
		Post,
		Favorite,
		Task,
		Update
	}
}