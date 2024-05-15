using System.Numerics;
using Application.DTOs;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class VotingController : BaseController
{
    private readonly IBlockchainService _blockchainService;
    private readonly IVoterService _voterService;
    private readonly ICandidateService _candidateService;
    private readonly IElectionService _electionService;
    private readonly ITransactionService _transactionService;
    private readonly IVoteService _voteService;
    
    public VotingController(
        IVoterService voterService,
        IBlockchainService blockchainService,
        ICandidateService candiateService,
        IElectionService electionService,
        ITransactionService transactionService,
        IVoteService voteService)
    {
        _voterService = voterService;
        _blockchainService = blockchainService;
        _candidateService = candiateService;
        _electionService = electionService;
        _transactionService = transactionService;
        _voteService = voteService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Vote([FromBody] VoteDto voteRequest)
    {
        var election = await _electionService.Get(voteRequest.ElectionId);
        if (election == null)
            return BadRequest("Сайлау табылмады");

        if (election.StartDate > DateTime.Now || election.EndDate < DateTime.Now)
        {
            return BadRequest("Сайлауға дауыс беру жабылды");
        }
        
        var candidate = await _candidateService.Get(voteRequest.CandidateId);
        if (candidate == null)
            return BadRequest("Үміткер табылмады");
        
        var voter = await _voterService.Get(voteRequest.VoterId);
        if (voter == null)
            return BadRequest("Дауыс беруші табылмады");

        var vote = await _voteService.GetAll(
            x => x.ElectionId == voteRequest.ElectionId
                 && x.VoterId == voteRequest.VoterId);

        if (vote.Count > 0)
        {
            return ResponseError("Сіз бұл сайлауда дауыс бергенсіз");
        }
        
        try
        {
            var result = await _blockchainService.VoteAsync(voteRequest.CandidateId);
            var transaction = new TransactionDto
            {
                Hash = result,
                CandidateId = voteRequest.CandidateId
            };
            await _transactionService.Add(transaction);

            var voteDto = new VoteDto
            {
                CandidateId = voteRequest.CandidateId,
                ElectionId = voteRequest.ElectionId,
                VoterId = voteRequest.VoterId
            };
            await _voteService.Add(voteDto);
            return ResponseOk("Сіздің дауысыңыз есептелді");
        }
        catch (Exception ex)
        {
            return ResponseException(ex);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetVoteByCandidate(Guid candidateId)
    {
        var candidate = await _candidateService.Get(candidateId);
        if (candidate == null)
            return BadRequest("Үміткер табылмады");
        try
        {
            var result = await _transactionService.GetAll(x => x.CandidateId == candidateId);
            return ResponseOk(result.Count);
        }
        catch (Exception ex)
        {
            return ResponseException(ex);
        }
    }
    
}