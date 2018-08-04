using CrossCutting.Resources;
using CrossCutting.Utils.Validation;
using Model.Models.Authentication;

namespace Model.Models.Validators
{
	public sealed class AuthenticationValidator : Validator<AuthenticationModel>
	{
		public override ValidatorResult Validate(AuthenticationModel obj)
		{
			var result = new ValidatorResult();

			if (obj == null || string.IsNullOrEmpty(obj.UserName) || string.IsNullOrEmpty(obj.Password))
			{
				result.Errors.Add(nameof(DesignAutomatorTexts.AuthenticationInvalid), DesignAutomatorTexts.AuthenticationInvalid);
			}

			return result;
		}
	}
}
