using System.Diagnostics;
using System.Net;
using System.Text;
using WytSky.Mobile.Maui.Skoola.Views.User;
using System.Net.Http.Headers;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.AppResources;
using RestSharp;
using RestSharp.Authenticators;
using System.Text.Json;
using WytSky.Mobile.Maui.Skoola.Views.Popups;
using Mopups.Services;

namespace WytSky.Mobile.Maui.Skoola.Services
{
    public class ApiServices
    {

        //Api Url
        public const string BaseAddress = "https://Qr.saskw.net";
        public const string PAGESIZE = "100";
        private const string apiAddress = "";
        public static string BaseImage = "https://Qr.saskw.net";

        static HttpClient client = new HttpClient(new HttpClientHandler())
        {
            Timeout = TimeSpan.FromSeconds(30),
            BaseAddress = new Uri(BaseAddress),
        };

        #region PostDataWithBaseUrl<T, T1>(T1 data, string control, string action, Dictionary<string, string> d,string BaseUrl, Enums.AuthorizationType Authorization = 0)
        public async Task<Models.ResultApi<T>> PostDataWithBaseUrl<T, T1>(T1 data, string control, string action, Dictionary<string, string> d, string BaseUrl, string apiAddress, Enums.AuthorizationType Authorization = 0)
        {
            string json = "", url = "";
            try
            {
                await MopupService.Instance.PushAsync(new LoadingPopup());
                {
                    HttpClient client = new HttpClient(new HttpClientHandler())
                    {
                        Timeout = TimeSpan.FromSeconds(30),
                        BaseAddress = new Uri(BaseUrl),
                    };
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if (Authorization == Enums.AuthorizationType.Token)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AuthoToken);
                    }
                    else if (Authorization == Enums.AuthorizationType.UserNamePassword)
                    {
                        var byteArray = Encoding.ASCII.GetBytes($"{Settings.UserName}:{Settings.Password}");
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
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
                    if (!request.IsSuccessStatusCode && (
                        request.StatusCode == HttpStatusCode.GatewayTimeout ||
                        request.StatusCode == HttpStatusCode.RequestTimeout))
                    {
                        Debug.WriteLine($"Error {content}");
                        return new Models.ResultApi<T>()
                        {
                            success = false,
                            message = $"Time Out :: StatusCode is ( {request.StatusCode} ) ",
                        };
                    }
                    else if (request.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        Debug.WriteLine($"Error {content}");
                        Settings.AuthoToken = ""; client.DefaultRequestHeaders.Authorization = null; Toast.ShowToastError(SharedResources.Msg_TimeExpired);
                        App.Current.MainPage = new NavigationPage(new SignInSignUpPage())
                        {
                            FlowDirection = Settings.Language == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
                        };
                        return null;
                    }
                    else if (!request.IsSuccessStatusCode)
                    {
                        Debug.WriteLine($"Error {content}");
                        return new Models.ResultApi<T>()
                        {
                            success = false,
                            message = $"StatusCode is ( {request.StatusCode} ) {Environment.NewLine} Error : {content}  ",
                        };
                    }
                    return System.Text.Json.JsonSerializer.Deserialize<Models.ResultApi<T>>(content);
                    //return new Models.ResultApi<T>()
                    //{
                    //    success = true,
                    //    ResultApi = $"Ok",
                    //    Data = obj,
                    //};
                }
            }
            catch (Exception ex)
            {
                string Error = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                Debug.WriteLine(Error);
                ExtensionLogMethods.LogExtension(Error, $"url : {client.BaseAddress.AbsoluteUri}/{url} {Environment.NewLine} Data : {json}", "ApiServices", "PostDataWithBaseUrl");
                return new Models.ResultApi<T>()
                {
                    success = false,
                    message = Error,
                };
            }
            finally
            {
                try
                {
                    if (MopupService.Instance.PopupStack.Count > 0)
                        await MopupService.Instance.PopAllAsync();
                }
                catch (Exception ex)
                {
                    ExtensionLogMethods.LogExtension(ex, "", "", "Dispose");
                }
            }
        }
        #endregion

