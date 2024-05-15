using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Candidate, CandidateDto>().ReverseMap();
        
        CreateMap<Election, ElectionDto>().ReverseMap();
        
        CreateMap<Voter, VoterDto>().ReverseMap();

        CreateMap<Transaction, TransactionDto>().ReverseMap();

        CreateMap<Vote, VoteDto>().ReverseMap();

        CreateMap<UserRequestDto, User>().ReverseMap();
    }
}