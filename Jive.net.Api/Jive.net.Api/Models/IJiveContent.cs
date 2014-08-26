using Jive.net.Serialization;

namespace Jive.net.Models
{
	public interface IJiveContent : IJiveApiObject
	{
		[JiveApiReadOnly]
		string ContentId { get; }
		JiveContentType Type { get; }
		IJiveBody Body { get; set; }
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