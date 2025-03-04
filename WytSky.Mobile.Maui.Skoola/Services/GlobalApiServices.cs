using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Net.Http.Headers;
using System.Text.Json;

namespace WytSky.Mobile.Maui.Skoola.Services
{
    public class GlobalApiServices
    {

        #region PostDataWithBaseUrl<T, T1>(T1 data, string control, string action, Dictionary<string, string> d,string BaseUrl, string apiAddress, AuthorizationType Authorization = 0)
        public async Task<T> PostDataWithBaseUrl<T, T1>(T1 data, string control, string action, Dictionary<string, string> d,string BaseUrl, string apiAddress, AuthorizationType Authorization = 0)
        {
            string json = "", url = "";
            try
            {
                HttpClient client = new HttpClient(new System.Net.Http.HttpClientHandler())
                {
                    Timeout = TimeSpan.FromSeconds(30),
                    BaseAddress = new Uri(BaseUrl),
                };
                if (Authorization == AuthorizationType.Token)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "AuthoToken");
                }
                else if (Authorization == AuthorizationType.UserNamePassword)
                {
                    var byteArray = Encoding.ASCII.GetBytes($"UserName:Password");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                }
                HttpResponseMessage request = null;
                if (data != null)
                    json = System.Text.Json.JsonSerializer.Serialize(data);
                StringContent dataConverted = new StringContent(json, Encoding.UTF8, "application/json");
                StringBuilder query = new StringBuilder().Append("?");
                if (d != null && d.Count > 0)
                {
                    var lastElement = d.ElementAt(d.Count - 1);
                    d.Remove("TimeStamp");
                    foreach (var item in d)
                    {
                        var flag = item.Key == lastElement.Key;
                        if (!flag)
                            query.Append(item.Key + "=" + item.Value).Append("&");
                        else
                            query.Append(item.Key + "=" + item.Value);
                    }
                    if (string.IsNullOrWhiteSpace(action))
                    {
                        url = $"{apiAddress}{control}{query}";
                    }
                    else
                    {
                        url = $"{apiAddress}{control}/{action}{query}";
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(action))
                    {
                        url = $"{apiAddress}{control}";
                    }
                    else
                    {
                        url = $"{apiAddress}{control}/{action}";
                    }
                }
                Debug.WriteLine($"Url: {BaseUrl}{url} ");
                request = await client.PostAsync(url, dataConverted);
                var content = await request.Content.ReadAsStringAsync();
                if (!request.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"StatusCode : {request.StatusCode} {Environment.NewLine} Error {content}");
                    return default;
                }
                else
                {
                    return System.Text.Json.JsonSerializer.Deserialize<T>(content);
                }
            }
            catch (Exception ex)
            {
                string Error = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                System.Diagnostics.Debug.WriteLine(Error);
                return default;
            }
        }
        #endregion

        #region GetDataWithBaseUrl<T, T1>(T1 data, string control, string action, Dictionary<string, string> d,string BaseUrl, string apiAddress, AuthorizationType Authorization = 0)
        public async Task<T> GetDataWithBaseUrl<T>(string control, string action, Dictionary<string, string> d, string BaseUrl, string apiAddress, AuthorizationType Authorization = 0)
        {
            string url = "";
            try
            {
                HttpClient client = new HttpClient(new System.Net.Http.HttpClientHandler())
                {
                    Timeout = TimeSpan.FromSeconds(30),
                    BaseAddress = new Uri(BaseUrl),
                };
                if (Authorization == AuthorizationType.Token)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "AuthoToken");
                }
                else if (Authorization == AuthorizationType.UserNamePassword)
                {
                    var byteArray = Encoding.ASCII.GetBytes($"UserName:Password");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                }
                HttpResponseMessage request = null;
                StringBuilder query = new StringBuilder().Append("?");
                if (d != null && d.Count > 0)
                {
                    var lastElement = d.ElementAt(d.Count - 1);
                    d.Remove("TimeStamp");
                    foreach (var item in d)
                    {
                        var flag = item.Key == lastElement.Key;
                        if (!flag)
                            query.Append(item.Key + "=" + item.Value).Append("&");
                        else
                            query.Append(item.Key + "=" + item.Value);
                    }
                    if (string.IsNullOrWhiteSpace(action))
                    {
                        url = $"{apiAddress}{control}{query}";
                    }
                    else
                    {
                        url = $"{apiAddress}{control}/{action}{query}";
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(action))
                    {
                        url = $"{apiAddress}{control}";
                    }
                    else
                    {
                        url = $"{apiAddress}{control}/{action}";
                    }
                }
                System.Diagnostics.Debug.WriteLine($"Url: {BaseUrl}{url} ");
                request = await client.GetAsync(url);
                var content = await request.Content.ReadAsStringAsync();
                if (!request.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine($"StatusCode : {request.StatusCode} {Environment.NewLine} Error {content}");
                    return default;
                }
                else
                {
                    return System.Text.Json.JsonSerializer.Deserialize<T>(content);
                }
            }
            catch (Exception ex)
            {
                string Error = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                System.Diagnostics.Debug.WriteLine(Error);
                return default;
            }
        }
        #endregion

        #region PutDataWithBaseUrl<T, T1>(T1 data, string control, string action, Dictionary<string, string> d,string BaseUrl, string apiAddress, AuthorizationType Authorization = 0)
        public async Task<T> PutDataWithBaseUrl<T, T1>(T1 data, string control, string action, Dictionary<string, string> d, string BaseUrl, string apiAddress, AuthorizationType Authorization = 0)
        {
            string json = "", url = "";
            try
            {
                HttpClient client = new HttpClient(new System.Net.Http.HttpClientHandler())
                {
                    Timeout = TimeSpan.FromSeconds(30),
                    BaseAddress = new Uri(BaseUrl),
                };
                if (Authorization == AuthorizationType.Token)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "AuthoToken");
                }
                else if (Authorization == AuthorizationType.UserNamePassword)
                {
                    var byteArray = Encoding.ASCII.GetBytes($"UserName:Password");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                }
                HttpResponseMessage request = null;
                if (data != null)
                    json = System.Text.Json.JsonSerializer.Serialize(data);
                StringContent dataConverted = new StringContent(json, Encoding.UTF8, "application/json");
                StringBuilder query = new StringBuilder().Append("?");
                if (d != null && d.Count > 0)
                {
                    var lastElement = d.ElementAt(d.Count - 1);
                    d.Remove("TimeStamp");
                    foreach (var item in d)
                    {
                        var flag = item.Key == lastElement.Key;
                        if (!flag)
                            query.Append(item.Key + "=" + item.Value).Append("&");
                        else
                            query.Append(item.Key + "=" + item.Value);
                    }
                    if (string.IsNullOrWhiteSpace(action))
                    {
                        url = $"{apiAddress}{control}{query}";
                    }
                    else
                    {
                        url = $"{apiAddress}{control}/{action}{query}";
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(action))
                    {
                        url = $"{apiAddress}{control}";
                    }
                    else
                    {
                        url = $"{apiAddress}{control}/{action}";
                    }
                }
                System.Diagnostics.Debug.WriteLine($"Url: {BaseUrl}{url} ");
                request = await client.PutAsync(url, dataConverted);
                var content = await request.Content.ReadAsStringAsync();
                if (!request.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine($"StatusCode : {request.StatusCode} {Environment.NewLine} Error {content}");
                    return default;
                }
                else
                {
                    return System.Text.Json.JsonSerializer.Deserialize<T>(content);
                }
            }
            catch (Exception ex)
            {
                string Error = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                System.Diagnostics.Debug.WriteLine(Error);
                return default;
            }
        }
        #endregion

        #region DeleteDataWithBaseUrl<T, T1>(T1 data, string control, string action, Dictionary<string, string> d,string BaseUrl, string apiAddress, AuthorizationType Authorization = 0)
        public async Task<T> DeleteDataWithBaseUrl<T>(string control, string action, Dictionary<string, string> d, string BaseUrl, string apiAddress, AuthorizationType Authorization = 0)
        {
            string url = "";
            try
            {
                HttpClient client = new HttpClient(new System.Net.Http.HttpClientHandler())
                {
                    Timeout = TimeSpan.FromSeconds(30),
                    BaseAddress = new Uri(BaseUrl),
                };
                if (Authorization == AuthorizationType.Token)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "AuthoToken");
                }
                else if (Authorization == AuthorizationType.UserNamePassword)
                {
                    var byteArray = Encoding.ASCII.GetBytes($"UserName:Password");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                }
                HttpResponseMessage request = null;
                StringBuilder query = new StringBuilder().Append("?");
                if (d != null && d.Count > 0)
                {
                    var lastElement = d.ElementAt(d.Count - 1);
                    d.Remove("TimeStamp");
                    foreach (var item in d)
                    {
                        var flag = item.Key == lastElement.Key;
                        if (!flag)
                            query.Append(item.Key + "=" + item.Value).Append("&");
                        else
                            query.Append(item.Key + "=" + item.Value);
                    }
                    if (string.IsNullOrWhiteSpace(action))
                    {
                        url = $"{apiAddress}{control}{query}";
                    }
                    else
                    {
                        url = $"{apiAddress}{control}/{action}{query}";
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(action))
                    {
                        url = $"{apiAddress}{control}";
                    }
                    else
                    {
                        url = $"{apiAddress}{control}/{action}";
                    }
                }
                System.Diagnostics.Debug.WriteLine($"Url: {BaseUrl}{url} ");
                request = await client.DeleteAsync(url);
                var content = await request.Content.ReadAsStringAsync();
                if (!request.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine($"StatusCode : {request.StatusCode} {Environment.NewLine} Error {content}");
                    return default;
                }
                else
                {
                    return System.Text.Json.JsonSerializer.Deserialize<T>(content);
                }
            }
            catch (Exception ex)
            {
                string Error = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                System.Diagnostics.Debug.WriteLine(Error);
                return default;
            }
        }
        #endregion
      
    }
    public enum AuthorizationType
    {
        nun = 0,
        Token = 1,
        UserNamePassword = 2
    }
}
