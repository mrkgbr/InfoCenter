using InfoCenter.Api.DTOs.Contract;
using InfoCenter.Api.Models;

namespace InfoCenter.Api.Mappers;

public static class ContractMappers
{
    public static ContractDTO ToDTO(this Contract contractModel)
    {
        return new ContractDTO
        {
            Id = contractModel.Id,
            ContractNumber = contractModel.ContractNumber,
            Name = contractModel.Name,
            Description = contractModel.Description,
            StartDate = contractModel.StartDate,
            EndDate = contractModel.EndDate,
            IsActive = contractModel.IsActive
        };
    }

    public static Contract ToModelFromCreateDTO(this CreateContractDTO contractDTO)
    {
        return new Contract
        {
            ContractNumber = contractDTO.ContractNumber,
            Name = contractDTO.Name,
            Description = contractDTO.Description,
            StartDate = contractDTO.StartDate,
            EndDate = contractDTO.EndDate
        };
    }
}
