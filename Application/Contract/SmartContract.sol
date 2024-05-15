pragma solidity ^0.8.0;

contract VotingContract {
    struct Candidate {
        uint id;
        string name;
        uint voteCount;
    }

    struct Voter {
        bool voted;
        uint candidateId;
    }

    mapping(uint => Candidate) public candidates;
    mapping(address => Voter) public voters;

    event Voted(uint indexed candidateId);

    function vote(uint _candidateId) public {
        require(!voters[msg.sender].voted);
        require(candidates[_candidateId].id != 0);

        candidates[_candidateId].voteCount++;
        voters[msg.sender].voted = true;
        voters[msg.sender].candidateId = _candidateId;

        emit Voted(_candidateId);
    }
}