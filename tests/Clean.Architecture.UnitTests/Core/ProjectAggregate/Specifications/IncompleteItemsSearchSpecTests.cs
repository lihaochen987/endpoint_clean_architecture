// namespace Clean.Architecture.UnitTests.Core.ProjectAggregate.Specifications;
//
// using Clean.Architecture.Core.ContributorAggregate;
// using Clean.Architecture.Core.ProjectAggregate.Specifications;
// using Builders;
// using Shouldly;
// using Xunit;
//
// /// <summary>
// /// Tests the ContributorById specification.
// /// </summary>
// public class IncompleteitemsSearchSpecTests
// {
//   private readonly int _testContributorId = 123;
//
//   /// <summary>
//   /// Tests whether a Contributor can be successfully retrieved by Id.
//   /// </summary>
//   [Fact]
//   public void SuccessfullyGetsContributorById()
//   {
//     // Arrange
//     var spec = new IncompleteItemsSearchSpec(_testContributorId);
//
//     // Act
//     var result = spec.Evaluate(GetSingleItem()).FirstOrDefault();
//
//     // Assert
//     result.ShouldNotBeNull();
//     result.Id.ShouldBe(_testContributorId);
//   }
//
//   private List<ToDoItem> GetSingleItem()
//   {
//     var contributor = new ContributorBuilder().WithDefaultValues().Id(123).Build();
//     return new List<Contributor> { contributor };
//   }
// }
