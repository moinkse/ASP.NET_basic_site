using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop;
using CarWorkshop.Application.CarWorkshopService;
using CarWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Mappings
{
	internal class CarWorkshopMappingProfile : Profile
	{
		public CarWorkshopMappingProfile(IUserContext userContext)
		{
			var user = userContext.GetCurrentUser();
			CreateMap<CarWorkshopDto, Domain.Entities.CarWorkshop>()
				.ForMember(e => e.ConcactDetails, opt => opt.MapFrom(src => new CarWorkshopConcactDetails()
				{
					City = src.City,
					PhoneNumber = src.PhoneNumber,
					PostalCode = src.PostalCode,
					Street = src.Street,
				}));

			CreateMap<Domain.Entities.CarWorkshop, CarWorkshopDto>()
				.ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null 
													&& (src.CreatedById == user.Id || user.IsInRole("Moderator"))))
				.ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.ConcactDetails.Street))
				.ForMember(dto => dto.City, opt => opt.MapFrom(src => src.ConcactDetails.City))
				.ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.ConcactDetails.PostalCode))
				.ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.ConcactDetails.PhoneNumber));

			CreateMap<CarWorkshopDto, EditCarWorkshopCommand>();

			CreateMap<CarWorkshopServiceDto, Domain.Entities.CarWorkshopService>()
				.ReverseMap();

		}
	}
}
