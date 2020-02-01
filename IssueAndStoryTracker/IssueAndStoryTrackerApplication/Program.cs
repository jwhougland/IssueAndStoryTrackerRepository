using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace IssueAndStoryTrackerApplication
{
  /// <summary>
  /// This class provides the main method for the app
  /// and it creates a host builder to get the app going.
  /// </summary>
  public class Program
  {
    #region Public static methods

    /// <summary>
    /// Starter method for the program.
    /// </summary>
    /// <param name="args">Collection of arguments for the host builder creation activity.</param>
    public static void Main( string[] args )
    {
      CreateHostBuilder( args ).Build().Run();
    }

    /// <summary>
    /// Creates and returns a host builder.
    /// </summary>
    /// <param name="args">Collection of arguments for the default builder activity.</param>
    /// <returns>A host builder.</returns>
    public static IHostBuilder CreateHostBuilder( string[] args ) =>
        Host.CreateDefaultBuilder( args )
            .ConfigureWebHostDefaults( webBuilder =>
             {
              webBuilder.UseStartup<Startup>();
            } );

    #endregion
  }
}
