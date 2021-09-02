using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Application.Helpers
{
	public class RandomStringGenerator
	{
		internal static readonly char[] chars =
		   "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

		public static List<string> ListOfStrings(int length, ushort count)
		{
			var result = new List<string>();

			for (int i = 0; i < count; i++)
				result.Add(SingleString(length));

			return result;
		}

		public static string SingleString(int length)
		{
			byte[] data = new byte[4 * length];
			using (RNGCryptoServiceProvider crypto = new())
			{
				crypto.GetBytes(data);
			}
			StringBuilder result = new(length);
			for (int i = 0; i < length; i++)
			{
				var rnd = BitConverter.ToUInt32(data, i * 4);
				var idx = rnd % chars.Length;

				result.Append(chars[idx]);
			}

			return result.ToString();
		}
	}
}