using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleWebFrontend_ASP_NETCORE31.Models;

namespace SimpleWebFrontend_ASP_NETCORE31.Controllers
{
    public class HomeController : Controller
    {
        json_data_getting json_data = new json_data_getting();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["ModelTypeCode_LIST"] = json_data.ModelTypeCode_list;
            ViewData["LatestOrder_LIST"] = json_data.LatestOrder_list;
            ViewData["HotestOrder_LIST"] = json_data.HotestOrder_list;
            ViewData["Phonenumber_LIST"] = json_data.Phonenumber_list;
            ViewData["Social_LIST"] = json_data.Socail_list;
            if(ViewData["ModelTypeCode_LIST"] == null | ViewData["LatestOrder_LIST"] == null | ViewData["HotestOrder_LIST"] == null | ViewData["Phonenumber_LIST"] == null | ViewData["Social_LIST"] == null)
            {
                return Redirect("/Error/NullData");
            }
            return View();
        }
        public IActionResult About()
        {
            ViewData["ModelTypeCode_LIST"] = json_data.ModelTypeCode_list;
            ViewData["Phonenumber_LIST"] = json_data.Phonenumber_list;
            ViewData["Social_LIST"] = json_data.Socail_list;
            if (ViewData["ModelTypeCode_LIST"] == null | ViewData["Phonenumber_LIST"] == null | ViewData["Social_LIST"] == null)
            {
                return Redirect("/Error/NullData");
            }
            return View();
        }
        public IActionResult Contact()
        {
            ViewData["ModelTypeCode_LIST"] = json_data.ModelTypeCode_list;
            ViewData["Phonenumber_LIST"] = json_data.Phonenumber_list;
            ViewData["Social_LIST"] = json_data.Socail_list;
            if (ViewData["ModelTypeCode_LIST"] == null | ViewData["Phonenumber_LIST"] == null | ViewData["Social_LIST"] == null)
            {
                return Redirect("/Error/NullData");
            }
            return View();
        }
        public IActionResult Payment()
        {
            ViewData["ModelTypeCode_LIST"] = json_data.ModelTypeCode_list;
            ViewData["Phonenumber_LIST"] = json_data.Phonenumber_list;
            ViewData["Social_LIST"] = json_data.Socail_list;
            ViewData["Payment_LIST"] = json_data.Payment_list;
            if (ViewData["ModelTypeCode_LIST"] == null | ViewData["Phonenumber_LIST"] == null | ViewData["Social_LIST"] == null | ViewData["Payment_LIST"] == null)
            {
                return Redirect("/Error/NullData");
            }
            return View();
        }
        public IActionResult Tracking()
        {
            ViewData["ModelTypeCode_LIST"] = json_data.ModelTypeCode_list;
            ViewData["Phonenumber_LIST"] = json_data.Phonenumber_list;
            ViewData["Social_LIST"] = json_data.Socail_list;
            if (ViewData["ModelTypeCode_LIST"] == null | ViewData["Phonenumber_LIST"] == null | ViewData["Social_LIST"] == null)
            {
                return Redirect("/Error/NullData");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Order(string ModelType)
        {
            ViewData["ModelTypeCode_LIST"] = json_data.ModelTypeCode_list;
            ViewData["Phonenumber_LIST"] = json_data.Phonenumber_list;
            ViewData["Social_LIST"] = json_data.Socail_list;
            if (ViewData["ModelTypeCode_LIST"] == null | ViewData["Phonenumber_LIST"] == null | ViewData["Social_LIST"] == null)
            {
                return Redirect("/Error/NullData");
            }
            try
            {
                if (json_data.ModelTypeCode_list[ModelType] != null)
                {
                    ViewData["ModelType"] = ModelType;
                    return Redirect("/Order/Search?ModelType=" + ModelType);
                }
                else
                {
                    return Redirect("/Home");
                }
            }
            catch (Exception)
            {
                return Redirect("/Home");
            }
            
        }
        [HttpGet]
        [HttpPost]
        public IActionResult GetOrder(string OrderCode)
        {
            if(Request.Method == "GET")
            {
                string OrderCode_TMP = "";
                try
                {
                    OrderCode_TMP = HttpContext.Session.GetString(session_data.Session_Order_Name);
                }
                catch(Exception)
                {
                    OrderCode_TMP = null;
                }
                if(OrderCode_TMP == null)
                {
                    return Redirect("/Home/NotFoundOrder");
                }
                else
                {
                    bool DataCheck = false;
                    if(json_data.Order_list == null)
                    {
                        return Redirect("/Error/NullData");
                    }
                    foreach (var check_tmp in json_data.Order_list as Dictionary<string, Dictionary<string, string>>)
                    {
                        if(OrderCode_TMP == check_tmp.Key.ToString())
                        {
                            DataCheck = true;
                        }
                    }
                    if(DataCheck)
                    {
                        ViewData["ModelTypeCode_LIST"] = json_data.ModelTypeCode_list;
                        ViewData["Phonenumber_LIST"] = json_data.Phonenumber_list;
                        ViewData["Social_LIST"] = json_data.Socail_list;
                        ViewData["Order_LIST"] = json_data.Order_list;
                        ViewData["OrderCode"] = OrderCode_TMP;
                        if (ViewData["ModelTypeCode_LIST"] == null | ViewData["Phonenumber_LIST"] == null | ViewData["Social_LIST"] == null | ViewData["Order_LIST"] == null | ViewData["OrderCode"] == null)
                        {
                            return Redirect("/Error/NullData");
                        }
                        return View();
                    }
                    else
                    {
                        return Redirect("/Error/NullData");
                    }
                }
            }
            else
            {
                ViewData["ModelTypeCode_LIST"] = json_data.ModelTypeCode_list;
                ViewData["Phonenumber_LIST"] = json_data.Phonenumber_list;
                ViewData["Social_LIST"] = json_data.Socail_list;
                ViewData["Order_LIST"] = json_data.Order_list;
                if (ViewData["ModelTypeCode_LIST"] == null | ViewData["Phonenumber_LIST"] == null | ViewData["Social_LIST"] == null | ViewData["Order_LIST"] == null)
                {
                    return Redirect("/Error/NullData");
                }
                HttpContext.Session.SetString(session_data.Session_Order_Name, OrderCode);
                bool Data_Check = false;
                foreach (var check_tmp in json_data.Order_list as Dictionary<string, Dictionary<string, string>>)
                {
                    if (HttpContext.Session.GetString(session_data.Session_Order_Name) == check_tmp.Key)
                    {
                        Data_Check = true;
                    }
                }
                if (Data_Check)
                {
                    ViewData["OrderCode"] = OrderCode;
                    return View();
                }
                else
                {
                    return Redirect("/Home/NotFoundOrder");
                }
            }
        }
        public IActionResult NotFoundOrder()
        {
            ViewData["ModelTypeCode_LIST"] = json_data.ModelTypeCode_list;
            ViewData["Phonenumber_LIST"] = json_data.Phonenumber_list;
            ViewData["Social_LIST"] = json_data.Socail_list;
            if (ViewData["ModelTypeCode_LIST"] == null | ViewData["Phonenumber_LIST"] == null | ViewData["Social_LIST"] == null)
            {
                return Redirect("/Error/NullData");
            }
            return View();
        }
        [HttpGet]
        [HttpPost]
        public IActionResult Search(string q)
        {
            if(Request.Method == "GET")
            {
                if(q == null | q == "")
                {
                    return Redirect("/Home/SearchNotFound");
                }
                List<string> data_setting = new List<string>();
                ViewData["ModelTypeCode_LIST"] = json_data.ModelTypeCode_list;
                ViewData["Phonenumber_LIST"] = json_data.Phonenumber_list;
                ViewData["Social_LIST"] = json_data.Socail_list;
                ViewData["Order_LIST"] = json_data.Order_list;
                if (ViewData["ModelTypeCode_LIST"] == null | ViewData["Phonenumber_LIST"] == null | ViewData["Social_LIST"] == null | ViewData["Order_LIST"] == null)
                {
                    return Redirect("/Error/NullData");
                }
                foreach (var tmp in json_data.Order_list as Dictionary<string, Dictionary<string, string>>)
                {
                    if(tmp.Value["OrderName"].IndexOf(q) != -1)
                    {
                        data_setting.Add(tmp.Key);
                    }
                }
                if (data_setting.Count != 0)
                {
                    ViewData["ModelTypeCode_LIST"] = json_data.ModelTypeCode_list;
                    ViewData["Phonenumber_LIST"] = json_data.Phonenumber_list;
                    ViewData["Social_LIST"] = json_data.Socail_list;
                    ViewData["Order"] = json_data.Order_list;
                    ViewData["OrderLIST"] = data_setting;
                    ViewData["OrderSearch"] = q;
                    if (ViewData["ModelTypeCode_LIST"] == null | ViewData["Phonenumber_LIST"] == null | ViewData["Social_LIST"] == null | ViewData["Order"] == null)
                    {
                        return Redirect("/Error/NullData");
                    }
                    return View();
                }
                else
                {
                    ViewData["ModelTypeCode_LIST"] = json_data.ModelTypeCode_list;
                    ViewData["Phonenumber_LIST"] = json_data.Phonenumber_list;
                    ViewData["Social_LIST"] = json_data.Socail_list;
                    if (ViewData["ModelTypeCode_LIST"] == null | ViewData["Phonenumber_LIST"] == null | ViewData["Social_LIST"] == null)
                    {
                        return Redirect("/Error/NullData");
                    }
                    return Redirect("/Home/SearchNotFound");
                }
            }
            else
            {
                return Redirect("/Error");
            }
        }
        public IActionResult SearchNotFound()
        {
            ViewData["ModelTypeCode_LIST"] = json_data.ModelTypeCode_list;
            ViewData["Phonenumber_LIST"] = json_data.Phonenumber_list;
            ViewData["Social_LIST"] = json_data.Socail_list;
            if (ViewData["ModelTypeCode_LIST"] == null | ViewData["Phonenumber_LIST"] == null | ViewData["Social_LIST"] == null)
            {
                return Redirect("/Error/NullData");
            }
            return View();
        }
    }
}
