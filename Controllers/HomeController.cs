using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ButterCMS;
using ButterCMS.Models;
using Microsoft.AspNetCore.Mvc;
using TestButter.Models;

namespace TestButter.Controllers
{
    public class HomeController : Controller
    {
       
        private string apiToken = "670e1d9327682dcdaa052f6fd3943f40e02e9e1b";
       
        public IActionResult Index()
        {
            var client = new ButterCMSClient(apiToken);
            PostsResponse responses = client.ListPosts(1, 10);
            List<Post> posts = new List<Post>();
            foreach (Post postResp in responses.Data)
            {
                
                posts.Add(postResp);
            }
            ViewData["allPosts"] = posts;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
