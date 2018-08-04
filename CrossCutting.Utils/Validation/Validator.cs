using System.Linq;
using CrossCutting.Utils.Exceptions;

namespace CrossCutting.Utils.Validation
{
	public abstract class Validator<T>
	{
		public abstract ValidatorResult Validate(T obj);

		public void ValidateThrowException(T obj)
		{
			var result = Validate(obj);

			if (!result.IsValid)
			{
				var message = string.Join(" ", result.Errors.Select(x => x.Value));
				throw new DomainException(message);
			}
		}
	}
}
