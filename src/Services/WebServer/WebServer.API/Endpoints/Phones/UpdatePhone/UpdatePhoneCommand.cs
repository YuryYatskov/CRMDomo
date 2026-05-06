namespace WebServer.API.Endpoints.Phones.UpdatePhone;

public record UpdatePhoneCommand(PhoneDto Phone) : ICommand<UpdatePhoneResult>;

public record UpdatePhoneResult(bool IsSuccess);

public class UpdatePhoneCommandValidator : AbstractValidator<UpdatePhoneCommand>
{
    public UpdatePhoneCommandValidator()
    {
        RuleFor(x => x.Phone.Number).NotEmpty().WithMessage("Name is required");
    }
}

public class UpdateProducHandler(ApplicationDbContext dbContext)
    : ICommandHandler<UpdatePhoneCommand, UpdatePhoneResult>
{
    public async Task<UpdatePhoneResult> Handle(UpdatePhoneCommand command, CancellationToken cancellationToken)
    {
        var phoneId = command.Phone.Id;
        var phone = await dbContext.Phones
            .FindAsync([phoneId], cancellationToken: cancellationToken)
            ?? throw new PhoneNotFoundException(command.Phone.Id);

        UpdatePhoneWithNewValues(phone, command.Phone);

        dbContext.Phones.Update(phone);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdatePhoneResult(true);
    }

    private static void UpdatePhoneWithNewValues(Phone phone, PhoneDto phoneDto)
    {
        phone.Number = phoneDto.Number;
        phone.CounterpartyId = phoneDto.CounterpartyId;
    }
}