namespace WebServer.API.Endpoints.Phones.CreatePhone;

public record CreatePhoneCommand(PhoneDto Phone)
    : ICommand<CreatePhoneResult>;

public record CreatePhoneResult(Guid Id);

public class CreatePhoneCommandValidator : AbstractValidator<CreatePhoneCommand>
{
    public CreatePhoneCommandValidator()
    {
        RuleFor(x => x.Phone.Number).NotEmpty().WithMessage("Name is required");
    }
}

public class CreatePhoneHandler(ApplicationDbContext dbContext)
    : ICommandHandler<CreatePhoneCommand, CreatePhoneResult>
{
    public async Task<CreatePhoneResult> Handle(CreatePhoneCommand command, CancellationToken cancellationToken)
    {
        Phone phone = new()
        {
            Id = Guid.NewGuid(),
            Number = command.Phone.Number,
            CounterpartyId = command.Phone.CounterpartyId,
        };

        dbContext.Phones.Add(phone);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreatePhoneResult(phone.Id);
    }
}
