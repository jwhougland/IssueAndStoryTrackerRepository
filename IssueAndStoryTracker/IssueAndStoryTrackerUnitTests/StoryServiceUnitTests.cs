using SYS = System;
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

    #endregion
  }
}
