namespace Jive.net.Models
{
	public class JiveBody
	{
		private string _type = "text/html";
		private string _text = "";

		public string Type { get { return _type; } set { _type = value; } }
		public string Text { get { return _text; } set { _text = value; } }
	}

}