using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using PlayingWReddit.Models;

namespace PlayingWReddit.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Reddit()
        {
            //requests to reddit for information
            HttpWebRequest request = WebRequest.CreateHttp("https://www.reddit.com/r/aww/.json");//gives it a URL and gives that URL a string from where youre requesting it from
            //we want the Json of that page
            //reddit will send a result back, and we want to collect it
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();//sends back a JSON (javascript object notation) response
            StreamReader rd = new StreamReader(response.GetResponseStream());//starts a streamreader to read the data in our response
            string data = rd.ReadToEnd(); //reads all the data from the JSOn Result
            JObject redditJson = JObject.Parse(data); //represents a JSON object (which is a chunk of Key value pairs), parses the reader data form the response into a JSON object
            List<JToken> posts = redditJson["data"]["children"].ToList(); //Jtoken are abstract chucks of JSON data (for a specified amount of time - like a backend cookie that holds info in your browser to compare with the frontend cookie) for each
            List<RedditPost> output = new List<RedditPost>();//makes a list of reddit posts to make objects of instances of this class to actually output results
            for(int i =0; i <posts.Count; i++)//makes it easier to access things using the index i
            {
                RedditPost rp = new RedditPost(); //makes an object to populate to list, then displays each property of RedditPost
                rp.Title = posts[i]["data"]["title"].ToString();
                rp.ImageURL = posts[i]["data"]["thumbnail"].ToString();
                rp.LinkURL = "http://reddit.com/" + posts[i]["data"]["permalink"].ToString();
                output.Add(rp);//adds each object to the RedditPost List
            }
            return View(output);//return output to view
        }
    }
}