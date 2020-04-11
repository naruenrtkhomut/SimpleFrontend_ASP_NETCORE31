using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleWebFrontend_ASP_NETCORE31.Models;

namespace SimpleWebFrontend_ASP_NETCORE31.Controllers
{
    public class OrderController : Controller
    {
        json_data_getting json_data = new json_data_getting();
        public IActionResult Search(string ModelType)
        {
            ViewData["ModelTypeCode_LIST"] = json_data.ModelTypeCode_list;
            ViewData["Phonenumber_LIST"] = json_data.Phonenumber_list;
            ViewData["Social_LIST"] = json_data.Socail_list;
            ViewData["ModelName"] = json_data.ModelName_list;
            ViewData["ModelType"] = ModelType;
            ViewData["ModelType_VALUE"] = json_data.ModelTypeCode_list[ModelType];
            ViewData["ModelList"] = json_data.ModelType_List_GROUP(ModelType);
            ViewData["Order"] = json_data.Order_list;
            if (ViewData["ModelTypeCode_LIST"] == null | ViewData["Phonenumber_LIST"] == null | ViewData["Social_LIST"] == null | ViewData["ModelName"] == null | ViewData["ModelType"] == null | ViewData["ModelList"] == null)
            {
                return Redirect("/Error/NullData");
            }
            return View();
        }
        public IActionResult SearchModel(string ModelType, string ModelName)
        {
            ViewData["ModelTypeCode_LIST"] = json_data.ModelTypeCode_list;
            ViewData["Phonenumber_LIST"] = json_data.Phonenumber_list;
            ViewData["Social_LIST"] = json_data.Socail_list;
            ViewData["ModelName"] = json_data.ModelName_list;
            ViewData["ModelType"] = ModelType;
            ViewData["ModelList"] = json_data.ModelType_List_GROUP(ModelType);
            ViewData["Order"] = json_data.Order_list;
            ViewData["ModelNameCode"] = ModelName;
            ViewData["ModelNameVALUE"] = json_data.ModelName_list[ModelName];
            if (ViewData["ModelTypeCode_LIST"] == null | ViewData["Phonenumber_LIST"] == null | ViewData["Social_LIST"] == null | ViewData["ModelName"] == null | ViewData["ModelType"] == null | ViewData["ModelList"] == null | ViewData["ModelName"] == null)
            {
                return Redirect("/Error/NullData");
            }
            bool data_check = false;
            foreach (var x in json_data.ModelType_List_GROUP(ModelType) as List<string>)
            {
                if(ModelName == x)
                {
                    data_check = true;
                }
            }
            if(data_check)
            {
                return View();
            }
            else
            {
                return Redirect("/Error/NullData");
            }
        }
    }
}