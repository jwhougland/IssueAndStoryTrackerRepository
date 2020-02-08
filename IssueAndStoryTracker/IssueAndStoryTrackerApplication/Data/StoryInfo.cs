using SCD = System.ComponentModel.DataAnnotations;
using SYS = System;

namespace IssueAndStoryTrackerApplication.Data
{
  /// <summary>
  /// This class defines the data for a story tracking object.
  /// </summary>
  [SYS.Serializable]
  public class StoryInfo : WorkInfoBase
  {
    #region Public constants

    /// <summary>
    /// Error message for when the business case exceeds the maximum number of allowed characters.
    /// </summary>
    public const string BusinessCaseLengthErrorMsg = "Business case cannot exceed {1} characters";

    /// <summary>
    /// The maximum number of characters for a business case.
    /// </summary>
    public const int BusinessCaseLengthMax = 500;

    /// <summary>
    /// Error message for when the completion criteria exceeds the maximum number of allowed characters.
    /// </summary>
    public const string CompletionCriteriaErrorMsg = "Completion criteria cannot exceed {1} characters";

    /// <summary>
    /// The maximum number of characters for completion criteria.
    /// </summary>
    public const int CompletionCriteriaLengthMax = 4000;

    #endregion 

    #region Constructors

    /// <summary>
    /// Creates a fully initialized <see cref="StoryInfo"/> instance.
    /// </summary>
    public StoryInfo()
      : base()
    {
      // No processing
    }

    #endregion

    #region Public properties

    /// <summary>
    /// Gets or sets the business case for working a story.
    /// </summary>
    [SCD.Required]
    [SCD.StringLength( BusinessCaseLengthMax, ErrorMessage = BusinessCaseLengthErrorMsg )]
    [SCD.RegularExpression( AllowedCharactersRegex, ErrorMessage = ProhibitedCharactersErrorMsg )]
    public string BusinessCase
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the completion criteria for a story.
    /// </summary>
    [SCD.Required]
    [SCD.StringLength( CompletionCriteriaLengthMax, ErrorMessage = CompletionCriteriaErrorMsg )]
    [SCD.RegularExpression( AllowedCharactersRegex, ErrorMessage = ProhibitedCharactersErrorMsg )]
    public string CompletionCriteria
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the personal identifier for the person who requested the story.
    /// </summary>
    [SCD.Required]
    [SCD.StringLength( PersonalIdentifierMaxLength, ErrorMessage = PersonalIdentifierLengthErrorMsg )]
    [SCD.RegularExpression( AllowedCharactersRegex, ErrorMessage = ProhibitedCharactersErrorMsg )]
    public string RequestedBy
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the description for a story.
    /// </summary>
    [SCD.Required]
    [SCD.StringLength( DescriptionLengthMax, ErrorMessage = DescriptionLengthErrorMsg )]
    [SCD.RegularExpression( AllowedCharactersRegex, ErrorMessage = ProhibitedCharactersErrorMsg )]
    public string StoryDescription
    {
      get;
      set;
    }

    #endregion
  }
}
