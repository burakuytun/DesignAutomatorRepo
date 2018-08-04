using CrossCutting.Resources;
using CrossCutting.Utils.Validation;

namespace Model.Models.Validators
{
    public class CommonValidator
    {
        public ValidatorResult Validate(Dna obj)
        {
            var result = new ValidatorResult();

            return result;
        }

        public ValidatorResult ValidateByObjectNull(object entity)
        {
            var result = new ValidatorResult();

            if (entity == null)
            {
                result.Errors.Add(nameof(DesignAutomatorTexts.QueriedObjectNull),
                    DesignAutomatorTexts.QueriedObjectNull);
            }

            return result;
        }

        public ValidatorResult ValidateByIntegerFilter(int filter)
        {
            var result = new ValidatorResult();

            if (filter <= 0)
            {
                result.Errors.Add(nameof(DesignAutomatorTexts.FilterKeywordEmpty), DesignAutomatorTexts.FilterKeywordEmpty);
            }

            return result;
        }
    }
}
