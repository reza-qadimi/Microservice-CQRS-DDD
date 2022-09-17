using System.Text;

namespace Framework.Utility.String
{
	public static class Cryptography : object
	{
		static Cryptography()
		{
		}


		public static string ComputeSha256Hash(string value)
		{
			// Create a SHA256   
			using var sha256Hash =
				System.Security.Cryptography.SHA256.Create();

			// ComputeHash - returns byte array  
			byte[] bytes =
				sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

			// Convert byte array to a string   
			StringBuilder builder = new();

			for (int index = 0; index < bytes.Length; index++)
			{
				builder.Append(bytes[index].ToString("x2"));
			}

			return builder.ToString();
		}

		public static string ComputeSha1Hash(string value)
		{
			// Create a SHA1   
			using var sha1Hash =
				System.Security.Cryptography.SHA1.Create();

			// ComputeHash - returns byte array  
			byte[] bytes =
				sha1Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

			// Convert byte array to a string   
			StringBuilder builder = new();

			for (int index = 0; index < bytes.Length; index++)
			{
				builder.Append(bytes[index].ToString("x2"));
			}

			return builder.ToString();
		}
	}
}
