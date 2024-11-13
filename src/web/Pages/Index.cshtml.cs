using Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Dapper;
using Azure.Storage.Blobs;
using Azure.Identity;
using Azure.Core;

namespace Web.Pages;

public class IndexModel : PageModel
{
    public IEnumerable<Movie> Movies = new Movie[] { };
    private readonly IConfiguration _config;

    public IndexModel(IConfiguration config)
    {
        _config = config;
    }

    public void OnGet()
    {
        Movies = new List<Movie>{
            new Movie{Title="Movie 1", Released=new DateTime(2000,1,1), Rating=5},
            new Movie{Title="Movie 2", Released=new DateTime(2010,2,12), Rating=7.6m},
            new Movie{Title="Movie 3", Released=new DateTime(2015,3,22), Rating=10},
        };
    }
}
