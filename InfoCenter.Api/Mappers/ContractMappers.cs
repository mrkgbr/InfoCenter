using InfoCenter.Api.DTOs.Contract;
using InfoCenter.Api.Models;

namespace InfoCenter.Api.Mappers;

public static class ContractMappers
{
    public static ContractDTO ToDTO(this Contract contractModel)
    {
        return new ContractDTO
        (
            contractModel.Id,
            contractModel.ContractNumber,
            contractModel.Name,
            contractModel.Description,
            contractModel.StartDate,
            contractModel.EndDate,
            contractModel.IsActive
        );
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