namespace Catalog.API.Products.CreateProduct;

public record CreateProudctRequest(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price
);

public record CreateProductResponse(
    Guid Id
);

public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products",
            async (CreateProudctRequest request, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = request.Adapt<CreateProductCommand>(); 
                var result = await sender.Send(command, cancellationToken);
                var response = result.Adapt<CreateProductResponse>();
                return Results.Created($"/products/{result.Id}", result);
            })
            .WithName("CreateProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithSummary("Create Product")
            .WithDescription("Create Product")
            .WithTags("Products");
    }
}
