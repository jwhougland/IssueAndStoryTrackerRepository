using SYS = System;
using SCG = System.Collections.Generic;
using System.Linq;

namespace IssueAndStoryTrackerApplication.Data
{
  /// <summary>
  /// Provides access to the data for a story.
  /// </summary>
  [SYS.Serializable]
  public class StoryService : ServiceBase<StoryInfo>
  {
    #region Constructors

    /// <summary>
    /// Creates a fully initialized <see cref="StoryService"/>
    /// instance using the given data context.
    /// </summary>
    /// <param name="dataContext">Provides access to the app's data context.</param>
    public StoryService( AppDataContext dataContext ) : base( dataContext )
    {
      // No processing
    }

    #endregion

    #region ServiceBase overrides

    /// <summary>
    /// Status message for when a failure occurs saving a story.
    /// </summary>
    protected override string SaveFailureMessage => 
      "An error occurred saving the story.  Please try again later";

    /// <summary>
    /// Status message for when a story is successfully saved.
    /// </summary>
    protected override string SaveSuccessMessage => 
      "Story saved successfully";

    /// <summary>
    /// Creates and saves a story record in the data context.
    /// </summary>
    /// <param name="story">Details of a story.</param>
    /// <returns>A success or failure status message.</returns>
    public override string Create( StoryInfo story )
    {
      try
      {
        // Save off the current time.
        SYS.DateTime currentTime = SYS.DateTime.Now;

        // Assign data to a few required timestamp properties
        story.CreatedOn = currentTime;
        story.LastUpdatedOn = currentTime;

        // Attempt to add the story to the context and save changes
        DataContext.Stories.Add( story );
        DataContext.SaveChanges();
      }
      catch( SYS.Exception )
      {
        // Report a failure
        return SaveFailureMessage;
      }

      // Report that the issue was saved successfully
      return SaveSuccessMessage;
    }

    /// <summary>
    /// This method returns a story whose ID matches the given ID.
    /// </summary>
    /// <param name="storyID">Uniquely identifies a story.</param>
    /// <returns>See method description.</returns>
    public override StoryInfo GetByID( int storyID ) => DataContext.Stories.Single( obj => obj.WorkInfoID == storyID );

    /// <summary>
    /// Returns a collection of story records in the data context.
    /// </summary>
    /// <returns>See method description.</returns>
    public override SCG.List<StoryInfo> GetAll() => DataContext.Stories.ToList();

    /// <summary>
    /// This method updates a story record in
    /// the data context with the given data.
    /// </summary>
    /// <param name="story">Data to update in the data context.</param>
    /// <returns>A success or failure status message.</returns>
    public override string Update( StoryInfo story )
    {
      try
      {
        // Attempt to update the story record in
        // the context and save the changes
        story.LastUpdatedOn = SYS.DateTime.Now;
        DataContext.Stories.Update( story );
        DataContext.SaveChanges();
      }
      catch ( SYS.Exception )
      {
        // Report a failure
        return SaveFailureMessage;
      }

      // Report that the story was saved successfully
      return SaveSuccessMessage;
    }

    #endregion 
  }
}
