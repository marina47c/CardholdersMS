using CardholderManagementSystem.DTOs;
using CardholderManagementSystem.Models;
using AutoMapper;

namespace CardholderManagementSystem.Mappings
{
    public class CardholdersMappingProfile : Profile
    {
        public CardholdersMappingProfile()
        {
            CreateMap<Cardholder, CardholderDto>();

            CreateMap<UpdateCardholderDto, Cardholder>()
                .ForMember(d => d.Id, opt => opt.Ignore());

            CreateMap<CreateCardholderDto, Cardholder>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.TransactionCount, opt => opt.MapFrom(_ => 0u));
        }
    }
}
