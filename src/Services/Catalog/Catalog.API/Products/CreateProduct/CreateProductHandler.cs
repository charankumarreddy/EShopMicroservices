namespace Catalog.API.Products.CreateProduct;

// we are passing all this vars to create the product record by using CQRS desgin patern 
public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<CreateProductResult>;

// after save the record in db gettting only id 
public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {

        // Create the product entity 
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };
        // Save database 
        return new CreateProductResult(Guid.NewGuid());
        //throw new NotImplementedException();
    }
}
