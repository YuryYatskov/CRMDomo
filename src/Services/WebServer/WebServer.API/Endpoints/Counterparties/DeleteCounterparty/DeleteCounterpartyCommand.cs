namespace WebServer.API.Endpoints.Counterparties.DeleteCounterparty;

public record DeleteCounterpartyCommand(Guid CounterpartyId)
    : ICommand<DeleteCounterpartyResult>;

public record DeleteCounterpartyResult(bool IsSuccess);

public class DeleteCounterpartyCommandValidator : AbstractValidator<DeleteCounterpartyCommand>
{
    public DeleteCounterpartyCommandValidator()
    {
        RuleFor(x => x.CounterpartyId).NotEmpty().WithMessage("CounterpartyId is required");
    }
}

public class DeleteCounterpartyHandler(ApplicationDbContext dbContext)
    : ICommandHandler<DeleteCounterpartyCommand, DeleteCounterpartyResult>
{
    public async Task<DeleteCounterpartyResult> Handle(DeleteCounterpartyCommand command, CancellationToken cancellationToken)
    {
        // Delete Counterparty entity from command object.
        var counterpartyId = command.CounterpartyId;
        var counterparty = await dbContext.Counterparties
            .FindAsync([counterpartyId], cancellationToken: cancellationToken)
            ?? throw new CounterpartyNotFoundException(command.CounterpartyId);


        // TODO: Delete related Phones, if any. Consider using cascade delete in the database.
        dbContext.Counterparties.Remove(counterparty);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteCounterpartyResult(true);
    }
}
