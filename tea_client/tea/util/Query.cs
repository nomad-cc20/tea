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
        private static readonly bool BYPASS_LOGIN = false;

        private static string GetPath(string postfix)
        {
            return PREFIX + postfix;
        }

        public static string Register(RegisterDtoOut dto)
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

            using (var response = request.GetResponse())
            {
                return (new StreamReader(response.GetResponseStream())).ReadToEnd();
            }
        }

        public static string LogIn(UserDtoOut dto)
        {
            if (BYPASS_LOGIN)
                return "admin";

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
                //return Newtonsoft.Json.JsonConvert.DeserializeObject<String>((new StreamReader(response.GetResponseStream())).ReadToEnd());
                return (new StreamReader(response.GetResponseStream())).ReadToEnd();
            }
        }

        public static void NewToy(NewToyDtoOut dto)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetPath("createToy"));
            request.Timeout = 5000;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
                streamWriter.Write(json);
                streamWriter.Close();
            }

            request.GetResponse();
        }

        public static List<ToyDtoIn> GetMyToys(UserNameDtoOut dto)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetPath("getAllToys"));
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
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<ToyDtoIn>>((new StreamReader(response.GetResponseStream())).ReadToEnd());
            }
        }

        public static void NewOffer(NewOfferDtoOut dto)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetPath("createOffer"));
            request.Timeout = 5000;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
                streamWriter.Write(json);
                streamWriter.Close();
            }

            request.GetResponse();
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

        public static List<OfferDtoIn> GetMyOffers(UserNameDtoOut dto)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetPath("getAllOffersOfUser"));
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.Timeout = 5000;

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
                streamWriter.Write(json);
                streamWriter.Close();
            }

            using (var response = request.GetResponse())
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<OfferDtoIn>>((new StreamReader(response.GetResponseStream())).ReadToEnd());
            }
        }

        public static void NewBid(NewBidDtoOut dto)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetPath("createBid"));
            request.Timeout = 5000;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
                streamWriter.Write(json);
                streamWriter.Close();
            }

            request.GetResponse();
        }

        public static List<OfferDtoIn> GetMyBids(UserNameDtoOut dto)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetPath("getAllBidsOfUser"));
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.Timeout = 5000;

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
                streamWriter.Write(json);
                streamWriter.Close();
            }

            using (var response = request.GetResponse())
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<OfferDtoIn>>((new StreamReader(response.GetResponseStream())).ReadToEnd());
            }
        }

        public static List<BidDtoIn> GetBids(long id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetPath("getAllBids/" + id));
            request.Timeout = 5000;

            using (var response = request.GetResponse())
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<BidDtoIn>>((new StreamReader(response.GetResponseStream())).ReadToEnd());
            }
        }

        public static void AcceptBid(long id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetPath("acceptBid/" + id));
            request.Method = "POST";
            request.Timeout = 5000;

            request.GetResponse();
        }
    }
}
