using CarWorkshop.Application.CarWorkshop.Commands.CreatCarWorkshop;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshopService.Commands
{
    public class CreateCarWorkshopServiceCommandsValidator : AbstractValidator<CreateCarWorkshopServiceCommands>
    {
        public CreateCarWorkshopServiceCommandsValidator()
        {
            RuleFor(s => s.Cost)
                .NotEmpty()
                .NotNull();

            RuleFor(s => s.Description)
                .NotEmpty()
                .NotNull();

            RuleFor(s => s.CarWorkshopEncodedName)
                .NotEmpty()
                .NotNull();
        }
    }
}
