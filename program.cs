//IF YOU NEED THE REST OF THE MISSING CODE Contact me on Telegram (https://t.me/dev_bot_oficial).


    using System; 
    using System.Collections.Generic;
    using System.Threading;
    using System.IO;
    using System.Linq;
    using Youtube_Viewers.Helpers;
    using Leaf.xNet;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Net;

    namespace YtbView
    {
    class Program
    {
    static string id;
    static int threadsCount;

    static int pos = 0;

    static ProxyQueue scraper;
    static ProxyType proxyType;
    static bool updateProxy = false;



    static string buildWatchtimeUrl(Dictionary<string, string> args2)
    {
    var url = "https://www.youtube.com/api/stats/watchtime?";
    foreach(var arg in args2)
    {
        url += $"{arg.Key}={arg.Value}";
    }
    return url;
    }

    static string buildPlaybackUrl(Dictionary<string, string> args1)
    {
    var url = "https://www.youtube.com/api/stats/playback?";
    foreach (var arg in args1)
    {
        url += $"{arg.Key}={arg.Value}";
    }
    return url;
    }

    static void Worker()
    {
    while (true)
    {
        try
        {
            using (var req = new HttpRequest()
            {
                Proxy = scraper.Next(),
                Cookies = new CookieStorage()
            })
            {

                var _rndCookint = GetRNDint();

                req.UserAgentRandomize();
                //req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/109.0";
                req.Cookies.Container.Add(new Uri("https://www.youtube.com"), new Cookie("CONSENT", "YES+cb.20221228-17-p0.en-GB+FX+" + _rndCookint));
                req.Cookies.Container.Add(new Uri("https://www.youtube.com"), new Cookie("",""));
                req.Cookies.Container.Add(new Uri("https://www.youtube.com"), new Cookie("", ""));
                req.Cookies.Container.Add(new Uri("https://www.youtube.com"), new Cookie("", ""));
                req.Cookies.Container.Add(new Uri("https://www.youtube.com"), new Cookie("", ""));
                 req.Cookies.Container.Add(new Uri("https://www.youtube.com"), new Cookie("", ""));
                req.Cookies.Container.Add(new Uri("https://www.youtube.com"), new Cookie("GPS", "1"));
                
//IF YOU NEED THE REST OF THE MISSING CODE Contact me on Telegram (https://t.me/dev_bot_oficial).

                var sres = req.Get($"https://www.youtube.com/watch?v={id}").ToString();
                    var _url = sres;
                var viewersTemp = string.Join("", RegularExpressions.Viewers.Match(sres).Groups[1].Value.Where(char.IsDigit)); //number of viewers
                string _watchtimeURL = sres.Split(new string[] { "videostatsWatchtimeUrl\":{\"baseUrl\":\"" }, StringSplitOptions.None)[1].Split(new string[] { "\"}" }, StringSplitOptions.None)[0].Replace("\\u0026", "&").Replace("%2C", ",").Replace("\\/", "/");
                string _playbackURL = sres.Split(new string[] { "videostatsPlaybackUrl\":{\"baseUrl\":\"" }, StringSplitOptions.None)[1].Split(new string[] { "\"}" }, StringSplitOptions.None)[0].Replace("\\u0026", "&").Replace("%2C", ",").Replace("\\/", "/");
                string strCL = _watchtimeURL.Split(new string[] { "cl=" }, StringSplitOptions.None)[1].Split(new char[] { '&' })[0];
                string strEi = _watchtimeURL.Split(new string[] { "ei=" }, StringSplitOptions.None)[1].Split(new char[] { '&' })[0];
                string strOf = _watchtimeURL.Split(new string[] { "of=" }, StringSplitOptions.None)[1].Split(new char[] { '&' })[0];
                string strVm = _watchtimeURL.Split(new string[] { "vm=" }, StringSplitOptions.None)[1].Split(new char[] { '&' })[0];
                string fexp = _watchtimeURL.Split(new string[] { "fexp=" }, StringSplitOptions.None)[1].Split(new char[] { '&' })[0];
                string _plid = _watchtimeURL.Split(new string[] { "plid=" }, StringSplitOptions.None)[1].Split(new char[] { '&' })[0];
            
                string cbrand = sres.Split(new string[] { "u0026ceng\\" }, StringSplitOptions.None)[1].Split(new char[] { '\\' })[0].Replace("u003d", "");//"Gecko,


                        

                var start = DateTime.UtcNow;


                    var args1 = new Dictionary<string, string>
                    {
                        ["&ns"] = "yt",
                        ["&el"] = "detailpage",
                        ["&cpn"] = cpn,
                        ["&docid"] = id,
                        ["&ver"] = "2",
                        //IF YOU NEED THE REST OF THE MISSING CODE Contact me on Telegram (https://t.me/dev_bot_oficial).
                    };
                        
                var args2 = new Dictionary<string, string>
                {
                    ["&ns"] = "yt",
                    ["&el"] = "detailpage",
                    ["&cpn"] = cpn,
                    ["&docid"] = id,
                    //IF YOU NEED THE REST OF THE MISSING CODE Contact me on Telegram (https://t.me/dev_bot_oficial).        
                };

                string urlToGetPlayback = buildPlaybackUrl(args1);
                string urlToGetWatchtime = buildWatchtimeUrl(args2);
                req.AcceptEncoding ="";
                req.Get(urlToGetPlayback.Replace("watchtime", "playback"));
                req.Get(urlToGetWatchtime.Replace("watchtime", "playback"));
                req.AddHeader("Host", "www.youtube.com");
                req.AddHeader("Referer", $"https://www.youtube.com/watch?v={id}");
                req.AddHeader("Accept", "");
                req.AddHeader("Accept-Language", "fr-FR,fr;q=0.9,en-US;q=0.8,en;q=0.7");
                req.AddHeader("Accept-Encoding", "gzip, deflate");
                req.AddHeader("Cookie", "");
                req.AddHeader("Cookie", "");
                req.AddHeader("Cookie", "");
                req.AddHeader("Cookie", "");
                req.AddHeader("Cookie", "");
                req.AddHeader("Cookie", "GPS=1");

                req.Get(urlToGetPlayback);
                req.Get(urlToGetWatchtime);

                Interlocked.Increment(ref botted);
            }
        }
        catch
        {
            Interlocked.Increment(ref errors);
        }

        Thread.Sleep(1);
    }
    }
        
    public static double GetCmt(DateTime date)
    {
    //IF YOU NEED THE REST OF THE MISSING CODE Contact me on Telegram (https://t.me/dev_bot_oficial).
    }

    public static double GetLio(DateTime date)
    {
    //IF YOU NEED THE REST OF THE MISSING CODE Contact me on Telegram (https://t.me/dev_bot_official).
    }
    
    private static Random random = new Random();
    public static string GetCPN()
    {
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_";
    return new string(Enumerable.Repeat(chars, 16)
        .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public static int GetRNDint()
    {
    return random.Next(100, 999);
    }

    }
    }
