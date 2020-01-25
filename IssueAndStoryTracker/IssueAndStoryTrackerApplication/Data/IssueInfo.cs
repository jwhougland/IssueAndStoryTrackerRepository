using SYS = System;
using SCD = System.ComponentModel.DataAnnotations;

namespace IssueAndStoryTrackerApplication.Data
{
  /// <summary>
  /// This class defines the data for an issue tracking object.
  /// </summary>
  [SYS.Serializable]
  public class IssueInfo : WorkInfoBase
  {
    #region Constructors

    /// <summary>
    /// Creates a fully initialized <see cref="IssueInfo"/> instance.
    /// </summary>
    public IssueInfo() 
      : base()
    {
      // No processing
    }

    #endregion

    #region Public properties

    /// <summary>
    /// Gets or sets the first known product version where a defected was introduced.
    /// </summary>
    [SCD.Required]
    [SCD.StringLength( ProductVersionLengthMax, ErrorMessage = ProductVersionLengthErrorMsg )]
    [SCD.RegularExpression( AllowedCharactersRegex, ErrorMessage = ProhibitedCharactersErrorMsg )]
    public string AffectedProductVersion
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the expected behavior for an issue.
    /// </summary>
    [SCD.Required]
    [SCD.StringLength( DescriptionLengthMax, ErrorMessage = DescriptionLengthErrorMsg )]
    [SCD.RegularExpression( AllowedCharactersRegex, ErrorMessage = ProhibitedCharactersErrorMsg )]
    public string ExpectedBehavior
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the string identifier of the person who found the issue.
    /// </summary>
    [SCD.Required]
    [SCD.StringLength( PersonalIdentifierMaxLength, ErrorMessage = PersonalIdentifierLengthErrorMsg )]
    [SCD.RegularExpression( AllowedCharactersRegex, ErrorMessage = ProhibitedCharactersErrorMsg )]
    public string FoundBy
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the obeserved behavior for an issue.
    /// </summary>
    [SCD.Required]
    [SCD.StringLength( DescriptionLengthMax, ErrorMessage = DescriptionLengthErrorMsg )]
    [SCD.RegularExpression( AllowedCharactersRegex, ErrorMessage = ProhibitedCharactersErrorMsg )]
    public string ObservedBehavior
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the verification state for the issue.
    /// </summary>
    public string VerificationState
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the personal identifier of the issue verifier.
    /// </summary>
    [SCD.StringLength( PersonalIdentifierMaxLength, ErrorMessage = PersonalIdentifierLengthErrorMsg )]
    [SCD.RegularExpression( AllowedCharactersRegex, ErrorMessage = ProhibitedCharactersErrorMsg )]
    public string VerifiedBy
    {
      get;
      set;
    }

    #endregion
  }
}
