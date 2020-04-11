using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Data;
using Newtonsoft.Json;

namespace SimpleWebFrontend_ASP_NETCORE31.Models
{
    public class json_data_getting
    {
        public Dictionary<string, string> ModelTypeCode_list;
        public Dictionary<string, Dictionary<string, string>> LatestOrder_list;
        public Dictionary<string, Dictionary<string, string>> HotestOrder_list;
        public Dictionary<string, Dictionary<string, string>> Phonenumber_list;
        public Dictionary<string, Dictionary<string, string>> Socail_list;
        public Dictionary<string, Dictionary<string, string>> Payment_list;
        public Dictionary<string, Dictionary<string, string>> Order_list;
        public Dictionary<string, string> ModelName_list;
        public List<string> ModelType_List_GROUP(string ModelType_code)
        {
            try
            {
                Dictionary<string, List<string>> data_setting = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(JSON_DATA_STR("https://raw.githubusercontent.com/naruenrtkhomut/SimpleJsonData/master/SimpleModelTypeList.json"));
                return data_setting[ModelType_code];
            }
            catch(Exception)
            {
                return null;
            }
        }
        
        
        public json_data_getting()
        {
            try
            {
                this.ModelTypeCode_list = ModelTypeCode_LIST;
                this.LatestOrder_list = LatestOrder_LIST;
                this.HotestOrder_list = HotestOrder_LIST;
                this.Phonenumber_list = Phonenumber_LIST;
                this.Socail_list = Social_LIST;
                this.Payment_list = Payment_LIST;
                this.Order_list = Order_LIST;
                this.ModelName_list = ModelName_LIST;
            }
            catch(Exception)
            {
                this.ModelTypeCode_list = null;
                this.LatestOrder_list = null;
                this.HotestOrder_list = null;
                this.Phonenumber_list = null;
                this.Socail_list = null;
                this.Payment_list = null;
                this.Order_list = null;
                this.ModelName_list = null;
            }
            
        }
        private static string JSON_DATA_STR(string json_url)
        {
            return (new WebClient()).DownloadString(json_url);
        }
        private static Dictionary<string, string> ModelTypeCode_LIST = JsonConvert.DeserializeObject<Dictionary<string, string>>(JSON_DATA_STR("https://raw.githubusercontent.com/naruenrtkhomut/SimpleJsonData/master/SimpleModelTypeValue.json"));
        private static Dictionary<string, Dictionary<string, string>> LatestOrder_LIST = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(JSON_DATA_STR("https://raw.githubusercontent.com/naruenrtkhomut/SimpleJsonData/master/SimpleLatestOrder.json"));
        private static Dictionary<string, Dictionary<string, string>> HotestOrder_LIST = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(JSON_DATA_STR("https://raw.githubusercontent.com/naruenrtkhomut/SimpleJsonData/master/SimpleHotestOrder.json"));
        private static Dictionary<string, Dictionary<string, string>> Phonenumber_LIST = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(JSON_DATA_STR("https://raw.githubusercontent.com/naruenrtkhomut/SimpleJsonData/master/SimplePhoneNumber.json"));
        private static Dictionary<string, Dictionary<string, string>> Social_LIST = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(JSON_DATA_STR("https://raw.githubusercontent.com/naruenrtkhomut/SimpleJsonData/master/SimpleSocial.json"));
        private static Dictionary<string, Dictionary<string, string>> Payment_LIST = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(JSON_DATA_STR("https://raw.githubusercontent.com/naruenrtkhomut/SimpleJsonData/master/SimplePayment.json"));
        private static Dictionary<string, Dictionary<string, string>> Order_LIST = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(JSON_DATA_STR("https://raw.githubusercontent.com/naruenrtkhomut/SimpleJsonData/master/SimpleOrderName_Value.json"));
        private static Dictionary<string, string> ModelName_LIST = JsonConvert.DeserializeObject<Dictionary<string, string>>(JSON_DATA_STR("https://raw.githubusercontent.com/naruenrtkhomut/SimpleJsonData/master/SimpleModelNameList.json"));
    }
}
