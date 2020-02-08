using SYS = System;
using ISTAD = IssueAndStoryTrackerApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace IssueAndStoryTrackerUnitTests
{
  /// <summary>
  /// This class provides in-memory data contexts for unit testing.
  /// </summary>
  internal static class TestApplicationDataContextProvider
  {
    #region Internal static methods

    /// <summary>
    /// This method initializes and returns an in-memory application data context.
    /// </summary>
    /// <returns>See method description.</returns>
    internal static ISTAD.AppDataContext GetContext()
    {
      DbContextOptions<ISTAD.AppDataContext> options = new DbContextOptionsBuilder<ISTAD.AppDataContext>()
        .UseInMemoryDatabase( SYS.Guid.NewGuid().ToString() )
        .Options;

      return new ISTAD.AppDataContext( options );
    }

    #endregion
  }
}
