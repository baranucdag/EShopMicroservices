
using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price):ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler 
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        //perform business logic
        var product = new Product()
        {
            Name = request.Name,
            Description = request.Description,
            ImageFile = request.ImageFile,
            Category = request.Category,
            Price = request.Price
        };
        
        //save to db
        
        return new CreateProductResult(Guid.NewGuid());
    }
} 