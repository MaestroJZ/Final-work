using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Infrastructure.DAO.Repositories;

namespace Application.Services.Impls;

public class VotingService : BaseService<Voting, VotingDto>, IVotingService
{
    public VotingService(IBaseRepository<Voting> repository, IMapper mapper) : base(repository, mapper)
    {
    }
    private readonly IBallotService _ballotOptionService;
    private readonly IVoteService _voteService;

    public VotingService(IBaseRepository<Voting> repository, IMapper mapper,
        IBallotService ballotOptionService, IVoteService voteService)
        : base(repository, mapper)
    {
        _ballotOptionService = ballotOptionService;
        _voteService = voteService;
    }

    public async Task<bool> Vote(int votingId, int ballotOptionId, string fullName, string phoneNumber)
    {
        // Проверяем, существует ли голосование с указанным идентификатором
        var voting = await _repository.SelectFirst(x => x.Id == votingId);
        if (voting == null)
            return false; // Голосование не найдено

        // Проверяем, существует ли вариант выбора с указанным идентификатором
        var ballotOption = await _ballotOptionService.Get(x => x.Id == ballotOptionId);
        if (ballotOption == null)
            return false; // Вариант выбора не найден

        // Проверяем, не голосовал ли пользователь ранее
        var existingVote = await _voteService.Get(x => x.VotingId == votingId && x.PhoneNumber == phoneNumber);
        if (existingVote != null)
            return false; // Пользователь уже проголосовал

        // Создаем голос
        var voteDto = new VoteDto
        {
            VotingId = votingId,
            BallotOptionId = ballotOptionId,
            FullName = fullName,
            PhoneNumber = phoneNumber,
            VoteDate = DateTime.Now
        };

        await _voteService.Add(voteDto);
        return true; // Голос успешно учтен
    }
}