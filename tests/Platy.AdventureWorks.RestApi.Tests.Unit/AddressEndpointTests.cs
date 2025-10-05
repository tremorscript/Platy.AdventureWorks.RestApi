using Ardalis.Result;
using FastEndpoints;
using NSubstitute;
using Platy.AdventureWorks.Repository;
using Platy.AdventureWorks.Repository.Domain.Models;
using Platy.AdventureWorks.RestApi.Address;
using Shouldly;

namespace Platy.AdventureWorks.RestApi.Tests.Unit;

public class AddressEndpointTests
{
  /// <summary>
  ///   Unit tests for the AddressRepository.
  ///   Methods should follow the naming convention:- [MethodWeTest_StateUnderTest_ExpectedBehavior]
  ///   [HTTPMethod]_[MethodName]_[StateUnderTest]_ThenTheAPIReturnsExpected[Http_Code]
  /// </summary>
  [Fact]
  public async Task Create_ValidAddress_ReturnsSuccess()
  {
    // Arrange
    var createAddressRequest = new CreateAddressRequest()
    {
      Data = new AddressCreateModel()
      {
        AddressLine1 = "Test1",
        AddressLine2 = "Test2",
        City = "Test",
        StateProvinceId = 123,
        PostalCode = "12345"
      }
    };
    
    var result = Result<AddressReadModel>.Success(new AddressReadModel()
    {
      AddressLine1 = "Test1",
      AddressLine2 = "Test2",
      City = "Test",
      StateProvinceId = 123,
      PostalCode = "12345"
    });

    var repository = Substitute.For<IAddressRepository>();
    repository.CreateAsync(createAddressRequest.Data, CancellationToken.None).Returns(result);

    var create = Factory.Create<Create>(repository);

    // Act
    await create.HandleAsync(createAddressRequest, CancellationToken.None);
    var response = create.Response;

    // Assert
    response.ShouldNotBeNull();
    response.Data.ShouldNotBeNull();
    response.Data.AddressLine1.ShouldBe("Test1");

  }
}
