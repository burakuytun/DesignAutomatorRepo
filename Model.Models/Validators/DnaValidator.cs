using CrossCutting.Resources;
using CrossCutting.Utils.Validation;

namespace Model.Models.Validators
{
    public class DnaValidator : Validator<Dna>
    {
        public override ValidatorResult Validate(Dna obj)
        {
            var result = new ValidatorResult();

            return result;
        }

        public ValidatorResult ValidateGetByUsername(string userName)
        {
            var result = new ValidatorResult();

            if (string.IsNullOrEmpty(userName))
            {
                result.Errors.Add(nameof(DesignAutomatorTexts.UsernameEmpty), DesignAutomatorTexts.UsernameEmpty);
            }

            return result;
        }

        public ValidatorResult ValidateGetByUserId(int id)
        {
            var result = new ValidatorResult();

            if (id <= 0)
            {
                result.Errors.Add(nameof(DesignAutomatorTexts.UserIdEmpty), DesignAutomatorTexts.UserIdEmpty);
            }

            return result;
        }
    }
}