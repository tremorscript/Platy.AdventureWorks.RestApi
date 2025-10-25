using Platy.AdventureWorks.Repository.Domain.Models;

namespace Platy.AdventureWorks.RestApi.Address;

public class CreateAddressResponse
{
  public CreateAddressResponse(AddressReadModel data)
  {
    Data = data;
  }

  public AddressReadModel Data { get; set; }
}
