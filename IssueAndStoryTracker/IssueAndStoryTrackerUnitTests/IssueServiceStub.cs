using ISTAD = IssueAndStoryTrackerApplication.Data;

namespace IssueAndStoryTrackerUnitTests
{
  /// <summary>
  /// This class inherits from the 
  /// <see cref="ISTAD.IssueService"/>
  /// for unit testing purposes.
  /// </summary>
  internal class IssueServiceStub : ISTAD.IssueService
  {
    #region Constructors

    /// <summary>
    /// Creates a fully initialized <see cref="IssueServiceStub"/>
    /// instance using the given <see cref="ISTAD.AppDataContext"/>.
    /// </summary>
    /// <param name="dataContext">Provides access to our test app's data context.</param>
    public IssueServiceStub( ISTAD.AppDataContext dataContext ) 
      : base( dataContext )
    {
      // No processing
    }

    #endregion

    #region Public properties

    /// <summary>
    /// Gets a <see cref="ISTAD.IssueService"/> instance's
    /// protected <see cref="ISTAD.IssueService.SaveFailureMessage"/>
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
    /// Gets a <see cref="ISTAD.IssueService"/> instance's
    /// protected <see cref="ISTAD.IssueService.SaveSuccessMessage"/>
    /// string value.
    /// </summary>
    public string SaveSuccessStringStub
    {
      get
      {
        return SaveSuccessMessage;
      }
    }

    #endregion Public properties
  }
}
