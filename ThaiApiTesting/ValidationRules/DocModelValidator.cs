using FluentValidation;
using ThaiApiTesting.Models;

namespace ThaiApiTesting.ValidationRules
{
    public class DocModelValidator : AbstractValidator<Doc>
    {
        public DocModelValidator()
        {
            RuleFor(doc => doc.city).NotNull();

            RuleFor(doc => doc.country).NotNull();

            RuleFor(doc => doc.lat).NotNull();

            RuleFor(doc => doc.lng).NotNull();

            RuleFor(doc => doc.name).NotNull();

            RuleFor(doc => doc.native_city).NotNull();

            RuleFor(doc => doc.native_name).NotNull();

            RuleFor(doc => doc.native_state).NotNull();

            RuleFor(doc => doc.native_town).NotNull();

            RuleFor(doc => doc.score).NotNull();

            RuleFor(doc => doc.state).NotNull();

            RuleFor(doc => doc.town).NotNull();
        }
    }
}
