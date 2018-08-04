namespace CrossCutting.Security.Criptography
{
	public interface ICriptography
	{
		string Decrypt(string value);

		string Encrypt(string value);

		void SetKey(string key);
	}
}
