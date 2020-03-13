using SYS = System;
using SCG = System.Collections.Generic;
using System.Linq;
using XU = Xunit;
using ISTAD = IssueAndStoryTrackerApplication.Data;

namespace IssueAndStoryTrackerUnitTests
{
  /// <summary>
  /// This class contains the unit tests for
  /// the <see cref="ISTAD.StoryService"/>.
  /// </summary>
  [SYS.Serializable]
  public class StoryServiceUnitTests
  {
    #region Public test methods

    /// <summary>
    /// This test instantiates the <see cref="ISTAD.StoryService"/>
    /// and verifies that a valid <see cref="ISTAD.StoryInfo"/> record
    /// can be created in the data context.
    /// </summary>
    [XU.Fact]
    public void CreateStoryTest()
    {
      // Create a valid story info object
      ISTAD.StoryInfo story = new ISTAD.StoryInfo()
      {
        BusinessCase = "This story provides the ability to increase user efficiency by streamlining user tasks",
        CompletionCriteria = "User trials show a reduction in time on Tasks A, B, and C by 20%",
        RequestedBy = "Release Train Engineer",
        StoryDescription = "Make instructions and user experience for Tasks A/B/C better based on user feedback",
        AssociatedProduct = "Product A",
        CreatedBy = "jedwards",
        EstimatedPoints = "5",
        Title = "As an RTE, I want to incorporate user feedback into Product A, so that we can increase user efficiency by 20%"
      };

      // Create a test data context instance
      ISTAD.AppDataContext dataContext = TestApplicationDataContextProvider.GetContext();

      // Instantiate the story service class
      StoryServiceStub service = new StoryServiceStub( dataContext );

      // Attempt to store a story in the data context
      string saveResult = service.Create( story );

      // Verify the save result string contains the expected value
      XU.Assert.Equal( service.SaveSuccessStringStub, saveResult );

      // Query the context for a story that equals the one we created
      ISTAD.StoryInfo queriedStory = service
        .GetAll()
        .SingleOrDefault( obj => obj.Equals( story ) );

      // Verify we found a story in the context that equals the one we created
      XU.Assert.NotNull( queriedStory );
    }    

    /// <summary>
    /// This test instantiates the <see cref="ISTAD.StoryService"/>,
    /// creates a story, and verifies we can retrieve the story
    /// by its ID.
    /// </summary>
    [XU.Fact]
    public void GetByIDTest()
    {
      // Create a valid story info object
      ISTAD.StoryInfo story = new ISTAD.StoryInfo()
      {
        BusinessCase = "This story provides the ability to increase user efficiency by streamlining user tasks",
        CompletionCriteria = "User trials show a reduction in time on Tasks A, B, and C by 20%",
        RequestedBy = "Release Train Engineer",
        StoryDescription = "Make instructions and user experience for Tasks A/B/C better based on user feedback",
        AssociatedProduct = "Product A",
        CreatedBy = "jedwards",
        EstimatedPoints = "5",
        Title = "As an RTE, I want to incorporate user feedback into Product A, so that we can increase user efficiency by 20%"
      };

      // Get a test data context instance
      ISTAD.AppDataContext dataContext = TestApplicationDataContextProvider.GetContext();

      // Instantiate the story service class
      StoryServiceStub service = new StoryServiceStub( dataContext );

      // Attempt to store a story in the data context
      service.Create( story );

      // Query the context to get the story we just made by its ID
      ISTAD.StoryInfo queriedStory = service.GetByID( story.WorkInfoID );

      // Verify the query result meets our expectations
      XU.Assert.Equal( story, queriedStory );
    }

