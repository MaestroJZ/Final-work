
using System.Numerics;
using Application.DTOs;
using Domain.Models;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Contracts;
using Microsoft.Extensions.Options;
using Nethereum.Hex.HexTypes;
using Nethereum.Util;

namespace Application.Services.Impls;
public class BlockchainService : IBlockchainService
{
    private readonly Web3 _web3;
    private readonly string _contractAddress;
    private readonly string _abi;
    private readonly Contract _contract;

    public BlockchainService(IOptions<BlockchainSettings> blockchainSettings)
    {
        var settings = blockchainSettings.Value;
        var account = new Account(settings.PrivateKey);
        _web3 = new Web3(account, settings.NodeUrl);
        _contractAddress = settings.ContractAddress;
        

        var abiFullPath = Path.GetFullPath(settings.AbiFilePath);

        if (!File.Exists(abiFullPath))
        {
            throw new FileNotFoundException($"ABI file not found at {abiFullPath}");
        }

        _abi = File.ReadAllText(abiFullPath);
        
        _contract = _web3.Eth.GetContract(_abi, _contractAddress);
    }

    public async Task<string> VoteAsync(Guid id)
    {
        var voteFunction = _contract.GetFunction("vote");
        var gas = new HexBigInteger(3000000);
        var gasPrice = new HexBigInteger(Web3.Convert.ToWei(20, UnitConversion.EthUnit.Gwei));
        var index = new BigInteger(id.ToByteArray().Concat(new byte[] { 0 }).ToArray());
        var transactionHash  = await voteFunction.SendTransactionAsync(
            _web3.TransactionManager.Account.Address,
            gas,
            gasPrice,
            null,
            index);
        return transactionHash;
    }
}