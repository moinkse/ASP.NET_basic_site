using MediatR;

namespace CarWorkshop.Application.CarWorkshopService.Commands
{
    public class CreateCarWorkshopServiceCommands : CarWorkshopServiceDto, IRequest
    {
        public string CarWorkshopEncodedName { get; set; } = default!;
    }
}