    /// <summary>
    /// This test instantiates the <see cref="ISTAD.StoryService"/>,
    /// creates multiple stories, and verifies we can retrieve them.
    /// </summary>
    [XU.Fact]
    public void GetAllTest()
    {
      // Create a valid story info object
      ISTAD.StoryInfo story1 = new ISTAD.StoryInfo()
      {
        BusinessCase = "This story provides the ability to increase user efficiency by streamlining user tasks",
        CompletionCriteria = "User trials show a reduction in time on Tasks A, B, and C by 20%",
        RequestedBy = "Release Train Engineer",
        StoryDescription = "Make instructions and user experience for Tasks A/B/C better based on user feedback",
        AssociatedProduct = "Product A",
        CreatedBy = "jedwards",
        EstimatedPoints = "5",
        Title = "As an RTE, I want to incorporate user feedback into Product A, so that we can increase user efficiency by 20%"
      };

      // Create another valid story info object
      ISTAD.StoryInfo story2 = new ISTAD.StoryInfo()
      {
        BusinessCase = "This story increases user satisfaction by allowing for configuration of preferences requested from user feedback",
        CompletionCriteria = "New requirements for user preferences are implemented and pass verification",
        RequestedBy = "Release Train Engineer",
        StoryDescription = "Allow users to configure preferences on topics A-E per recent user feedback",
        AssociatedProduct = "Product B",
        CreatedBy = "msmith",
        EstimatedPoints = "5",
        Title = "As an RTE, I want to incorporate user feedback into Product B, so that we can allow for highly requested user preferences to be configured"
      };

      // Get a test data context instance
      ISTAD.AppDataContext dataContext = TestApplicationDataContextProvider.GetContext();

      // Instantiate the story service class
      StoryServiceStub service = new StoryServiceStub( dataContext );

      // Save both stories in the context
      service.Create( story1 );
      service.Create( story2 );

      // Query the context for all stories
      SCG.List<ISTAD.StoryInfo> queriedStories = service.GetAll();

      // Verify we have all expected stories in the context
      XU.Assert.True( queriedStories.Contains( story1 ) && queriedStories.Contains( story2 ) );
    }

    /// <summary>
    /// This test instantiates the <see cref="ISTAD.StoryService"/>,
    /// creates a story, and verifies we can update the story.
    /// </summary>
    [XU.Fact]
    public void UpdateStory()
    {
      // Create a valid story info object
      ISTAD.StoryInfo story = new ISTAD.StoryInfo()
      {
        BusinessCase = "This story provides the ability to increase user efficiency by streamlining user tasks",
        CompletionCriteria = "User trials show a reduction in time on Tasks A, B, and C by 20%",
        RequestedBy = "Release Train Engineer",
        StoryDescription = "Make instructions and user experience for Tasks A/B/C better based on user feedback",
        AssociatedProduct = "Product A",
        CreatedBy = "jedwards",
        EstimatedPoints = "5",
        Title = "As an RTE, I want to incorporate user feedback into Product A, so that we can increase user efficiency by 20%"
      };

      // Get a test data context instance
      ISTAD.AppDataContext dataContext = TestApplicationDataContextProvider.GetContext();

      // Instantiate the story service class
      StoryServiceStub service = new StoryServiceStub( dataContext );

      // Attempt to store a story in the data context
      service.Create( story );

      // Query the context to get the story we just made by its ID
      ISTAD.StoryInfo queriedStory = service.GetByID( story.WorkInfoID );

      // Verify the query result meets our expectations
      XU.Assert.Equal( story, queriedStory );

      // Save off the initial value for the last updated timestamp
      SYS.DateTime initialTimestamp = queriedStory.LastUpdatedOn;

      // Now let's update the story locally
      story.AssignedSprint = "5";

      // Update the story in the context
      service.Update( story );

      // Query the context to get the story we've updated
      ISTAD.StoryInfo queriedUpdatedStory = service.GetByID( story.WorkInfoID );

      // Verify the query result meets our expectations
      XU.Assert.Equal( story, queriedUpdatedStory );

      // Verify the last updated on property got updated
      XU.Assert.True( queriedUpdatedStory.LastUpdatedOn.CompareTo( initialTimestamp ) > 0 );
    }

    #endregion
  }
}
