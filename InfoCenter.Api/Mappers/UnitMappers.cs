using InfoCenter.Api.DTOs.Unit;
using InfoCenter.Api.Models;

namespace InfoCenter.Api.Mappers;

public static class UnitMappers
{
    public static UnitDTO ToDTO(this Unit unit)
    {
        return new UnitDTO
        (
            unit.Id,
            unit.Name,
            unit.Description,
            unit.IsActive
        );
    }
    public static Unit ToModelFromCreateDTO(this CreateUnitDTO unitDTO)
    {
        return new Unit
        {
            Name = unitDTO.Name,
            Description = unitDTO.Description,
        };
    }
}
