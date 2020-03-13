using SYS = System;
using SCG = System.Collections.Generic;
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
    #region Public test methods
    
    /// <summary>
    /// This test instantiates the <see cref="ISTAD.IssueService"/>
    /// and verifies that a valid <see cref="ISTAD.IssueInfo"/> record
    /// can be created in the data context.
    /// </summary>
    [XU.Fact]
    public void CreateIssueTest()
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

      // Verify we found an issue in the context that equals the one we created
      XU.Assert.NotNull( queriedIssue );
    }

    /// <summary>
    /// This test instantiates the <see cref="ISTAD.IssueService"/>,
    /// creates an issue, and verifies we can retrieve the issue
    /// by its ID.
    /// </summary>
    [XU.Fact]
    public void GetByIDTest()
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
      service.Create( issue );

      // Query the context to get the issue we just made by its ID
      ISTAD.IssueInfo queriedIssue = service.GetByID( issue.WorkInfoID );

      // Verify the query result meets our expectations
      XU.Assert.Equal( issue, queriedIssue );
    }

    /// <summary>
    /// This test instantiates the <see cref="ISTAD.IssueService"/>
    /// creates multiple issues, and verifies we can retrieve them.
    /// </summary>
    [XU.Fact]
    public void GetAllTest()
    {
      // Create a valid issue info object
      ISTAD.IssueInfo issue1 = new ISTAD.IssueInfo()
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

      // Create another valid issue info object
      ISTAD.IssueInfo issue2 = new ISTAD.IssueInfo()
      {
        AffectedProductVersion = "1.0.0.0",
        ExpectedBehavior = "Product B is not cross validating text boxes X and Y",
        FoundBy = "Sandra Miller",
        ObservedBehavior = "Product B should cross validate text boxes X and B",
        AssociatedProduct = "Product B",
        CreatedBy = "smiller",
        EstimatedPoints = "2",
        Title = "Missing cross validations in Product B"
      };

      // Get a test data context instance
      ISTAD.AppDataContext dataContext = TestApplicationDataContextProvider.GetContext();

      // Instantiate the issue service class
      IssueServiceStub service = new IssueServiceStub( dataContext );

      // Save both issues in the context
      service.Create( issue1 );
      service.Create( issue2 );

      // Query the context for all issues
      SCG.List<ISTAD.IssueInfo> queriedIssues = service.GetAll();

      // Verify we have all expected issues in the context
      XU.Assert.True( queriedIssues.Contains( issue1 ) && queriedIssues.Contains( issue2 ) );
    }

    /// <summary>
    /// This test instantiates the <see cref="ISTAD.IssueService"/>,
    /// creates an issue, and verifies we can update the issue.
    /// </summary>
    [XU.Fact]
    public void UpdateTest()
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

      // Query the context to get the issue we just made by its ID
      ISTAD.IssueInfo queriedIssue = service.GetByID( issue.WorkInfoID );

      // Verify the get by ID method returned what we expect
      XU.Assert.Equal( issue, queriedIssue );

      // Save off the initial value for the last updated timestamp
      SYS.DateTime initialUpdateTimestamp = queriedIssue.LastUpdatedOn;

      // Now let's update the issue locally
      issue.AffectedProductVersion = "1.0.0.1";

      // Update the issue in the context
      service.Update( issue );

      // Query the context to get the issue we've updated
      ISTAD.IssueInfo queriedUpdatedIssue = service.GetByID( issue.WorkInfoID );

      // Verify the get by ID method returned what we expect
      XU.Assert.Equal( issue, queriedUpdatedIssue );

      // Verify the last updated on property got updated
      XU.Assert.True( queriedUpdatedIssue.LastUpdatedOn.CompareTo( initialUpdateTimestamp ) > 0 );
    }

    #endregion
  }
}
