namespace WebServer.API.Endpoints.Counterparties.UpdateCounterparty;

public record UpdateCounterpartyCommand(CounterpartyFullDto Counterparty) : ICommand<UpdateCounterpartyResult>;

public record UpdateCounterpartyResult(bool IsSuccess);

public class UpdateCounterpartyCommandValidator : AbstractValidator<UpdateCounterpartyCommand>
{
    public UpdateCounterpartyCommandValidator()
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

public class UpdateProducHandler(ApplicationDbContext dbContext)
    : ICommandHandler<UpdateCounterpartyCommand, UpdateCounterpartyResult>
{
    public async Task<UpdateCounterpartyResult> Handle(UpdateCounterpartyCommand command, CancellationToken cancellationToken)
    {
        var counterpartyId = command.Counterparty.Id;
        var counterparty = await dbContext.Counterparties
            .Where(x => x.Id == counterpartyId)
            .Include(x => x.Phones)
            .FirstAsync(cancellationToken: cancellationToken)
            ?? throw new CounterpartyNotFoundException(command.Counterparty.Id);

        UpdateCounterpartyWithNewValues(counterparty, command.Counterparty);

        dbContext.Counterparties.Update(counterparty);

        //IEnumerable<Phone> phonesUpd = [];
        //IEnumerable<Phone> phonesDel = [];

        //UpdatePhonesWithNewValues(phonesUpd, phonesDel, counterparty.Phones!, command.Counterparty.Phones!);

        //if(phonesUpd.Any())
        //    dbContext.Phones.UpdateRange(phonesUpd);

        //if (phonesDel.Any())
        //    dbContext.Phones.RemoveRange(phonesDel);

        //await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateCounterpartyResult(true);
    }

    private static void UpdateCounterpartyWithNewValues(Counterparty counterparty, CounterpartyFullDto counterpartyDto)
    {
        counterparty.Name = counterpartyDto.Name;
        counterparty.FullName = counterpartyDto.FullName;
        counterparty.Supplier = counterpartyDto.Supplier;
        counterparty.Seller = counterpartyDto.Seller;
        counterparty.FormOfOwnership = counterpartyDto.FormOfOwnership;
        counterparty.Edrpou = counterpartyDto.Edrpou;
        counterparty.Tin = counterpartyDto.Tin;
        counterparty.Description = counterpartyDto.Description;
    }

    private static void UpdatePhonesWithNewValues(
        IEnumerable<Phone> phonesUpd,
        IEnumerable<Phone> phonesDel,
        IEnumerable<Phone> phones,
        IEnumerable<PhoneLiteDto> phonesLite)
    {
        IEnumerable<PhoneLiteDto>? phonesLiteNew = phonesLite.ExceptBy(phones.Select(x => x.Id), p => p.Id);
    }
}
