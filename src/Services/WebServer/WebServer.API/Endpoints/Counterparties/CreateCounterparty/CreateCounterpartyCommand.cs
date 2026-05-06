namespace WebServer.API.Endpoints.Counterparties.CreateCounterparty;

public record CreateCounterpartyCommand(CounterpartyFullDto Counterparty)
    : ICommand<CreateCounterpartyResult>;

public record CreateCounterpartyResult(Guid Id);

public class CreateCounterpartyCommandValidator : AbstractValidator<CreateCounterpartyCommand>
{
    public CreateCounterpartyCommandValidator()
    {
        RuleFor(x => x.Counterparty.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Counterparty.Name).MaximumLength(100).WithMessage("The name must be 100 characters or fewer.");
        RuleFor(x => x.Counterparty.FullName).NotEmpty().WithMessage("Full name is required");
        RuleFor(x => x.Counterparty.FullName).MaximumLength(200).WithMessage("The full name must be 200 characters or fewer.");
        RuleFor(x => x.Counterparty.FormOfOwnership).NotNull().WithMessage("Form of ownership is required");
        RuleFor(x => x.Counterparty.Edrpou).Must(x => string.IsNullOrEmpty(x) == true || x.Length == 8).WithMessage("The EDRPOU must be 8 characters or fewer.");
        RuleFor(x => x.Counterparty.Tin).Must(x => string.IsNullOrEmpty(x) == true || x.Length == 10).WithMessage("The TIN must be 10 characters or fewer.");
        RuleFor(x => x.Counterparty.Description).MaximumLength(1000).WithMessage("The description must be 1000 characters or fewer.");
    }
}

public class CreateCounterpartyHandler(ApplicationDbContext dbContext)
    : ICommandHandler<CreateCounterpartyCommand, CreateCounterpartyResult>
{
    public async Task<CreateCounterpartyResult> Handle(CreateCounterpartyCommand command, CancellationToken cancellationToken)
    {
        Counterparty counterparty = new()
        {
            Id = Guid.NewGuid(),
            Name = command.Counterparty.Name,
            FullName = command.Counterparty.FullName,
            Supplier = command.Counterparty.Supplier,
            Seller = command.Counterparty.Seller,
            FormOfOwnership = command.Counterparty.FormOfOwnership,
            Edrpou = command.Counterparty.Edrpou,
            Tin = command.Counterparty.Tin,
            Description = command.Counterparty.Description,
        };
        dbContext.Counterparties.Add(counterparty);

        //IEnumerable<Phone> phones = command.Counterparty.Phones!.Select(x => new Phone { 
        //    Id = x.Id,
        //    Number = x.Number,
        //    CounterpartyId = counterparty.Id,
        //});
        //dbContext.Phones.AddRange(phones);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateCounterpartyResult(counterparty.Id);
    }
}
