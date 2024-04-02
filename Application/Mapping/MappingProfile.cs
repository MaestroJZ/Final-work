using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        CreateMap<Voting, VotingDto>()
            .ForMember(dest => dest.BallotOptions, opt => opt.MapFrom(src => src.BallotOptions));

        CreateMap<Ballot, BallotDto>().ReverseMap();
        CreateMap<Vote, VoteDto>().ReverseMap();
            
        CreateMap<VotingDto, Voting>();
    }
}