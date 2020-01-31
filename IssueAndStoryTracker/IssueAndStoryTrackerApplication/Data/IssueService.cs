using SYS = System;
using SCG = System.Collections.Generic;
using System.Linq;

namespace IssueAndStoryTrackerApplication.Data
{
  /// <summary>
  /// Provides access to the data for an issue.
  /// </summary>
  [SYS.Serializable]
  public class IssueService
  {
    #region Public constants
    
    /// <summary>
    /// Status message for when a failure occurs saving an issue.
    /// </summary>
    public const string IssueSaveFailureMsg = "An error occured saving the issue.  Please try again later.";

    /// <summary>
    /// Status message for when an issue is successfully saved.
    /// </summary>
    public const string IssueSaveSuccessMsg = "Issue saved successfully";

    #endregion

    #region Private member objects

    /// <summary>
    /// Provides access to the app's data context.
    /// </summary>
    private readonly AppDataContext m_dataContext;

    #endregion 

    #region Constructors

    /// <summary>
    /// Creates a fully initialized <see cref="IssueService"/>
    /// instance using the given data context.
    /// </summary>
    /// <param name="dataContext">Provies access to the app's data context.</param>
    public IssueService( AppDataContext dataContext )
    {
      m_dataContext = dataContext;
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Creates and saves an issue record in the data context.
    /// </summary>
    /// <param name="issue">Details of an issue.</param>
    /// <returns>A success or failure status message.</returns>
    public string CreateIssue( IssueInfo issue )
    {
      try
      {
        // Save off the current time
        SYS.DateTime currentTime = SYS.DateTime.Now;

        // Assign data to a few required properties
        issue.CreatedOn = currentTime;
        issue.LastUpdatedOn = currentTime;        
                
        // Attempt to add the issue to the context and save changes.
        m_dataContext.Issues.Add( issue );
        m_dataContext.SaveChanges();
      }
      catch (SYS.Exception)
      {
        // Report a failure.
        return IssueSaveFailureMsg;
      }

      // Report that the issue was saved successfully.
      return IssueSaveSuccessMsg;
    }

    /// <summary>
    /// This method returns an issue whose ID matches the given ID.
    /// </summary>
    /// <param name="issueID">Uniquely identifies an issue.</param>
    /// <returns>See method description.</returns>
    public IssueInfo GetIssueByID( int issueID ) => m_dataContext.Issues.Single( obj => obj.WorkInfoID == issueID );

    /// <summary>
    /// Returns a list of issue records in the data context.
    /// </summary>
    /// <returns>See method description.</returns>
    public SCG.List<IssueInfo> GetIssues() => m_dataContext.Issues.ToList();

    /// <summary>
    /// This method updates an issue record in
    /// teh data context with the given data.
    /// </summary>
    /// <param name="issue">Data to update in the data context.</param>
    /// <returns>A success or failure status message.</returns>
    public string UpdateIssue( IssueInfo issue )
    {
      try
      {
        // Attempt to update the issue record in the
        // context and save the changes in the context.
        issue.LastUpdatedOn = SYS.DateTime.Now;
        m_dataContext.Issues.Update( issue );
        m_dataContext.SaveChanges();
      }
      catch ( SYS.Exception )
      {
        // Report a failure.
        return IssueSaveFailureMsg;
      }

      // Report that the issue was saved successfully.
      return IssueSaveSuccessMsg;
    }

    #endregion 
  }
}
