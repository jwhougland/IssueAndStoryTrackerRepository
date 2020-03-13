using ISTAD = IssueAndStoryTrackerApplication.Data;

namespace IssueAndStoryTrackerUnitTests
{
  /// <summary>
  /// This class inherits from the
  /// <see cref="ISTAD.StoryService"/>
  /// for unit testing purposes.
  /// </summary>
  internal class StoryServiceStub : ISTAD.StoryService
  {
    #region Constructors

    /// <summary>
    /// Creates a fully initialized <see cref="StoryServiceStub"/>
    /// instance using the given <see cref="ISTAD.AppDataContext"/>.
    /// </summary>
    /// <param name="dataContext">Provides access to our test app's data context.</param>
    internal StoryServiceStub( ISTAD.AppDataContext dataContext )
      : base( dataContext )
    {
      // No processing
    }

    #endregion

    /// <summary>
    /// Gets a <see cref="ISTAD.StoryService"/> instance's
    /// protected <see cref="ISTAD.StoryService.SaveFailureMessage"/>
    /// string value.
    /// </summary>
    public string SaveFailureStringStub
    {
      get
      {
        return SaveFailureMessage;
      }
    }

    /// <summary>
    /// Gets a <see cref="ISTAD.StoryService"/> instance's
    /// protected <see cref="ISTAD.StoryService.SaveSuccessMessage"/>
    /// string value.
    /// </summary>
    public string SaveSuccessStringStub
    {
      get
      {
        return SaveSuccessMessage;
      }
    }
  }
}
