namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;
public record DeleteProductResult(bool IsSuccess);

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID is required.");
    }
}

internal class DeleteProductCommandHandler(ApplicationDbContext context)
        : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        if (await context.Products.FindAsync([command.Id], cancellationToken: cancellationToken) is Product product)
        {
            context.Products.Remove(product);
            await context.SaveChangesAsync(cancellationToken);
            return new DeleteProductResult(true);
        }
        return new DeleteProductResult(false);
    }
}
