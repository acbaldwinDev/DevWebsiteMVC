using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DevWebsiteMVC.Models;

namespace DevWebsiteMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult AngularExample()
    {
        return View();
    }

    [HttpGet]
    public IActionResult ReportIssue()
    {
        return View(new IssueReportViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ReportIssue(IssueReportViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        TempData["IssueReportedMessage"] = "Thanks, your issue report was submitted.";
        return RedirectToAction(nameof(ReportIssue));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