        #region PostDataWithBaseUrlNoLoading<T, T1>(T1 data, string control, string action, Dictionary<string, string> d,string BaseUrl, Enums.AuthorizationType Authorization = 0)
        public async Task<Models.ResultApi<T>> PostDataWithBaseUrlNoLoading<T, T1>(T1 data, string control, string action, Dictionary<string, string> d, string BaseUrl, string apiAddress, Enums.AuthorizationType Authorization = 0)
        {
            string json = "", url = "";
            try
            {
                HttpClient client = new HttpClient(new HttpClientHandler())
                {
                    Timeout = TimeSpan.FromSeconds(30),
                    BaseAddress = new Uri(BaseUrl),
                };
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (Authorization == Enums.AuthorizationType.Token)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AuthoToken);
                }
                else if (Authorization == Enums.AuthorizationType.UserNamePassword)
                {
                    var byteArray = Encoding.ASCII.GetBytes($"{Settings.UserName}:{Settings.Password}");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
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
                if (!request.IsSuccessStatusCode && (
                    request.StatusCode == HttpStatusCode.GatewayTimeout ||
                    request.StatusCode == HttpStatusCode.RequestTimeout))
                {
                    Debug.WriteLine($"Error {content}");
                    return new Models.ResultApi<T>()
                    {
                        success = false,
                        message = $"Time Out :: StatusCode is ( {request.StatusCode} ) ",
                    };
                }
                else if (request.StatusCode == HttpStatusCode.Unauthorized)
                {
                    Debug.WriteLine($"Error {content}");
                    Settings.AuthoToken = ""; client.DefaultRequestHeaders.Authorization = null; Toast.ShowToastError(SharedResources.Msg_TimeExpired);
                    App.Current.MainPage = new NavigationPage(new SignInSignUpPage())
                    {
                        FlowDirection = Settings.Language == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
                    };
                    return null;
                }
                else if (!request.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"Error {content}");
                    return new Models.ResultApi<T>()
                    {
                        success = false,
                        message = $"StatusCode is ( {request.StatusCode} ) {Environment.NewLine} Error : {content}  ",
                    };
                }
                return System.Text.Json.JsonSerializer.Deserialize<Models.ResultApi<T>>(content);
                //return new Models.ResultApi<T>()
                //{
                //    success = true,
                //    ResultApi = $"Ok",
                //    Data = obj,
                //};
            }
            catch (Exception ex)
            {
                string Error = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                Debug.WriteLine(Error);
                ExtensionLogMethods.LogExtension(Error, $"url : {client.BaseAddress.AbsoluteUri}/{url} {Environment.NewLine} Data : {json}", "ApiServices", "PostDataWithBaseUrl");
                return new Models.ResultApi<T>()
                {
                    success = false,
                    message = Error,
                };
            }
            finally
            {
                try
                {
                    if (MopupService.Instance.PopupStack.Count > 0)
                        await MopupService.Instance.PopAllAsync();
                }
                catch (Exception ex)
                {
                    ExtensionLogMethods.LogExtension(ex, "", "", "Dispose");
                }
            }
        }
        #endregion

        #region GetDataWithBaseUrl<T>(string control, string action, Dictionary<string, string> d,string BaseUrl, Enums.AuthorizationType Authorization = 0)
        public async Task<Models.ResultApi<T>> GetDataWithBaseUrl<T>(string control, string action, Dictionary<string, string> d, string BaseUrl, string apiAddress, Enums.AuthorizationType Authorization = 0)
        {
            string url = "";
            try
            {
                await MopupService.Instance.PushAsync(new LoadingPopup());
                {
                    HttpClient client = new HttpClient(new HttpClientHandler())
                    {
                        Timeout = TimeSpan.FromSeconds(30),
                        BaseAddress = new Uri(BaseUrl),
                    };
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if (Authorization == Enums.AuthorizationType.Token)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AuthoToken);
                    }
                    else if (Authorization == Enums.AuthorizationType.UserNamePassword)
                    {
                        var byteArray = Encoding.ASCII.GetBytes($"{Settings.UserName}:{Settings.Password}");
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
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
                    Debug.WriteLine($"Url: {BaseUrl}{url} ");
                    request = await client.GetAsync(url);
                    var content = await request.Content.ReadAsStringAsync();
                    if (!request.IsSuccessStatusCode && (
                        request.StatusCode == HttpStatusCode.GatewayTimeout ||
                        request.StatusCode == HttpStatusCode.RequestTimeout))
                    {
                        Debug.WriteLine($"Error {content}");
                        return new Models.ResultApi<T>()
                        {
                            success = false,
                            message = $"Time Out :: StatusCode is ( {request.StatusCode} ) ",
                        };
                    }
                    else if (request.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        Debug.WriteLine($"Error {content}");
                        Settings.AuthoToken = ""; client.DefaultRequestHeaders.Authorization = null; Toast.ShowToastError(SharedResources.Msg_TimeExpired);
                        App.Current.MainPage = new NavigationPage(new SignInSignUpPage())
                        {
                            FlowDirection = Settings.Language == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
                        };
                        return null;
                    }
                    else if (!request.IsSuccessStatusCode)
                    {
                        Debug.WriteLine($"Error {content}");
                        return new Models.ResultApi<T>()
                        {
                            success = false,
                            message = $"StatusCode is ( {request.StatusCode} ) {Environment.NewLine} Error : {content}  ",
                        };
                    }
                    return System.Text.Json.JsonSerializer.Deserialize<Models.ResultApi<T>>(content);
                    //return new Models.ResultApi<T>()
                    //{
                    //    success = true,
                    //    ResultApi = $"Ok",
                    //    Data = obj,
                    //};
                }
            }
            catch (Exception ex)
            {
                string Error = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                Debug.WriteLine(Error);
                ExtensionLogMethods.LogExtension(Error, $"url : {BaseUrl}/{url} {Environment.NewLine}", "ApiServices", "GetDataWithBaseUrl");
                return new Models.ResultApi<T>()
                {
                    success = false,
                    message = Error,
                };
            }
            finally
            {
                try
                {
                    if (MopupService.Instance.PopupStack.Count > 0)
                        await MopupService.Instance.PopAllAsync();
                }
                catch (Exception ex)
                {
                    ExtensionLogMethods.LogExtension(ex, "", "", "Dispose");
                }
            }
        }
        #endregion

        #region GetDataWithBaseUrlNoLoading<T>(string control, string action, Dictionary<string, string> d,string BaseUrl, Enums.AuthorizationType Authorization = 0)
        public async Task<Models.ResultApi<T>> GetDataWithBaseUrlNoLoading<T>(string control, string action, Dictionary<string, string> d, string BaseUrl, string apiAddress, Enums.AuthorizationType Authorization = 0)
        {
            string url = "";
            try
            {
                HttpClient client = new HttpClient(new HttpClientHandler())
                {
                    Timeout = TimeSpan.FromSeconds(30),
                    BaseAddress = new Uri(BaseUrl),
                };
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (Authorization == Enums.AuthorizationType.Token)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AuthoToken);
                }
                else if (Authorization == Enums.AuthorizationType.UserNamePassword)
                {
                    var byteArray = Encoding.ASCII.GetBytes($"{Settings.UserName}:{Settings.Password}");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
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
                Debug.WriteLine($"Url: {BaseUrl}{url} ");
                request = await client.GetAsync(url);
                var content = await request.Content.ReadAsStringAsync();
                if (!request.IsSuccessStatusCode && (
                    request.StatusCode == HttpStatusCode.GatewayTimeout ||
                    request.StatusCode == HttpStatusCode.RequestTimeout))
                {
                    Debug.WriteLine($"Error {content}");
                    return new Models.ResultApi<T>()
                    {
                        success = false,
                        message = $"Time Out :: StatusCode is ( {request.StatusCode} ) ",
                    };
                }
                else if (request.StatusCode == HttpStatusCode.Unauthorized)
                {
                    Debug.WriteLine($"Error {content}");
                    Settings.AuthoToken = ""; client.DefaultRequestHeaders.Authorization = null; Toast.ShowToastError(SharedResources.Msg_TimeExpired);
                    App.Current.MainPage = new NavigationPage(new SignInSignUpPage())
                    {
                        FlowDirection = Settings.Language == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
                    };
                    return null;
                }
                else if (!request.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"Error {content}");
                    return new Models.ResultApi<T>()
                    {
                        success = false,
                        message = $"StatusCode is ( {request.StatusCode} ) {Environment.NewLine} Error : {content}  ",
                    };
                }
                return System.Text.Json.JsonSerializer.Deserialize<Models.ResultApi<T>>(content);
                //return new Models.ResultApi<T>()
                //{
                //    success = true,
                //    ResultApi = $"Ok",
                //    Data = obj,
                //};
            }
            catch (Exception ex)
            {
                string Error = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                Debug.WriteLine(Error);
                ExtensionLogMethods.LogExtension(Error, $"url : {BaseUrl}/{url} {Environment.NewLine}", "ApiServices", "PostDataWithBaseUrl");
                return new Models.ResultApi<T>()
                {
                    success = false,
                    message = Error,
                };
            }
            finally
            {
                try
                {
                    if (MopupService.Instance.PopupStack.Count > 0)
                        await MopupService.Instance.PopAllAsync();
                }
                catch (Exception ex)
                {
                    ExtensionLogMethods.LogExtension(ex, "", "", "Dispose");
                }
            }
        }
        #endregion

        #region PostData<T, T1>(T1 data, string control, string action, Dictionary<string, string> d, Enums.AuthorizationType Authorization = 0)
        public async Task<Models.IResponse<T>> PostData<T, T1>(T1 data, string control, string action, Dictionary<string, string> d, Enums.AuthorizationType Authorization = 0, bool isLoading = true)
        {
            string json = "", url = "";
            try
            {
                if (isLoading)
                    await MopupService.Instance.PushAsync(new LoadingPopup());
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if (Authorization == Enums.AuthorizationType.Token)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AuthoToken);
                    }
                    else if (Authorization == Enums.AuthorizationType.UserNamePassword)
                    {
                        var byteArray = Encoding.ASCII.GetBytes($"{Settings.UserName}:{Settings.Password}");
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
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
                    Debug.WriteLine($"Url: {BaseAddress}{url} ");
                    request = await client.PostAsync(url, dataConverted);
                    var content = await request.Content.ReadAsStringAsync();
                    if (!request.IsSuccessStatusCode && (
                        request.StatusCode == HttpStatusCode.GatewayTimeout ||
                        request.StatusCode == HttpStatusCode.RequestTimeout))
                    {
                        Debug.WriteLine($"Error {content}");
                        return new Models.IResponse<T>()
                        {
                            IsPassed = false,
                            Message = $"Time Out :: StatusCode is ( {request.StatusCode} ) ",
                        };
                    }
                    else if (request.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        Debug.WriteLine($"Error {content}");
                        Settings.AuthoToken = ""; client.DefaultRequestHeaders.Authorization = null; Toast.ShowToastError(SharedResources.Msg_TimeExpired);
                        App.Current.MainPage = new NavigationPage(new SignInSignUpPage())
                        {
                            FlowDirection = Settings.Language == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
                        };
                        return null;
                    }
                    else if (!request.IsSuccessStatusCode)
                    {
                        Debug.WriteLine($"Error {content}");
                        return new Models.IResponse<T>()
                        {
                            IsPassed = false,
                            Message = $"StatusCode is ( {request.StatusCode} ) {Environment.NewLine} Error : {content}  ",
                        };
                    }
                    var obj = System.Text.Json.JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return new Models.IResponse<T>()
                    {
                        IsPassed = true,
                        Message = $"Ok",
                        Data = obj,
                    };
                }
            }
            catch (Exception ex)
            {
                string Error = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                Debug.WriteLine(Error);
                ExtensionLogMethods.LogExtension(Error, $"url : {client.BaseAddress.AbsoluteUri}/{url} {Environment.NewLine} Data : {json}", "ApiServices", "PostData");
                return new Models.IResponse<T>()
                {
                    IsPassed = false,
                    Message = Error,
                };
            }
            finally
            {
                if (isLoading)
                    try
                    {
                        if (MopupService.Instance.PopupStack.Count > 0)
                            await MopupService.Instance.PopAllAsync();
                    }
                    catch (Exception ex)
                    {
                        ExtensionLogMethods.LogExtension(ex, "", "", "Dispose");
                    }
            }
        }
        #endregion

        #region PostDataIgnoreException(data,control,action,d,IsAuthorization)
        public async Task<Models.IResponse<T>> PostDataIgnoreException<T, T1>(T1 data, string control, string action, Dictionary<string, string> d, Enums.AuthorizationType Authorization = 0)
        {
            string json = "", url = "";
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (Authorization == Enums.AuthorizationType.Token)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AuthoToken);
                }
                else if (Authorization == Enums.AuthorizationType.UserNamePassword)
                {
                    var byteArray = Encoding.ASCII.GetBytes($"{Settings.UserName}:{Settings.Password}");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
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
                Debug.WriteLine($"Url: {BaseAddress}/{url} ");
                request = await client.PostAsync(url, dataConverted);
                var content = await request.Content.ReadAsStringAsync();
                if (!request.IsSuccessStatusCode && (
                    request.StatusCode == HttpStatusCode.GatewayTimeout ||
                    request.StatusCode == HttpStatusCode.RequestTimeout))
                {
                    Debug.WriteLine($"Error {content}");
                    return new Models.IResponse<T>()
                    {
                        IsPassed = false,
                        Message = $"Time Out :: StatusCode is ( {request.StatusCode} ) ",
                    };
                }
                else if (request.StatusCode == HttpStatusCode.Unauthorized)
                {
                    Debug.WriteLine($"Error {content}");
                    Settings.AuthoToken = ""; client.DefaultRequestHeaders.Authorization = null; Toast.ShowToastError(SharedResources.Msg_TimeExpired);
                    App.Current.MainPage = new NavigationPage(new SignInSignUpPage())
                    {
                        FlowDirection = Settings.Language == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
                    };
                    return null;
                }
                else if (!request.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"Error {content}");
                    return new Models.IResponse<T>()
                    {
                        IsPassed = false,
                        Message = $"StatusCode is ( {request.StatusCode} ) {Environment.NewLine} Error : {content}  ",
                    };
                }
                var obj = System.Text.Json.JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return new Models.IResponse<T>()
                {
                    IsPassed = true,
                    Message = $"Ok",
                    Data = obj,
                };
            }
            catch (Exception ex)
            {
                string Error = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                Debug.WriteLine(Error);
                return new Models.IResponse<T>()
                {
                    IsPassed = false,
                    Message = Error,
                };
            }
            finally
            {
                try
                {
                    if (MopupService.Instance.PopupStack.Count > 0)
                        await MopupService.Instance.PopAllAsync();
                }
                catch (Exception ex)
                {
                    ExtensionLogMethods.LogExtension(ex, "", "", "Dispose");
                }
            }
        }
        #endregion

        #region PostDataWithFile<T, T1>(T1 data, string control, string action, Dictionary<string, string> d, List<Stream> files, Enums.AuthorizationType Authorization = 0)
        public async Task<Models.IResponse<T>> PostDataWithFile<T, T1>(T1 data, string control, string action, Dictionary<string, string> d, List<Stream> files, Enums.AuthorizationType Authorization = 0)
        {
            string json = "", url = "";
            try
            {
                await MopupService.Instance.PushAsync(new LoadingPopup());
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if (Authorization == Enums.AuthorizationType.Token)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AuthoToken);
                    }
                    else if (Authorization == Enums.AuthorizationType.UserNamePassword)
                    {
                        var byteArray = Encoding.ASCII.GetBytes($"{Settings.UserName}:{Settings.Password}");
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
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
                    Debug.WriteLine($"Url: {BaseAddress}/{url} ");
                    if (files != null)
                    {
                        var formData = new MultipartFormDataContent();
                        for (int i = 0; i < files.Count; i++)
                        {
                            HttpContent fileStreamContent = new StreamContent(files[i]);
                            fileStreamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") { Name = "file", FileName = $"File_{i}" };
                            fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                            formData.Add(fileStreamContent);
                        }
                        request = await client.PostAsync(url, formData);
                    }
                    else
                    {
                        request = await client.PostAsync(url, dataConverted);
                    }
                    var content = await request.Content.ReadAsStringAsync();
                    if (!request.IsSuccessStatusCode && (
                        request.StatusCode == HttpStatusCode.GatewayTimeout ||
                        request.StatusCode == HttpStatusCode.RequestTimeout))
                    {
                        Debug.WriteLine($"Error {content}");
                        return new Models.IResponse<T>()
                        {
                            IsPassed = false,
                            Message = $"Time Out :: StatusCode is ( {request.StatusCode} ) ",
                        };
                    }
                    else if (request.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        Debug.WriteLine($"Error {content}");
                        Settings.AuthoToken = ""; client.DefaultRequestHeaders.Authorization = null; Toast.ShowToastError(SharedResources.Msg_TimeExpired);
                        App.Current.MainPage = new NavigationPage(new SignInSignUpPage())
                        {
                            FlowDirection = Settings.Language == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
                        };
                        return null;
                    }
                    else if (!request.IsSuccessStatusCode)
                    {
                        Debug.WriteLine($"Error {content}");
                        return new Models.IResponse<T>()
                        {
                            IsPassed = false,
                            Message = $"StatusCode is ( {request.StatusCode} ) {Environment.NewLine} Error : {content}  ",
                        };
                    }
                    var obj = System.Text.Json.JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return new Models.IResponse<T>()
                    {
                        IsPassed = true,
                        Message = $"Ok",
                        Data = obj,
                    };
                }
            }
            catch (Exception ex)
            {
                string Error = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                Debug.WriteLine(Error);
                ExtensionLogMethods.LogExtension(Error, $"url : {client.BaseAddress.AbsoluteUri}/{url} {Environment.NewLine} Data : {json}", "ApiServices", "PostDataWithFile");
                return new Models.IResponse<T>()
                {
                    IsPassed = false,
                    Message = Error,
                };
            }
            finally
            {
                try
                {
                    if (MopupService.Instance.PopupStack.Count > 0)
                        await MopupService.Instance.PopAllAsync();
                }
                catch (Exception ex)
                {
                    ExtensionLogMethods.LogExtension(ex, "", "", "Dispose");
                }
            }
        }
        #endregion

        #region PostDataWithFileWithBaseUrl<T, T1>(T1 data, string control, string action, Dictionary<string, string> d, List<Stream> files, Enums.AuthorizationType Authorization = 0)
        public async Task<Models.IResponse<T>> PostDataWithFileWithBaseUrl<T, T1>(T1 data, string control, string action, Dictionary<string, string> d, string BaseUrl, string apiAddress, List<Dictionary<string, Stream>> files, Enums.AuthorizationType Authorization = 0)
        {
            string json = "", url = "";
            try
            {
                await MopupService.Instance.PushAsync(new LoadingPopup());
                {
                    HttpClient client = new HttpClient(new HttpClientHandler())
                    {
                        Timeout = TimeSpan.FromSeconds(90),
                        BaseAddress = new Uri(BaseUrl),
                    };
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if (Authorization == Enums.AuthorizationType.Token)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AuthoToken);
                    }
                    else if (Authorization == Enums.AuthorizationType.UserNamePassword)
                    {
                        var byteArray = Encoding.ASCII.GetBytes($"{Settings.UserName}:{Settings.Password}");
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
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
                    Debug.WriteLine($"Url: {BaseUrl}/{url} ");
                    if (files != null)
                    {
                        var formData = new MultipartFormDataContent();
                        for (int i = 0; i < files.Count; i++)
                        {
                            HttpContent fileStreamContent = new StreamContent(files[i].FirstOrDefault().Value);
                            fileStreamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") { Name = "file", FileName = $"File{files[i].FirstOrDefault().Key}" };
                            fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                            formData.Add(fileStreamContent);
                        }
                        request = await client.PostAsync(url, formData);
                    }
                    else
                    {
                        request = await client.PostAsync(url, dataConverted);
                    }
                    var content = await request.Content.ReadAsStringAsync();
                    if (!request.IsSuccessStatusCode && (
                        request.StatusCode == HttpStatusCode.GatewayTimeout ||
                        request.StatusCode == HttpStatusCode.RequestTimeout))
                    {
                        Debug.WriteLine($"Error {content}");
                        return new Models.IResponse<T>()
                        {
                            IsPassed = false,
                            Message = $"Time Out :: StatusCode is ( {request.StatusCode} ) ",
                        };
                    }
                    else if (request.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        Debug.WriteLine($"Error {content}");
                        Settings.AuthoToken = ""; client.DefaultRequestHeaders.Authorization = null; Toast.ShowToastError(SharedResources.Msg_TimeExpired);
                        App.Current.MainPage = new NavigationPage(new SignInSignUpPage())
                        {
                            FlowDirection = Settings.Language == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
                        };
                        return null;
                    }
                    else if (!request.IsSuccessStatusCode)
                    {
                        Debug.WriteLine($"Error {content}");
                        return new Models.IResponse<T>()
                        {
                            IsPassed = false,
                            Message = $"StatusCode is ( {request.StatusCode} ) {Environment.NewLine} Error : {content}  ",
                        };
                    }
                    var obj = System.Text.Json.JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return new Models.IResponse<T>()
                    {
                        IsPassed = true,
                        Message = $"Ok",
                        Data = obj,
                    };
                }
            }
            catch (Exception ex)
            {
                string Error = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                Debug.WriteLine(Error);
                ExtensionLogMethods.LogExtension(Error, $"url : {client.BaseAddress.AbsoluteUri}/{url} {Environment.NewLine} Data : {json}", "ApiServices", "PostDataWithFile");
                return new Models.IResponse<T>()
                {
                    IsPassed = false,
                    Message = Error,
                };
            }
            finally
            {
                try
                {
                    if (MopupService.Instance.PopupStack.Count > 0)
                        await MopupService.Instance.PopAllAsync();
                }
                catch (Exception ex)
                {
                    ExtensionLogMethods.LogExtension(ex, "", "", "Dispose");
                }
            }
        }
        #endregion

        #region PostDataMultipart(data,control,action,d,files,IsAuthorization)
        public async Task<Models.IResponse<T>> PostDataMultipart<T>(string control, string action, Dictionary<string, string> d, Dictionary<string, object> formData, Enums.AuthorizationType Authorization = 0)
        {
            string url = "";
            try
            {
                await MopupService.Instance.PushAsync(new LoadingPopup());
                {
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
                    Debug.WriteLine($"Url: {BaseAddress}/{url} ");
                    var client = new RestClient($"{BaseAddress}/{url}");
                    var request = new RestRequest();
                    if (Authorization == Enums.AuthorizationType.Token)
                    {
                        request.AddHeader("Authorization", $"Bearer {Settings.AuthoToken}");
                    }
                    else if (Authorization == Enums.AuthorizationType.UserNamePassword)
                    {
                        // client.Authenticator = new HttpBasicAuthenticator(Settings.UserName, Settings.Password);
                        var byteArray = System.Text.Encoding.ASCII.GetBytes($"{Settings.UserName}:{Settings.Password}");
                        request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(byteArray));
                    }
                    request.AlwaysMultipartFormData = true;
                    foreach (var item in formData)
                    {
                        request.AddParameter(Parameter.CreateParameter(item.Key, item.Value, ParameterType.GetOrPost));
                    }
                    var response = client.ExecutePost(request);
                    var content = response.Content;
                    if (!response.IsSuccessful && (
                        response.StatusCode == HttpStatusCode.GatewayTimeout ||
                        response.StatusCode == HttpStatusCode.RequestTimeout))
                    {
                        Debug.WriteLine($"Error {content}");
                        return new Models.IResponse<T>()
                        {
                            IsPassed = false,
                            Message = $"Time Out :: StatusCode is ( {response.StatusCode} ) ",
                        };
                    }
                    else if (!response.IsSuccessful)
                    {
                        Debug.WriteLine($"Error {content}");
                        return new Models.IResponse<T>()
                        {
                            IsPassed = false,
                            Message = $"StatusCode is ( {response.StatusCode} ) {Environment.NewLine} Error : {content}  ",
                        };
                    }
                    var obj = System.Text.Json.JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return new Models.IResponse<T>()
                    {
                        IsPassed = true,
                        Message = $"Ok",
                        Data = obj,
                    };
                }
            }
            catch (Exception ex)
            {
                string Error = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                Debug.WriteLine(Error);
                ExtensionLogMethods.LogExtension(Error, $"url : {client.BaseAddress.AbsoluteUri}/{url} {Environment.NewLine} Data : {System.Text.Json.JsonSerializer.Serialize(formData)}", "ApiServices", "PostDataMultipart");
                return new Models.IResponse<T>()
                {
                    IsPassed = false,
                    Message = Error,
                };
            }
            finally
            {
                try
                {
                    if (MopupService.Instance.PopupStack.Count > 0)
                        await MopupService.Instance.PopAllAsync();
                }
                catch (Exception ex)
                {
                    ExtensionLogMethods.LogExtension(ex, "", "", "Dispose");
                }
            }
        }
        #endregion

        #region PostDataMultipartNoLoding(data,control,action,d,files,IsAuthorization)

        [Obsolete]
        public async Task<Models.IResponse<T>> PostDataMultipartNoLoding<T>(string control, string action, Dictionary<string, string> d, Dictionary<string, object> formData, Enums.AuthorizationType Authorization = 0)
        {

            string url = "";
            try
            {
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
                Debug.WriteLine($"Url: {BaseAddress}{url} ");
                var client = new RestClient($"{BaseAddress}/{url}");
                var request = new RestRequest();
                if (Authorization == Enums.AuthorizationType.Token)
                {
                    request.AddHeader("Authorization", $"Bearer {Settings.AuthoToken}");
                }
                else if (Authorization == Enums.AuthorizationType.UserNamePassword)
                {
                    // client.Authenticator = new HttpBasicAuthenticator(Settings.UserName, Settings.Password);
                    var byteArray = System.Text.Encoding.ASCII.GetBytes($"{Settings.UserName}:{Settings.Password}");
                    request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(byteArray));
                }
                request.AlwaysMultipartFormData = true;
                foreach (var item in formData)
                {
                    request.AddParameter(Parameter.CreateParameter(item.Key, item.Value, ParameterType.GetOrPost));
                }
                var response = client.ExecutePost(request);
                var content = response.Content;
                if (!response.IsSuccessful && (
                    response.StatusCode == HttpStatusCode.GatewayTimeout ||
                    response.StatusCode == HttpStatusCode.RequestTimeout))
                {
                    Debug.WriteLine($"Error {content}");
                    return new Models.IResponse<T>()
                    {
                        IsPassed = false,
                        Message = $"Time Out :: StatusCode is ( {response.StatusCode} ) ",
                    };
                }
                else if (!response.IsSuccessful)
                {
                    Debug.WriteLine($"Error {content}");
                    return new Models.IResponse<T>()
                    {
                        IsPassed = false,
                        Message = $"StatusCode is ( {response.StatusCode} ) {Environment.NewLine} Error : {content}  ",
                    };
                }
                var obj = System.Text.Json.JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return new Models.IResponse<T>()
                {
                    IsPassed = true,
                    Message = $"Ok",
                    Data = obj,
                };
            }
            catch (Exception ex)
            {
                string Error = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                Debug.WriteLine(Error);
                ExtensionLogMethods.LogExtension(Error, $"url : {client.BaseAddress.AbsoluteUri}/{url} {Environment.NewLine} Data : {System.Text.Json.JsonSerializer.Serialize(formData)}", "ApiServices", "PostDataMultipart");
                return new Models.IResponse<T>()
                {
                    IsPassed = false,
                    Message = Error,
                };
            }
            finally
            {
                try
                {
                    if (MopupService.Instance.PopupStack.Count > 0)
                        await MopupService.Instance.PopAllAsync();
                }
                catch (Exception ex)
                {
                    ExtensionLogMethods.LogExtension(ex, "", "", "Dispose");
                }
            }
        }
        #endregion

        #region PutDataMultipart(data,control,action,d,files,IsAuthorization)
        public async Task<Models.IResponse<T>> PutDataMultipart<T>(string control, string action, Dictionary<string, string> d, Dictionary<string, object> formData, Enums.AuthorizationType Authorization = 0)
        {

            string url = "";
            try
            {
                await MopupService.Instance.PushAsync(new LoadingPopup());
                {
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
                    var client = new RestClient($"{BaseAddress}/{url}");
                    var request = new RestRequest();
                    if (Authorization == Enums.AuthorizationType.Token)
                    {
                        request.AddHeader("Authorization", $"Bearer {Settings.AuthoToken}");
                    }
                    else if (Authorization == Enums.AuthorizationType.UserNamePassword)
                    {
                        // client.Authenticator = new HttpBasicAuthenticator(Settings.UserName, Settings.Password);
                        var byteArray = System.Text.Encoding.ASCII.GetBytes($"{Settings.UserName}:{Settings.Password}");
                        request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(byteArray));
                    }
                    request.AlwaysMultipartFormData = true;
                    foreach (var item in formData)
                    {
                        request.AddParameter(Parameter.CreateParameter(item.Key, item.Value, ParameterType.GetOrPost));
                    }
                    var response = client.ExecutePut(request);
                    var content = response.Content;
                    if (!response.IsSuccessful && (
                        response.StatusCode == HttpStatusCode.GatewayTimeout ||
                        response.StatusCode == HttpStatusCode.RequestTimeout))
                    {
                        Debug.WriteLine($"Error {content}");
                        return new Models.IResponse<T>()
                        {
                            IsPassed = false,
                            Message = $"Time Out :: StatusCode is ( {response.StatusCode} ) ",
                        };
                    }
                    else if (!response.IsSuccessful)
                    {
                        Debug.WriteLine($"Error {content}");
                        return new Models.IResponse<T>()
                        {
                            IsPassed = false,
                            Message = $"StatusCode is ( {response.StatusCode} ) {Environment.NewLine} Error : {content}  ",
                        };
                    }
                    var obj = System.Text.Json.JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return new Models.IResponse<T>()
                    {
                        IsPassed = true,
                        Message = $"Ok",
                        Data = obj,
                    };
                }
            }
            catch (Exception ex)
            {
                string Error = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                Debug.WriteLine(Error);
                ExtensionLogMethods.LogExtension(Error, $"url : {client.BaseAddress.AbsoluteUri}/{url} {Environment.NewLine} Data : {System.Text.Json.JsonSerializer.Serialize(formData)}", "ApiServices", "PutDataMultipart");
                return new Models.IResponse<T>()
                {
                    IsPassed = false,
                    Message = Error,
                };
            }
            finally
            {
                try
                {
                    if (MopupService.Instance.PopupStack.Count > 0)
                        await MopupService.Instance.PopAllAsync();
                }
                catch (Exception ex)
                {
                    ExtensionLogMethods.LogExtension(ex, "", "", "Dispose");
                }
            }
        }
        #endregion

        #region PutData<T, T1>(T1 data, string control, string action, Dictionary<string, string> d, Enums.AuthorizationType Authorization = 0)
        public async Task<Models.IResponse<T>> PutData<T, T1>(T1 data, string control, string action, Dictionary<string, string> d, Enums.AuthorizationType Authorization = 0)
        {
            string url = "", json = "";
            try
            {
                await MopupService.Instance.PushAsync(new LoadingPopup());
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if (Authorization == Enums.AuthorizationType.Token)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AuthoToken);
                    }
                    else if (Authorization == Enums.AuthorizationType.UserNamePassword)
                    {
                        var byteArray = Encoding.ASCII.GetBytes($"{Settings.UserName}:{Settings.Password}");
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
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
                    Debug.WriteLine($"Url: {BaseAddress}/{url} ");
                    request = await client.PutAsync(url, dataConverted);
                    var content = await request.Content.ReadAsStringAsync();
                    if (!request.IsSuccessStatusCode && (
                        request.StatusCode == HttpStatusCode.GatewayTimeout ||
                        request.StatusCode == HttpStatusCode.RequestTimeout))
                    {
                        Debug.WriteLine($"Error {content}");
                        return new Models.IResponse<T>()
                        {
                            IsPassed = false,
                            Message = $"Time Out :: StatusCode is ( {request.StatusCode} ) ",
                        };
                    }
                    else if (request.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        Debug.WriteLine($"Error {content}");
                        Settings.AuthoToken = ""; client.DefaultRequestHeaders.Authorization = null; Toast.ShowToastError(SharedResources.Msg_TimeExpired);
                        App.Current.MainPage = new NavigationPage(new SignInSignUpPage())
                        {
                            FlowDirection = Settings.Language == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
                        };
                        return null;
                    }
                    else if (!request.IsSuccessStatusCode)
                    {
                        Debug.WriteLine($"Error {content}");
                        return new Models.IResponse<T>()
                        {
                            IsPassed = false,
                            Message = $"StatusCode is ( {request.StatusCode} ) {Environment.NewLine} Error : {content}  ",
                        };
                    }
                    var obj = System.Text.Json.JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return new Models.IResponse<T>()
                    {
                        IsPassed = true,
                        Message = $"Ok",
                        Data = obj,
                    };
                }
            }
            catch (Exception ex)
            {
                string Error = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                Debug.WriteLine(Error);
                ExtensionLogMethods.LogExtension(Error, $"url : {client.BaseAddress.AbsoluteUri}/{url} {Environment.NewLine} Data : {json}", "ApiServices", "PutData");
                return new Models.IResponse<T>()
                {
                    IsPassed = false,
                    Message = Error,
                };
            }
            finally
            {
                try
                {
                    if (MopupService.Instance.PopupStack.Count > 0)
                        await MopupService.Instance.PopAllAsync();
                }
                catch (Exception ex)
                {
                    ExtensionLogMethods.LogExtension(ex, "", "", "Dispose");
                }
            }
        }
        #endregion

        #region GetData<T>(string control, string action, Dictionary<string, string> d, Enums.AuthorizationType Authorization = 0)
        public async Task<Models.IResponse<T>> GetData<T>(string control, string action, Dictionary<string, string> d, Enums.AuthorizationType Authorization = 0, bool isLoading = true)
        {
            string url = "";
            try
            {
                //if (isLoading)
                //    await MopupService.Instance.PushAsync(new LoadingPopup());
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = null;
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if (Authorization == Enums.AuthorizationType.Token)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AuthoToken);
                    }
                    else if (Authorization == Enums.AuthorizationType.UserNamePassword)
                    {
                        var byteArray = Encoding.ASCII.GetBytes($"{Settings.UserName}:{Settings.Password}");
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    }
                    HttpResponseMessage request = null;
                    StringBuilder query = new StringBuilder().Append("?");

                    if (d != null && d.Count > 0)
                    {
                        d.Add("IsActive", "true");
                        d.Add("IsDelete", "false");
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
                    Debug.WriteLine($"Url: {BaseAddress}/{url} ");
                    request = await client.GetAsync(url);
                    var content = await request.Content.ReadAsStringAsync();
                    if (!request.IsSuccessStatusCode && (
                        request.StatusCode == HttpStatusCode.GatewayTimeout ||
                        request.StatusCode == HttpStatusCode.RequestTimeout))
                    {
                        Debug.WriteLine($"Error {content}");
                        return new Models.IResponse<T>()
                        {
                            IsPassed = false,
                            Message = $"Time Out :: StatusCode is ( {request.StatusCode} ) ",
                        };
                    }
                    else if (request.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        Debug.WriteLine($"Error {content}");
                        Settings.AuthoToken = ""; client.DefaultRequestHeaders.Authorization = null;
                        Toast.ShowToastError(SharedResources.Msg_TimeExpired);
                        App.Current.MainPage = new NavigationPage(new SignInSignUpPage())
                        {
                            FlowDirection = Settings.Language == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
                        };
                        return null;
                    }
                    else if (!request.IsSuccessStatusCode)
                    {
                        Debug.WriteLine($"Error {content}");
                        return new Models.IResponse<T>()
                        {
                            IsPassed = false,
                            Message = $"StatusCode is ( {request.StatusCode} ) {Environment.NewLine} Error : {content}  ",
                        };
                    }
                    var obj = JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return new Models.IResponse<T>()
                    {
                        IsPassed = true,
                        Message = $"Ok",
                        Data = obj,
                    };
                }
            }
            catch (Exception ex)
            {
                string Error = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                Debug.WriteLine(Error);
                ExtensionLogMethods.LogExtension(Error, $"url : {client.BaseAddress.AbsoluteUri}/{url} ", "ApiServices", "GetData");
                return new Models.IResponse<T>()
                {
                    IsPassed = false,
                    Message = Error,
                };
            }
            finally
            {
                try
                {
                    if (isLoading)
                        if (MopupService.Instance.PopupStack.Count > 0)
                            await MopupService.Instance.PopAllAsync();
                }
                catch (Exception ex)
                {
                    ExtensionLogMethods.LogExtension(ex, "", "", "Dispose");
                }
            }
        }
        #endregion

        #region DeleteData(control,action,d,IsAuthorization)
        public async Task<Models.IResponse<T>> DeleteData<T>(string control, string action, Dictionary<string, string> d, Enums.AuthorizationType Authorization = 0)
        {
            string url = "";
            try
            {
                await MopupService.Instance.PushAsync(new LoadingPopup());
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if (Authorization == Enums.AuthorizationType.Token)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AuthoToken);
                    }
                    else if (Authorization == Enums.AuthorizationType.UserNamePassword)
                    {
                        var byteArray = Encoding.ASCII.GetBytes($"{Settings.UserName}:{Settings.Password}");
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
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
                    Debug.WriteLine($"Url: {BaseAddress}/{url} ");
                    request = await client.DeleteAsync(url);
                    var content = await request.Content.ReadAsStringAsync();
                    if (!request.IsSuccessStatusCode && (
                        request.StatusCode == HttpStatusCode.GatewayTimeout ||
                        request.StatusCode == HttpStatusCode.RequestTimeout))
                    {
                        Debug.WriteLine($"Error {content}");
                        return new Models.IResponse<T>()
                        {
                            IsPassed = false,
                            Message = $"Time Out :: StatusCode is ( {request.StatusCode} ) ",
                        };
                    }
                    else if (request.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        Debug.WriteLine($"Error {content}");
                        Settings.AuthoToken = ""; client.DefaultRequestHeaders.Authorization = null; Toast.ShowToastError(SharedResources.Msg_TimeExpired);
                        App.Current.MainPage = new NavigationPage(new SignInSignUpPage())
                        {
                            FlowDirection = Settings.Language == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
                        };
                        return null;
                    }
                    else if (!request.IsSuccessStatusCode)
                    {
                        Debug.WriteLine($"Error {content}");
                        return new Models.IResponse<T>()
                        {
                            IsPassed = false,
                            Message = $"StatusCode is ( {request.StatusCode} ) {Environment.NewLine} Error : {content}  ",
                        };
                    }
                    var obj = System.Text.Json.JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return new Models.IResponse<T>()
                    {
                        IsPassed = true,
                        Message = $"Ok",
                        Data = obj,
                    };
                }

            }
            catch (Exception ex)
            {
                string Error = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                Debug.WriteLine(Error);
                ExtensionLogMethods.LogExtension(Error, $"url : {client.BaseAddress.AbsoluteUri}/{url} ", "ApiServices", "DeleteData");
                return new Models.IResponse<T>()
                {
                    IsPassed = false,
                    Message = Error,
                };
            }
            finally
            {
                try
                {
                    if (MopupService.Instance.PopupStack.Count > 0)
                        await MopupService.Instance.PopAllAsync();
                }
                catch (Exception ex)
                {
                    ExtensionLogMethods.LogExtension(ex, "", "", "Dispose");
                }
            }
        }
        #endregion

        #region PostDataNoLoding<T, T1>(T1 data, string control, string action, Dictionary<string, string> d, Enums.AuthorizationType Authorization = 0)
        public async Task<Models.IResponse<T>> PostDataNoLoding<T, T1>(T1 data, string control, string action, Dictionary<string, string> d, Enums.AuthorizationType Authorization = 0)
        {
            string json = "", url = "";
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (Authorization == Enums.AuthorizationType.Token)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AuthoToken);
                }
                else if (Authorization == Enums.AuthorizationType.UserNamePassword)
                {
                    var byteArray = Encoding.ASCII.GetBytes($"{Settings.UserName}:{Settings.Password}");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
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
                Debug.WriteLine($"Url: {BaseAddress}/{url} ");
                request = await client.PostAsync(url, dataConverted);
                var content = await request.Content.ReadAsStringAsync();
                if (!request.IsSuccessStatusCode && (
                        request.StatusCode == HttpStatusCode.GatewayTimeout ||
                        request.StatusCode == HttpStatusCode.RequestTimeout))
                {
                    Debug.WriteLine($"Error {content}");
                    return new Models.IResponse<T>()
                    {
                        IsPassed = false,
                        Message = $"Time Out :: StatusCode is ( {request.StatusCode} ) ",
                    };
                }
                else if (request.StatusCode == HttpStatusCode.Unauthorized)
                {
                    Debug.WriteLine($"Error {content}");
                    Settings.AuthoToken = ""; client.DefaultRequestHeaders.Authorization = null; Toast.ShowToastError(SharedResources.Msg_TimeExpired);
                    App.Current.MainPage = new NavigationPage(new SignInSignUpPage())
                    {
                        FlowDirection = Settings.Language == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
                    };
                    return null;
                }
                else if (!request.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"Error {content}");
                    return new Models.IResponse<T>()
                    {
                        IsPassed = false,
                        Message = $"StatusCode is ( {request.StatusCode} ) {Environment.NewLine} Error : {content}  ",
                    };
                }
                var obj = System.Text.Json.JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return new Models.IResponse<T>()
                {
                    IsPassed = true,
                    Message = $"Ok",
                    Data = obj,
                };
            }
            catch (Exception ex)
            {
                string Error = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                Debug.WriteLine(Error);
                ExtensionLogMethods.LogExtension(Error, $"url : {client.BaseAddress.AbsoluteUri}/{url} {Environment.NewLine} Data : {json}", "ApiServices", "PostDataNoLoding");
                return new Models.IResponse<T>()
                {
                    IsPassed = false,
                    Message = Error,
                };
            }
            finally
            {
                try
                {
                    if (MopupService.Instance.PopupStack.Count > 0)
                        await MopupService.Instance.PopAllAsync();
                }
                catch (Exception ex)
                {
                    ExtensionLogMethods.LogExtension(ex, "", "", "Dispose");
                }
            }
        }
        #endregion

        #region GetDataNoLoding(control,action,d,IsAuthorization)
        public async Task<Models.IResponse<T>> GetDataNoLoding<T>(string control, string action, Dictionary<string, string> d, Enums.AuthorizationType Authorization = 0)
        {
            string url = "";
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (Authorization == Enums.AuthorizationType.Token)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AuthoToken);
                }
                else if (Authorization == Enums.AuthorizationType.UserNamePassword)
                {
                    var byteArray = Encoding.ASCII.GetBytes($"{Settings.UserName}:{Settings.Password}");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                }
                HttpResponseMessage request = null;
                StringBuilder query = new StringBuilder().Append("?");

                if (d != null && d.Count > 0)
                {
                    d.Add("IsActive", "true");
                    d.Add("IsDelete", "false");
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
                request = await client.GetAsync(url);
                var content = await request.Content.ReadAsStringAsync();
                if (!request.IsSuccessStatusCode && (
                        request.StatusCode == HttpStatusCode.GatewayTimeout ||
                        request.StatusCode == HttpStatusCode.RequestTimeout))
                {
                    Debug.WriteLine($"Error {content}");
                    return new Models.IResponse<T>()
                    {
                        IsPassed = false,
                        Message = $"Time Out :: StatusCode is ( {request.StatusCode} ) ",
                    };
                }
                else if (request.StatusCode == HttpStatusCode.Unauthorized)
                {
                    Debug.WriteLine($"Error {content}");
                    Settings.AuthoToken = ""; client.DefaultRequestHeaders.Authorization = null; Toast.ShowToastError(SharedResources.Msg_TimeExpired);
                    App.Current.MainPage = new NavigationPage(new SignInSignUpPage())
                    {
                        FlowDirection = Settings.Language == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
                    };
                    return null;
                }
                else if (!request.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"Error {content}");
                    return new Models.IResponse<T>()
                    {
                        IsPassed = false,
                        Message = $"StatusCode is ( {request.StatusCode} ) {Environment.NewLine} Error : {content}  ",
                    };
                }
                var obj = JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return new Models.IResponse<T>()
                {
                    IsPassed = true,
                    Message = $"Ok",
                    Data = obj,
                };
            }
            catch (Exception ex)
            {
                string Error = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                Debug.WriteLine(Error);
                ExtensionLogMethods.LogExtension(Error, $"url : {client.BaseAddress.AbsoluteUri}/{url} ", "ApiServices", "GetDataNoLoding");
                return new Models.IResponse<T>()
                {
                    IsPassed = false,
                    Message = Error,
                };
            }
            finally
            {
                try
                {
                    if (MopupService.Instance.PopupStack.Count > 0)
                        await MopupService.Instance.PopAllAsync();
                }
                catch (Exception ex)
                {
                    ExtensionLogMethods.LogExtension(ex, "", "", "Dispose");
                }
            }
        }
        #endregion
    }
}
