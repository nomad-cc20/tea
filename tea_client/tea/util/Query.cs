using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using tea.containers.dtos;

namespace tea.utils
{
    static class Query
    {
        private static readonly string PREFIX = "http://localhost:8080/toychange/";
        private static bool BYPASS_LOGIN = false;

        private static string GetPath(string postfix)
        {
            return PREFIX + postfix;
        }

        public static List<OfferDtoIn> GetAllActiveOffers()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetPath("getAllActiveOffers"));
            request.Timeout = 5000;

            using (var response = request.GetResponse())
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<OfferDtoIn>>((new StreamReader(response.GetResponseStream())).ReadToEnd());
            }
        }

        public static long logIn(UserDtoOut dto)
        {
            if (BYPASS_LOGIN)
                return 0;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetPath("login"));
            request.Timeout = 5000;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
                streamWriter.Write(json);
                streamWriter.Close();
            }

            using (var response = request.GetResponse())
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<long>((new StreamReader(response.GetResponseStream())).ReadToEnd());
            }
        }

        public static void register(RegisterDtoOut dto)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetPath("register"));
            request.Timeout = 5000;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
                streamWriter.Write(json);
                streamWriter.Close();
            }
        }
    }
}
