using Ardalis.Result.AspNetCore;
using Platy.AdventureWorks.Repository.Domain.Models;

namespace Platy.AdventureWorks.RestApi.Address;


/// <summary>
///  Creates a new Address
/// </summary>
public class Create(IAddressRepository repository) : Endpoint<CreateAddressRequest, CreateAddressResponse>
{
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
         AddressLine1 = "123 address"
         
        }
      };
    });
  }
  
  
  public override async Task HandleAsync(
    CreateAddressRequest request,
    CancellationToken cancellationToken)
  {

    var result = await repository.CreateAsync(request.Data, cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CreateAddressResponse(result.Value);
      return;
    }
    // TODO: Handle other cases as necessary
    
    await SendResultAsync(result.ToMinimalApiResult());
  }
}
