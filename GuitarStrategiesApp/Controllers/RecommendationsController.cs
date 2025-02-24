using Microsoft.AspNetCore.Mvc;
using GuitarStrategiesApp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;

namespace GuitarStrategiesApp.Controllers
{
    public class RecommendationsController : Controller
    {
        private static List<Recommendation> recommendations = new List<Recommendation>();
        private static int nextId = 1; // Unique ID for tracking recommendations

        [HttpGet]
        public IActionResult Index()
        {
            return View(recommendations);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecommendation(string category, string link)
        {
            if (string.IsNullOrEmpty(category) || string.IsNullOrEmpty(link))
            {
                ViewBag.Error = "Category and link are required.";
                return View("Index", recommendations);
            }

            string title = await GetPageTitleAsync(link) ?? "Unknown Title";
            string thumbnail = GetThumbnailUrl(link);

            recommendations.Add(new Recommendation
            {
                Id = nextId++, // Assign a unique ID
                Category = category,
                Title = title,
                Link = link,
                ThumbnailUrl = thumbnail
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveRecommendation(int id)
        {
            recommendations.RemoveAll(r => r.Id == id);
            return RedirectToAction("Index");
        }

        private async Task<string> GetPageTitleAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string htmlContent = await client.GetStringAsync(url);
                    Match match = Regex.Match(htmlContent, @"<title>\s*(.+?)\s*</title>", RegexOptions.IgnoreCase);
                    return match.Success ? match.Groups[1].Value : null;
                }
                catch
                {
                    return null; // Handle errors gracefully
                }
            }
        }

        private string GetThumbnailUrl(string url)
        {
            if (url.Contains("youtube.com") || url.Contains("youtu.be"))
            {
                var videoIdMatch = Regex.Match(url, @"(?:v=|\/)([0-9A-Za-z_-]{11})");
                if (videoIdMatch.Success)
                {
                    return $"https://img.youtube.com/vi/{videoIdMatch.Groups[1].Value}/hqdefault.jpg";
                }
            }
            else if (url.Contains("amazon.com"))
            {
                string asin = ExtractAmazonASIN(url);
                if (!string.IsNullOrEmpty(asin))
                {
                    return $"https://images-na.ssl-images-amazon.com/images/P/{asin}.jpg"; // Amazon standard product image URL
                }
            }
            return "https://via.placeholder.com/150"; // Default placeholder image
        }

        private string ExtractAmazonASIN(string url)
        {
            Match match = Regex.Match(url, @"\/dp\/([A-Z0-9]{10})");
            return match.Success ? match.Groups[1].Value : null;
        }
    }
}