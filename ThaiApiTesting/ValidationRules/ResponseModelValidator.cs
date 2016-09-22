using FluentValidation;
using ThaiApiTesting.Models;

namespace ThaiApiTesting.ValidationRules
{
    public class ResponseModelValidator : AbstractValidator<Response>
    {
        public ResponseModelValidator()
        {
            RuleFor(response => response.current_item).NotNull(); 

            RuleFor(response => response.docs).NotNull().SetCollectionValidator(new DocModelValidator());

            RuleFor(response => response.item_found).NotNull();

            RuleFor(response => response.item_per_page).NotNull();

            RuleFor(response => response.lat).NotNull();

            RuleFor(response => response.lng).NotNull();

            RuleFor(response => response.next_parameter).NotNull();

            RuleFor(response => response.parameter_template).NotNull();

            RuleFor(response => response.prev_parameter).NotNull();

            //RuleFor(response => response.query).NotNull();
        }
    }
}
