using FluentValidation;
using ShopsRUs.API.Models;

namespace ShopsRUs.API.Validators
{
    /// <summary>
    /// Represents a custom validator for <see cref="CreateClientRequestModel"/>.
    /// </summary>
    public sealed class CreateClientRequestModelValidator : AbstractValidator<CreateClientRequestModel>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="CreateClientRequestModelValidator"/>.
        /// </summary>
        public CreateClientRequestModelValidator()
        {
            RuleFor(model => model.Name).NotEmpty();
            RuleFor(model => model.IsEmployee).NotNull();
            RuleFor(model => model.IsAffiliated).NotNull();
        }
    }
}
