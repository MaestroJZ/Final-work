using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class VotingController : BaseController
{
    private readonly IVotingService _votingService;

    public VotingController(IVotingService votingService)
    {
        _votingService = votingService;
    }

    [HttpPost]
    public async Task<IActionResult> Vote(int votingId, int ballotOptionId, string fullName, string phoneNumber)
    {
        try
        {
            bool success = await _votingService.Vote(votingId, ballotOptionId, fullName, phoneNumber);
            if (success)
                return Ok("Vote registered successfully");
            else
                return NotFound("Voting or ballot option not found, or user already voted");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}