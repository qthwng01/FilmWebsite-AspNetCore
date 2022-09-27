using Jobject_Parse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Jobject_Parse.Data;
using X.PagedList;
using System;

namespace Jobject_Parse.Controllers
{
    //[Route("home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SearchDataContext _context;
        public HomeController(ILogger<HomeController> logger, SearchDataContext context)
        {
            _logger = logger;
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        //[Route("/trang-chu")]
        //[HttpGet("phim-moi")]
        public IActionResult Index()
        {
            using (var webClient = new WebClient())
            {
                var uri = webClient.DownloadString("https://ophim1.com/danh-sach/phim-moi-cap-nhat");

                //Lấy Array lồng nhau 
                JObject rootObject = JObject.Parse(uri);

                //Lấy ra mảng items
                JArray getItems = (JArray)rootObject["items"];
                ViewBag.GetInItems = getItems;

               /* foreach (var item in getItems)
                {
                    var n = item["slug"].ToString();
                    if (n == ViewData["cc"])
                    {
                        var uriSlug = webClient.DownloadString("https://ophim1.com/phim/" + n);
                        JArray jsonSlug = JArray.Parse("[" + uriSlug + "]");
                        ViewBag.slug = jsonSlug;
                    }
                }*/
            }
            return View();
        }

        [Route("/dach-sach")]
        public IActionResult Page(int page)
        {
            using (var webClient = new WebClient())
            {
                var jsonUrl = webClient.DownloadString("https://ophim1.com/danh-sach/phim-moi-cap-nhat?page=" + page);

                //Lấy Array lồng nhau 
                JObject rootObject = JObject.Parse(jsonUrl);

                //Lấy ra mảng items
                JArray getItems = (JArray)rootObject["items"];
                ViewBag.GetInItems = getItems;

            }
            return View();
        }

        [Route("/phim")]
        public IActionResult Detail(string slug)
        {

            if (slug == null)
            {
                return View("InvalidSlug");
            }

            else
            {
                using (var webClient = new WebClient())
                {
                    try
                    {
                        var jsonUrl = webClient.DownloadString("https://ophim1.com/phim/" + slug);

                        //Khai báo WebException || Url invalid
                        /*HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(jsonUrl);
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();*/

                        //Use method
                        //Lấy data sử dụng JArray
                        JArray jsonArray = JArray.Parse("[" + jsonUrl + "]");

                        //Lấy Array lồng nhau
                        //Mảng cha 
                        JObject rootObject = JObject.Parse(jsonUrl);

                        //Lấy ra mảng con server_data trong mảng cha episodes
                        JArray getEpisodes = (JArray)rootObject["episodes"];
                        JObject getInEpisodes = (JObject)getEpisodes[0];
                        JArray serverData = (JArray)getInEpisodes["server_data"];

                        //Lấy category
                        JArray getCategory = (JArray)rootObject["movie"]["category"];
                        ViewBag.GetCategory = getCategory;

                        //Console.WriteLine(serverData);
                        //JArray dataArray = (JArray) data[]
                        ViewBag.Data = jsonArray;
                        ViewBag.getServerData = serverData;
                    }

                    catch (WebException ex)
                    {
                        HttpWebResponse webResponse = (HttpWebResponse)ex.Response;
                        if (webResponse.StatusCode == HttpStatusCode.NotFound)
                        {
                            return View("InvalidSlug");
                        }
                    }
                }
            }
            return View();
        }


        [Route("/tim-kiem")]
        public IActionResult Search(string searchstring, int? page, string currentfilter)
        {
            try
            {
                var pageNumber = page ?? 1;
                int pageSize = 8;

                if (searchstring != null)
                {
                    pageNumber = 1;
                }
                else
                {
                    searchstring = currentfilter;
                }

                ViewData["currentfilter"] = searchstring;

                var result = from r in _context.SearchDatass
                             select r;
                if (!String.IsNullOrEmpty(searchstring))
                {
                    result = result.Where(s => s.Name.Contains(searchstring) || s.Origin_Name.Contains(searchstring));

                    ViewBag.result = result.Count();

                    if (result.Count() == 0)
                    {
                        return View("InvalidSlug");
                    }
                }
                return View(result.AsNoTracking().ToPagedList(pageNumber, pageSize));
            }
            catch(WebException ex)
            {
                HttpWebResponse webResponse = (HttpWebResponse)ex.Response;
                if (webResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    return NotFound();
                }
            }
            return View("InvalidSlug");
        }


        public IActionResult UpdateSearch()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSearch(UpdateSearch updateSearch)
        {
            int start = updateSearch.startPage;
            int end = updateSearch.endPage;

            JArray arr = new JArray();
            await Task.Run(() =>
            {
                for(var i = start; i <= end; i++)
                { 
                    var webClient = new WebClient();
                    var uri = webClient.DownloadString("https://ophim1.com/danh-sach/phim-moi-cap-nhat?page=" + i);

                    //Console.WriteLine("adding page", currentPage);

                    JObject rootObject = JObject.Parse(uri);
                    //Lấy ra mảng items
                    JArray getItems = (JArray)rootObject["items"];
                    //Push tất cả object "items" vào mảng mới
                    arr.Add(getItems);
                }

                var jarr = arr.Value<JArray>();
                ViewBag.GetInArrayNested = jarr;

                foreach (var item in jarr)
                {
                    List<Items> lst = item.ToObject<List<Items>>();
                    foreach (Items s in lst)
                    {
                        List<SearchDatass> searchDatas = new List<SearchDatass>();
                        searchDatas.Add(new SearchDatass {  _Id = s._Id,
                                                            Name = s.Name,
                                                            Origin_Name = s.Origin_Name,
                                                            Slug = s.Slug,
                                                            Year = s.Year});
                        _context.AddRange(searchDatas.Distinct().ToList());
                        _context.SaveChanges();
                    }
                }
            });
            var result = _context.SearchDatass
                        .AsEnumerable()
                        .GroupBy(s => new { s.Name, s.Origin_Name, s.Slug, s.Year }).SelectMany(grp => grp.Skip(1)).Count();
            ViewBag.dup = result;
            return View();
        }

        public IActionResult RemoveDuplicates()
        {
            var result = _context.SearchDatass
                        .AsEnumerable()
                        .GroupBy(s => new { s.Name, s.Origin_Name, s.Slug, s.Year }).SelectMany(grp => grp.Skip(1))
                        .ToList();
            _context.SearchDatass.RemoveRange(result);
            _context.SaveChanges();
            var count = _context.SearchDatass.Count();
            ViewBag.cc = count;
            return View();
        }

        [Route("/phim-khong-ton-tai")]
        public IActionResult InvalidSlug()
        {
            return View();
        }

        [Route("/tinh-nang")]
        public IActionResult Features()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
