using FastEndpoints;
using Platy.AdventureWorks.Repository.Domain.Models;

namespace Platy.AdventureWorks.RestApi.Address;


public class Create : Endpoint<CreateAddressRequest, CreateAddressResponse>
{
  private readonly AddressRepository _repository;

  public Create(AddressRepository repository)
  {
    _repository = repository;
  }
   
  public override void Configure()
  {
    Post(CreateAddressRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      // XML Docs are used by default but are overridden by these properties:
      //s.Summary = "Create a new Contributor.";
      //s.Description = "Create a new Contributor. A valid name is required.";
      s.ExampleRequest = new CreateAddressRequest()
      {
        Data = new AddressCreateModel()
        {
         AddressID = 123,
         AddressLine1 = "123 address"
        }
      };
    });
  }
  
  
  public override async Task HandleAsync(
    CreateAddressRequest request,
    CancellationToken cancellationToken)
  {

    var result = await _repository.CreateAsync(request.Data, cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CreateAddressResponse(result.Value);
    }
    // TODO: Handle other cases as necessary
  }
}
