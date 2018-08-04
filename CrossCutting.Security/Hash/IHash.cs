namespace CrossCutting.Security.Hash
{
	public interface IHash
	{
		string Create(string value);
	}
}
