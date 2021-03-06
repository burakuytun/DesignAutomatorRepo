using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CrossCutting.Security.Criptography
{
	public class Criptography : ICriptography
	{
		private string Key { get; set; }

		public string Decrypt(string value)
		{
			var result = Transform(Convert.FromBase64String(value), GetAlgorithm().CreateDecryptor());
			return Encoding.Unicode.GetString(result);
		}

		public string Encrypt(string value)
		{
			var result = Transform(Encoding.Unicode.GetBytes(value), GetAlgorithm().CreateEncryptor());
			return Convert.ToBase64String(result);
		}

		public void SetKey(string key)
		{
			Key = key;
		}

		private static byte[] Transform(byte[] bytes, ICryptoTransform cryptoTransform)
		{
			var ms = new MemoryStream();
			var cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write);
			cs.Write(bytes, 0, bytes.Length);
			cs.Close();
			return ms.ToArray();
		}

		private SymmetricAlgorithm GetAlgorithm()
		{
			var key = new Rfc2898DeriveBytes(Key, Encoding.ASCII.GetBytes(Key));
			var algorithm = new RijndaelManaged();
			algorithm.Key = key.GetBytes(algorithm.KeySize / 8);
			algorithm.IV = key.GetBytes(algorithm.BlockSize / 8);
			return algorithm;
		}
	}
}
