using SYS = System;
using SCG = System.Collections.Generic;

namespace IssueAndStoryTrackerApplication.Data
{
  /// <summary>
  /// Base class for services.
  /// </summary>
  [SYS.Serializable]
  public abstract class ServiceBase<T> where T : WorkInfoBase
  {
    #region Constructors

    /// <summary>
    /// Creates a fully initialized <see cref="ServiceBase{T}"/>
    /// using the given data context.
    /// </summary>
    /// <param name="dataContext">Provides access to the app's data context.</param>
    public ServiceBase( AppDataContext dataContext )
    {
      DataContext = dataContext;
    }

    #endregion

    #region Protected properties

    /// <summary>
    /// Provides access to the app's data context.
    /// </summary>
    protected AppDataContext DataContext
    {
      get;
      private set;
    }

    /// <summary>
    /// Status message for when a failure occurs while saving a <see cref="WorkInfoBase"/> entity.
    /// </summary>
    protected abstract string SaveFailureMessage
    {
      get;
    }

    /// <summary>
    /// Status message for when a <see cref="WorkInfoBase"/> entity is saved successfully.
    /// </summary>
    protected abstract string SaveSuccessMessage
    {
      get;
    }

    #endregion

    #region Public abstract method declarations

    /// <summary>
    /// Creates and saves a <see cref="WorkInfoBase"/> entity in the data context.
    /// </summary>
    /// <param name="item">A <see cref="WorkInfoBase"/> entity</param>
    /// <returns>A success or failure status message.</returns>
    public abstract string Create( T item );

    /// <summary>
    /// Returns a <see cref="WorkInfoBase"/> entity whose ID matches the given ID.
    /// </summary>
    /// <param name="itemID">Uniquely identifies a <see cref="WorkInfoBase"/> entity.</param>
    /// <returns>See method description.</returns>
    public abstract T GetByID( int itemID );

    /// <summary>
    /// Returns a collection of <see cref="WorkInfoBase"/> entity records in the data context.
    /// </summary>
    /// <returns>See method description.</returns>
    public abstract SCG.List<T> GetAll();

    /// <summary>
    /// Updates a <see cref="WorkInfoBase"/> entity
    /// in the data context with the given data.
    /// </summary>
    /// <param name="item">Updated <see cref="WorkInfoBase"/> entity data to write into the data context.</param>
    /// <returns>A success or failure message.</returns>
    public abstract string Update( T item );    

    #endregion
  }
}
