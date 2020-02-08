using SYS = System;
using System.Linq;
using XU = Xunit;
using ISTAD = IssueAndStoryTrackerApplication.Data;

namespace IssueAndStoryTrackerUnitTests
{
  /// <summary>
  /// This class contains the unit tests for the 
  /// <see cref="ISTAD.IssueService"/>.
  /// </summary>
  [SYS.Serializable]
  public class IssueServiceUnitTests
  {
    /// <summary>
    /// This test instantiates the <see cref="ISTAD.IssueService"/>
    /// and verifies that a valid <see cref="ISTAD.IssueInfo"/> record
    /// can be created in the data context.
    /// </summary>
    [XU.Fact]
    public void CreateIssueTest1()
    {
      // Create a valid issue info object
      ISTAD.IssueInfo issue = new ISTAD.IssueInfo()
      {
        AffectedProductVersion = "1.0.0.0",
        ExpectedBehavior = "Product A is not validating ranges in text boxes X and Y.",
        FoundBy = "John Smith",
        ObservedBehavior = "Product A should range check text boxes X and Y",
        AssociatedProduct = "Product A",
        CreatedBy = "jsmith",        
        EstimatedPoints = "1",
        Title = "Missing range checks in Product A"
      };

      // Get a test data context instance
      ISTAD.AppDataContext dataContext = TestApplicationDataContextProvider.GetContext();

      // Instantiate the issue service class
      IssueServiceStub service = new IssueServiceStub( dataContext );

      // Attempt to store an issue in the data context
      string saveResult = service.Create( issue );

      // Verify the save result string contains the expected value
      XU.Assert.Equal( service.SaveSuccessStringStub, saveResult );

      // Query the context for an issue that equals the one we created
      ISTAD.IssueInfo queriedIssue = service
        .GetAll()
        .SingleOrDefault( obj => obj.Equals( issue ) );

      // Verify the queried issue is not null
      XU.Assert.NotNull( queriedIssue );
    }
  }
}
