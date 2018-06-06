using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchType.Equals("all"))
            {
                List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                ViewBag.title = "All Jobs";
                ViewBag.columns = ListController.columnChoices;
                ViewBag.items = jobs;
                return View("Index");
            }
            else
            {
                List<Dictionary<string, string>> items = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = "All " + ListController.columnChoices[searchType] + " Values";
                ViewBag.columns = ListController.columnChoices;
                ViewBag.items = items;
                return View("Index");
            }
        }

        public IActionResult Jobs(string column, string value)
        {
            List<Dictionary<String, String>> jobs = JobData.FindByColumnAndValue(column, value);
            ViewBag.title = "Jobs with " + ListController.columnChoices[column] + ": " + value;
            ViewBag.jobs = jobs;

            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

    }
}
