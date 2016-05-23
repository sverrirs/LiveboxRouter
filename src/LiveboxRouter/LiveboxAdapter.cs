using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Orange.Livebox.json;

namespace Orange.Livebox
{
    public class LiveboxAdapter
    {
        private CookieContainer _cookieJar = null;
        public string UserName { get; set; }
        public string Password { get; set; }

        private static string UrlLogin = "/authenticate?username={0}&password={1}";

        public string Origin => "http://192.168.1.1";

        private LoginResult _loginResult;

        public LiveboxAdapter(string userName, string password )
        {
            UserName = userName;
            Password = password;
        }

        #region Login to Livebox

        public Task<LoginResult> LoginAsync()
        {
            if (_cookieJar != null)
                throw new InvalidOperationException("Already logged in");

            // Login and get status
            return Task.FromResult(CoreLogin(string.Format(UrlLogin, UserName, Password)));
        }

        private LoginResult CoreLogin(string url)
        {
            var uri = new Uri(Origin + url);

            // Default cache policy
            HttpWebRequest.DefaultCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);

            // If the cookie jar is empty then do a fake call to get a session cookie
            try
            {
                if (_cookieJar == null)
                {
                    _cookieJar = new CookieContainer();
                    var request = (HttpWebRequest) WebRequest.Create(uri);

                    request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
                    request.CookieContainer = _cookieJar;
                    request.Method = WebRequestMethods.Http.Post;
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    request.Accept = "text/javascript, text/html, application/xml, text/xml, */*";
                    request.KeepAlive = true;
                    request.Headers.Add("X-Prototype-Version", "1.7");
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");

                    request.CookieContainer.Add(new Cookie("25200fcf/accept-language", WebUtility.UrlEncode("en,en-US"), "/", uri.Host));
                    request.CookieContainer.Add(new Cookie("25200fcf/zoom-accessibility", "small", "/", uri.Host));
                    request.CookieContainer.Add(new Cookie("25200fcf/contrast-accessibility", "contrast1", "/", uri.Host));
                    request.CookieContainer.Add(new Cookie("25200fcf/language", "en", "/", uri.Host));
                    request.CookieContainer.Add(new Cookie("25200fcf/possibleLanguages", WebUtility.UrlEncode("en,fr"), "/", uri.Host));
                    request.CookieContainer.Add(new Cookie("25200fcf/expirydate", DateTime.Now.AddMinutes(10).ToString("ddd MMM dd yyyy HH:mm:ss") + " GMT+0200 (Romance Daylight Time)", "/", uri.Host));

                    request.CookieContainer.Add(new Cookie("25200fcf/WanInterfaceConfig", "DSL", "/", uri.Host));



                    using (var response = (HttpWebResponse) request.GetResponse())
                    {
                        int cookieCount = _cookieJar.Count;
                        if (cookieCount <= 0)
                            throw new InvalidOperationException("Did not receive any valid session cookies form url '" + url + "'");

                        // Store the returned contextid and assign it to a cookie as well
                        _loginResult = ReadJsonFromResponse<LoginResult>(response);
                        _cookieJar.Add(new Cookie("25200fcf/context", _loginResult.Data.ContextID, "/", uri.Host));
                        _cookieJar.Add(new Cookie("25200fcf/login", UserName, "/", uri.Host));
                    }
                }

                return _loginResult; // Success
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                throw;
            }
        }

        #endregion

        #region Get Device Info

        public Task<DeviceInfoResult> GetDeviceInfo()
        {
            return Task.FromResult(CoreGetDeviceInfo());
        }

        private DeviceInfoResult CoreGetDeviceInfo()
        {
            try
            {
                var uri = new Uri(Origin + "/sysbus/DeviceInfo?_restDepth=-1");
                var request = CreateRequest(uri, requestMethod: WebRequestMethods.Http.Get, omitContentType:true);
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    return ReadJsonFromResponse<DeviceInfoResult>(response);
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                throw;
            }
        }

        #endregion


        #region Manipulate Firewall levels

        public Task<StringResult> GetFirewallLevel()
        {
            return Task.FromResult(CoreGetFirewallLevel());
        }

        private StringResult CoreGetFirewallLevel()
        {
            try
            {
                var uri = new Uri(Origin + "/sysbus/Firewall:getFirewallLevel");
                var request = CreateRequest(uri, "{\"parameters\":{}}");
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    return ReadJsonFromResponse<StringResult>(response);
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                throw;
            }
        }

        public Task<SimpleResult> SetFirewallToMedium()
        {
            return Task.FromResult(SetFirewallLevel("Medium"));
        }

        public Task<SimpleResult> SetFirewallToCustom()
        {
            return Task.FromResult(SetFirewallLevel("Custom"));
        }

