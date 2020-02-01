using SYS = System;
using SCG = System.Collections.Generic;
using System.Linq;

namespace IssueAndStoryTrackerApplication.Data
{
  /// <summary>
  /// Provides access to the data for an issue.
  /// </summary>
  [SYS.Serializable]
  public class IssueService : ServiceBase<IssueInfo>
  {
    #region Constructors

    /// <summary>
    /// Creates a fully initialized <see cref="IssueService"/>
    /// instance using the given data context.
    /// </summary>
    /// <param name="dataContext">Provies access to the app's data context.</param>
    public IssueService( AppDataContext dataContext ) : base( dataContext )
    {
      // No processing
    }

    #endregion

    #region ServiceBase overrides

    /// <summary>
    /// Status message for when a failure occurs saving an issue.
    /// </summary>
    protected override string SaveFailureMessage =>
      "An error occured saving the issue.  Please try again later.";

    /// <summary>
    /// Status message for when an issue is successfully saved.
    /// </summary>
    protected override string SaveSuccessMessage =>
      "Issue saved successfully";

    /// <summary>
    /// Creates and saves an issue record in the data context.
    /// </summary>
    /// <param name="issue">Details of an issue.</param>
    /// <returns>A success or failure status message.</returns>
    public override string Create( IssueInfo issue )
    {
      try
      {
        // Save off the current time
        SYS.DateTime currentTime = SYS.DateTime.Now;

        // Assign data to a few required timestamp properties
        issue.CreatedOn = currentTime;
        issue.LastUpdatedOn = currentTime;        
                
        // Attempt to add the issue to the context and save changes
        DataContext.Issues.Add( issue );
        DataContext.SaveChanges();
      }
      catch ( SYS.Exception )
      {
        // Report a failure
        return SaveFailureMessage;
      }

      // Report that the issue was saved successfully
      return SaveSuccessMessage;
    }

    /// <summary>
    /// This method returns an issue whose ID matches the given ID.
    /// </summary>
    /// <param name="issueID">Uniquely identifies an issue.</param>
    /// <returns>See method description.</returns>
    public override IssueInfo GetByID( int issueID ) =>
      DataContext.Issues.Single( obj => obj.WorkInfoID == issueID );

    /// <summary>
    /// Returns a collection of issue records in the data context.
    /// </summary>
    /// <returns>See method description.</returns>
    public override SCG.List<IssueInfo> GetAll() =>
      DataContext.Issues.ToList();

    /// <summary>
    /// This method updates an issue record in
    /// the data context with the given data.
    /// </summary>
    /// <param name="issue">Data to update in the data context.</param>
    /// <returns>A success or failure status message.</returns>
    public override string Update( IssueInfo issue )
    {
      try
      {
        // Attempt to update the issue record in
        // the context and save the changes
        issue.LastUpdatedOn = SYS.DateTime.Now;
        DataContext.Issues.Update( issue );
        DataContext.SaveChanges();
      }
      catch ( SYS.Exception )
      {
        // Report a failure
        return SaveFailureMessage;
      }

      // Report that the issue was saved successfully
      return SaveSuccessMessage;
    }

    #endregion 
  }
}
