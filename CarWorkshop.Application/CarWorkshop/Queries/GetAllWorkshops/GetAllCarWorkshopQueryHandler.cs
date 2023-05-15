using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Queries.GetAllWorkshops
{
    internal class GetAllCarWorkshopQueryHandler : IRequestHandler<GetAllCarWorkshopsQuery, IEnumerable<CarWorkshopDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        public GetAllCarWorkshopQueryHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CarWorkshopDto>> Handle(GetAllCarWorkshopsQuery request, CancellationToken cancellationToken)
        {
            var carWorkshops = await _carWorkshopRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<CarWorkshopDto>>(carWorkshops);

            return dtos;
        }
    }
}
