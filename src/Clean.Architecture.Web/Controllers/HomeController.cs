namespace Clean.Architecture.Web.Controllers;

using System.Diagnostics;
using ViewModels;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// A sample MVC controller that uses views.
/// Razor Pages provides a better way to manage view-based content, since the behavior, viewmodel, and view are all in one place,
/// rather than spread between 3 different folders in your Web project. Look in /Pages to see examples.
/// See: https://ardalis.com/aspnet-core-razor-pages-%E2%80%93-worth-checking-out/
/// TODO.
/// </summary>
public class HomeController : Controller
{
  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>TODO LATER.</returns>
  public IActionResult Index()
  {
    return View();
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>TODO LATER.</returns>
  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error() =>
    View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
