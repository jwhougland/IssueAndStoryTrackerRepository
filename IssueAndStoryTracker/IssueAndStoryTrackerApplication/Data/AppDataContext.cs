using MSEFC = Microsoft.EntityFrameworkCore;
using SYS = System;

namespace IssueAndStoryTrackerApplication.Data
{
  /// <summary>
  /// This class initializes the data context and any related data sets within the context.
  /// </summary>
  [SYS.Serializable]
  public class AppDataContext : MSEFC.DbContext
  {
    #region Constructors

    /// <summary>
    /// Creates a fully initialized <see cref="AppDataContext"/> instance
    /// using the given options.
    /// </summary>
    /// <param name="options">Data context options</param>
    public AppDataContext( MSEFC.DbContextOptions<AppDataContext> options )
      : base( options )
    {
      // No processing
    }

    #endregion

    #region Public properties

    /// <summary>
    /// Gets or sets the <see cref="IssueInfo"/> records in the data context.
    /// </summary>
    public MSEFC.DbSet<IssueInfo> Issues
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the <see cref="StoryInfo"/> records in the data context.
    /// </summary>
    public MSEFC.DbSet<StoryInfo> Stories
    {
      get;
      set;
    }

    #endregion
  }
}
