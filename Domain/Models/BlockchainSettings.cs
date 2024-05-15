namespace Domain.Models;

public class BlockchainSettings
{
    public string NodeUrl { get; set; }
    public string ContractAddress { get; set; }
    public string PrivateKey { get; set; }
    public string AbiFilePath { get; set; }
}