        private SimpleResult SetFirewallLevel(string level)
        {
            try
            {
                var uriip6 = new Uri(Origin + "/sysbus/Firewall:setFirewallIPv6Level");
                var requestIp6 = CreateRequest(uriip6, "{\"parameters\":{\"level\":\"" + level + "\"}}");
                using (var response = (HttpWebResponse) requestIp6.GetResponse())
                {
                    var result = ReadJsonFromResponse<SimpleResult>(response);
                    if (!result.Status.GetValueOrDefault())
                        return result;
                    //throw new ArgumentException("Could not set firewall ipv6 level, aborting");
                }

                var uriIp4 = new Uri(Origin + "/sysbus/Firewall:setFirewallLevel");
                var requestIp4 = CreateRequest(uriIp4, "{\"parameters\":{\"level\":\"" + level + "\"}}");
                using (var response = (HttpWebResponse) requestIp4.GetResponse())
                {
                    return ReadJsonFromResponse<SimpleResult>(response);
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                throw;
            }
        }

        #endregion

        #region Manipulate Firewall custom rules

        public Task<FirewallRule[]> GetFirewallCustomRules()
        {
            return Task.FromResult(CoreGetFirewallCustomRules());
        }

        private FirewallRule[] CoreGetFirewallCustomRules()
        {
            try
            {
                var uri = new Uri(Origin + "/sysbus/Firewall:getCustomRule");
                var request = CreateRequest(uri, "{\"parameters\":{\"chain\":\"Custom\"}}");
                //{"parameters":{"chain":"Custom_V6In"}}
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var result = ReadJsonFromResponse<FirewallRuleResults>(response);
                    if (result != null)
                        return result.Status.Values.ToArray();
                }
                return new FirewallRule[0];
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                throw;
            }
        }

        #endregion

        #region Get the status of the network

        public Task<WANData> GetNetworkStatus()
        {
            return Task.FromResult(CoreGetNetworkStatus());
        }

        private WANData CoreGetNetworkStatus()
        {
            try
            {
                var uri = new Uri(Origin + "/sysbus/NMC:getWANStatus");
                var request = CreateRequest(uri, "{\"parameters\":{}}");
                using (var response = (HttpWebResponse) request.GetResponse())
                {

                    var result = ReadJsonFromResponse<WANStatus>(response);
                    if (result.Status.GetValueOrDefault())
                        return result.Data;
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                throw;
            }
        }

        #endregion

        #region Utilitie functions

        private HttpWebRequest CreateRequest(Uri uri, string content = null, bool omitContentType = false, string requestMethod = WebRequestMethods.Http.Post)
        {
            var request = (HttpWebRequest) WebRequest.Create(uri);

            request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            request.CookieContainer = _cookieJar;
            request.Method = requestMethod;
            if( !omitContentType )
                request.ContentType = "application/x-sah-ws-1-call+json; charset=UTF-8";
            request.Accept = "text/javascript";
            request.KeepAlive = true;
            request.Headers.Add("X-Context", _loginResult.Data.ContextID);
            request.Headers.Add("X-Prototype-Version", "1.7");
            request.Headers.Add("X-Sah-Request-Type", "idle");
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");

            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";

            request.ReadWriteTimeout = request.Timeout = 30000;

            // Write the Post content if there is one supplied
            if (content != null)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(content);
                request.ContentLength = buffer.Length;

                using (var reqStream = request.GetRequestStream())
                {
                    reqStream.Write(buffer, 0, buffer.Length);
                }
            }

            return request;
        }

        private T ReadJsonFromResponse<T>(HttpWebResponse response)
        {
            using (Stream responseStream = response.GetResponseStream())
            {
                if (responseStream == null)
                    return default(T);

                string rawReplyData = null;
                // First complete the reading from the stream and close it before doing more
                using (var sr = new StreamReader(responseStream, Encoding.GetEncoding("iso8859-1")))
                {
                    rawReplyData = sr.ReadToEnd();
                }

                // The Livebox will return a JSON object that may have the "result" element which contains 
                // the actual JSON return result object from the operation. An exception to this is the 
                // login functionality that will return the core object directly without being wrapped in the 
                // {"result": {...}} harness

                // Attempt to locate and partially parse the result data out of the JSON object
                var obj = JObject.Parse(rawReplyData);
                JToken resultObject;
                if (obj.TryGetValue("result", out resultObject))
                    rawReplyData = resultObject.ToString();

                // Now convert the reply (filtered or not) into the desired typed object
                return JsonConvert.DeserializeObject<T>(rawReplyData);
            }
        }

        private static CookieCollection GetAllCookies(CookieContainer cookieJar, string scheme = "https")
        {
            var cookieCollection = new CookieCollection();

            Hashtable table = (Hashtable) cookieJar.GetType().InvokeMember("m_domainTable",
                BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance,
                null, cookieJar, new object[] {});
            foreach (string rawKey in table.Keys)
            {
                // Skip dots in the beginning, the key value is the domain name for the cookies
                var key = rawKey.TrimStart('.');

                // Invoke the private function to get the list of cookies
                var list = (SortedList) table[rawKey].GetType().InvokeMember("m_list",
                    BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance,
                    null,
                    table[key],
                    new object[] {});

                foreach (var uri in list.Keys.Cast<string>()
                    .Select(listkey => new Uri(scheme + "://" + key + listkey)))
                {
                    cookieCollection.Add(cookieJar.GetCookies(uri));
                }
            }

            return cookieCollection;
        }

        #endregion

    }
}
