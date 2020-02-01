using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ISTD = IssueAndStoryTrackerApplication.Data;

namespace IssueAndStoryTrackerApplication
{
  /// <summary>
  /// This class provides startup support for the app.
  /// </summary>
  public class Startup
  {
    #region Constructors

    /// <summary>
    /// Saves off the given configuration to a property.
    /// </summary>
    /// <param name="configuration">Represents key/value properties for the app's configuration.</param>
    public Startup( IConfiguration configuration )
    {
      Configuration = configuration;
    }

    #endregion

    #region Public properties

    /// <summary>
    /// Gets the app's configuration key/value properties.
    /// </summary>
    public IConfiguration Configuration { get; }

    #endregion

    #region Public methods

    /// <summary>
    /// This method gets called by the runtime. Use this method to add services to the container.
    /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    /// </summary>
    /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
    public void ConfigureServices( IServiceCollection services )
    {
      services.AddRazorPages();
      services.AddServerSideBlazor();      
      services.AddServerSideBlazor();
      services.AddScoped<ISTD.IssueService>();
      services.AddScoped<ISTD.StoryService>();
      services.AddDbContext<ISTD.AppDataContext>( options => options.UseSqlServer( Configuration.GetConnectionString( "DefaultConnection" ) ) );
    }

    /// <summary>
    /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    /// </summary>
    /// <param name="app">Defines a class that provides the mechanisms to configure an application's request pipeline.</param>
    /// <param name="env">Provides information about the web hosting environment an application is running in.</param>
    public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler( "/Error" );        
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseEndpoints( endpoints =>
       {
         endpoints.MapBlazorHub();
         endpoints.MapFallbackToPage( "/_Host" );
       } );
    }

    #endregion
  }
}
