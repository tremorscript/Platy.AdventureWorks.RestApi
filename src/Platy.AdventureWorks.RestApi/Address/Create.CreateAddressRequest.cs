using System.ComponentModel.DataAnnotations;
using Platy.AdventureWorks.Repository.Domain.Models;

namespace Platy.AdventureWorks.RestApi.Address;

public class CreateAddressRequest
{
  public const string Route = "/Address";
  
  [Required] public AddressCreateModel Data { get; set; }
}
