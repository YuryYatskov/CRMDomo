using BuildingBlocks.Types.Enums;

namespace BuildingBlocks.DTO.Dtos;

public class CounterpartyLiteDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
}

public class CounterpartyDto : CounterpartyLiteDto
{
    public bool Supplier { get; set; }
    public bool Seller { get; set; }
}

public class CounterpartyFullDto : CounterpartyDto
{
    public string FullName { get; set; } = default!;
    public FormOfOwnership FormOfOwnership { get; set; }
    public string? Edrpou { get; set; }
    public string? Tin { get; set; }
    public string? Description { get; set; }

    public List<PhoneLiteDto>? Phones { get; set; }
}
