using CrossCutting.Resources;
using CrossCutting.Utils.Validation;
using Model.Models.Authentication;

namespace Model.Models.Validators
{
    public sealed class AuthenticatedValidator : Validator<AuthenticatedModel>
    {
        public override ValidatorResult Validate(AuthenticatedModel obj)
        {
            var result = new ValidatorResult();

            if (obj == null || obj.Id == 0 || obj.Roles.Length == 0)
            {
                result.Errors.Add(nameof(DesignAutomatorTexts.AuthenticationInvalid), DesignAutomatorTexts.AuthenticationInvalid);
            }

            return result;
        }
    }
}
