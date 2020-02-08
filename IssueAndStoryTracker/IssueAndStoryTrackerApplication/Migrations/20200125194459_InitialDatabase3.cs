using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace IssueAndStoryTrackerApplication.Migrations
{
  public partial class InitialDatabase3 : Migration
  {
    protected override void Up( MigrationBuilder migrationBuilder )
    {
      migrationBuilder.CreateTable(
          name: "Issues",
          columns: table => new
          {
            WorkInfoID = table.Column<int>( nullable: false )
                  .Annotation( "SqlServer:Identity", "1, 1" ),
            AssignedSprint = table.Column<string>( nullable: true ),
            AssociatedProduct = table.Column<string>( nullable: false ),
            CreatedBy = table.Column<string>( nullable: false ),
            CreatedOn = table.Column<DateTime>( nullable: false ),
            EstimatedPoints = table.Column<string>( nullable: false ),
            LastUpdatedOn = table.Column<DateTime>( nullable: false ),
            SolutionProductVersion = table.Column<string>( maxLength: 50, nullable: true ),
            State = table.Column<string>( nullable: false ),
            Title = table.Column<string>( maxLength: 250, nullable: false ),
            WorkProductType = table.Column<string>( nullable: false ),
            AffectedProductVersion = table.Column<string>( maxLength: 50, nullable: false ),
            ExpectedBehavior = table.Column<string>( maxLength: 2000, nullable: false ),
            FoundBy = table.Column<string>( maxLength: 50, nullable: false ),
            ObservedBehavior = table.Column<string>( maxLength: 2000, nullable: false ),
            VerificationState = table.Column<string>( nullable: true ),
            VerifiedBy = table.Column<string>( maxLength: 50, nullable: true )
          },
          constraints: table =>
          {
            table.PrimaryKey( "PK_Issues", x => x.WorkInfoID );
          } );

      migrationBuilder.CreateTable(
          name: "Stories",
          columns: table => new
          {
            WorkInfoID = table.Column<int>( nullable: false )
                  .Annotation( "SqlServer:Identity", "1, 1" ),
            AssignedSprint = table.Column<string>( nullable: true ),
            AssociatedProduct = table.Column<string>( nullable: false ),
            CreatedBy = table.Column<string>( nullable: false ),
            CreatedOn = table.Column<DateTime>( nullable: false ),
            EstimatedPoints = table.Column<string>( nullable: false ),
            LastUpdatedOn = table.Column<DateTime>( nullable: false ),
            SolutionProductVersion = table.Column<string>( maxLength: 50, nullable: true ),
            State = table.Column<string>( nullable: false ),
            Title = table.Column<string>( maxLength: 250, nullable: false ),
            WorkProductType = table.Column<string>( nullable: false ),
            BusinessCase = table.Column<string>( maxLength: 500, nullable: false ),
            CompletionCriteria = table.Column<string>( maxLength: 4000, nullable: false ),
            RequestedBy = table.Column<string>( maxLength: 50, nullable: false ),
            StoryDescription = table.Column<string>( maxLength: 2000, nullable: false )
          },
          constraints: table =>
          {
            table.PrimaryKey( "PK_Stories", x => x.WorkInfoID );
          } );
    }

    protected override void Down( MigrationBuilder migrationBuilder )
    {
      migrationBuilder.DropTable(
          name: "Issues" );

      migrationBuilder.DropTable(
          name: "Stories" );
    }
  }
}
