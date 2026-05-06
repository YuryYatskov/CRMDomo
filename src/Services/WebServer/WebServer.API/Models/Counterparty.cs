namespace WebServer.API.Models;

public class Counterparty
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string FullName { get; set; } = default!;

    public bool Supplier { get; set; }

    public bool Seller { get; set; }

    public FormOfOwnership FormOfOwnership { get; set; }

    public string? Edrpou { get; set; } 

    public string? Tin { get; set; } 

    public string? Description { get; set; }

    public IEnumerable<Phone>? Phones { get; set; }
}
