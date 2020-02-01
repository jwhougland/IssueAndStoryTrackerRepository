using SYS = System;
using SCD = System.ComponentModel.DataAnnotations;

namespace IssueAndStoryTrackerApplication.Data
{
  /// <summary>
  /// This abstract base class defines the data
  /// that is common to a work planning object.
  /// </summary>
  [SYS.Serializable]
  public abstract class WorkInfoBase
  {
    #region Public constants

    /// <summary>
    /// Regular expression for allowed characters.
    /// </summary>
    public const string AllowedCharactersRegex = @"[A-Za-z0-9 _.,!]*";

    /// <summary>
    /// Error message for when a work object description's maximum length in characters is exceeded.
    /// </summary>
    public const string DescriptionLengthErrorMsg = "Description cannot exceed {1} characters";

    /// <summary>
    /// The maximum number of characters for a work object description.
    /// </summary>
    public const int DescriptionLengthMax = 2000;

    /// <summary>
    /// Error message for when a personal identifier's maximum length in characters is exceeded.
    /// </summary>
    public const string PersonalIdentifierLengthErrorMsg = "Personal identifier string cannot exceed {1} characters";

    /// <summary>
    /// The maximum number of allowed characters to identify a person associated with a work object.
    /// </summary>
    public const int PersonalIdentifierMaxLength = 50;

    /// <summary>
    /// Error message for when a product version's maximum length in characters is exceeded.
    /// </summary>
    public const string ProductVersionLengthErrorMsg = "Product Version cannot exceed {1} characters.";

    /// <summary>
    /// The maximum number of characters for a product version.
    /// </summary>
    public const int ProductVersionLengthMax = 50;

    /// <summary>
    /// Error message for when a prohibited character is used.
    /// </summary>
    public const string ProhibitedCharactersErrorMsg = "Only alpha-numeric characters, spaces, periods, commans, and exclamation marks are allowed.";

    /// <summary>
    /// Error message for when a title's maximum length in characters is exceeded.
    /// </summary>
    public const string TitleLengthErrorMsg = "Title cannot exceed {1} characters.";

    /// <summary>
    /// The maximum number of allowed characters for a work planning object's title.    
    /// </summary>
    public const int TitleLengthMax = 250;

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a fully initialized <see cref="WorkInfoBase"/> instance.
    /// </summary>
    public WorkInfoBase()
    {      
      // No processing
    }

    #endregion

    #region Public properties

    /// <summary>
    /// Gets or privately sets the primary key for a work planning object.
    /// </summary>
    [SCD.Key]
    public int WorkInfoID
    {
      get;
      private set;
    }

    /// <summary>
    /// Gets or sets the assigned sprint for a work planning object.
    /// </summary>    
    public string AssignedSprint
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the software product name that a work planning object is written against.
    /// </summary>
    [SCD.Required]
    public string AssociatedProduct
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the name of the person who created the work planning object.
    /// </summary>
    [SCD.Required]
    public string CreatedBy
    {
      get;
      set;
    } = "System";

    /// <summary>
    /// Gets or sets the date and time when a work planning object was created.
    /// </summary>
    [SCD.Required]
    public SYS.DateTime CreatedOn
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the estimated number of points for a work planning object.
    /// </summary>
    [SCD.Required]
    public string EstimatedPoints
    {
      get;
      set;
    }
       
    /// <summary>
    /// Gets or sets the date and time when a work planning object was last updated.
    /// </summary>
    [SCD.Required]
    public SYS.DateTime LastUpdatedOn
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the product version in which the work planning object is resolved.
    /// </summary>
    [SCD.StringLength( ProductVersionLengthMax, ErrorMessage = ProductVersionLengthErrorMsg )]
    [SCD.RegularExpression( AllowedCharactersRegex, ErrorMessage = ProhibitedCharactersErrorMsg )]
    public string SolutionProductVersion
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the current process state for a work planning object.
    /// </summary>
    [SCD.Required]
    public string State
    {
      get;
      set;
    } = "Created";

    /// <summary>
    /// Gets or sets the title of a work planning object.
    /// </summary>
    [SCD.Required]
    [SCD.StringLength( TitleLengthMax, ErrorMessage = TitleLengthErrorMsg )]
    [SCD.RegularExpression( AllowedCharactersRegex , ErrorMessage = ProhibitedCharactersErrorMsg )]
    public string Title
    { 
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the work product type that will be created or updated
    /// as the work planning object traverses through the normal process.
    /// </summary>
    [SCD.Required]
    public string WorkProductType
    {
      get;
      set;
    }

    #endregion
  }
}
