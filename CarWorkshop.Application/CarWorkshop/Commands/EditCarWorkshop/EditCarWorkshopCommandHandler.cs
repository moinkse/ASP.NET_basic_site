using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    internal class EditCarWorkshopCommandHandler : IRequestHandler<EditCarWorkshopCommand>
    {
        private readonly ICarWorkshopRepository _repository;
        private readonly IUserContext _userContext;

        public EditCarWorkshopCommandHandler(ICarWorkshopRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(EditCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _repository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && (carWorkshop.CreatedById == user.Id || user.IsInRole("Moderator"));

            if (isEditable)
            {
                return Unit.Value;
            }

            carWorkshop.Description = request.Description;
            carWorkshop.About = request.About;

            carWorkshop.ConcactDetails.City = request.City;
            carWorkshop.ConcactDetails.PhoneNumber = request.PhoneNumber;
            carWorkshop.ConcactDetails.PostalCode = request.PostalCode;
            carWorkshop.ConcactDetails.Street = request.Street;

            await _repository.Commit();

            return Unit.Value;
        }
    }
}
