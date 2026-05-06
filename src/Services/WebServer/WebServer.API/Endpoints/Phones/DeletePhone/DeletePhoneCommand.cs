namespace WebServer.API.Endpoints.Phones.DeletePhone;

public record DeletePhoneCommand(Guid PhoneId)
    : ICommand<DeletePhoneResult>;

public record DeletePhoneResult(bool IsSuccess);

public class DeletePhoneCommandValidator : AbstractValidator<DeletePhoneCommand>
{
    public DeletePhoneCommandValidator()
    {
        RuleFor(x => x.PhoneId).NotEmpty().WithMessage("PhoneId is required");
    }
}

public class DeletePhoneHandler(ApplicationDbContext dbContext)
    : ICommandHandler<DeletePhoneCommand, DeletePhoneResult>
{
    public async Task<DeletePhoneResult> Handle(DeletePhoneCommand command, CancellationToken cancellationToken)
    {
        // Delete Phone entity from command object.
        var phoneId = command.PhoneId;
        var phone = await dbContext.Phones
            .FindAsync([phoneId], cancellationToken: cancellationToken)
            ?? throw new PhoneNotFoundException(command.PhoneId);


        // TODO: Чи не силається на інші елементи.
        dbContext.Phones.Remove(phone);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeletePhoneResult(true);
    }
}
