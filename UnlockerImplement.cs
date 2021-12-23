using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Fiddler;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Demon_Panel
{
    public static class UnlockerImplement
    {
        static UnlockerImplement()
        {
            FiddlerApplication.BeforeRequest += FiddlerBeforeRequest;
            FiddlerApplication.AfterSessionComplete += FiddlerAfterSessionComplete;
            FiddlerApplication.ResetSessionCounter();
        }
        private static bool EnsureRootCertificate()
        {
            if (!CertMaker.rootCertExists())
            {
                if (!CertMaker.createRootCert())
                    return false;
                if (!CertMaker.trustRootCert())
                    return false;
                FiddlerApplication.Prefs.GetStringPref("fiddler.certmaker.bc.cert", null);
                FiddlerApplication.Prefs.GetStringPref("fiddler.certmaker.bc.key", null);
            }
            return true;
        }
        public static void FiddlerAfterSessionComplete(Session session)
        {

        }
        public static void Start()
        {
            EnsureRootCertificate();
            CONFIG.IgnoreServerCertErrors = true;
            FiddlerApplication.Startup(new FiddlerCoreStartupSettingsBuilder().ListenOnPort(8866).RegisterAsSystemProxy().ChainToUpstreamGateway().DecryptSSL().OptimizeThreadPool().Build());
        }
        public static void FiddlerBeforeRequest(Session oSession)
        {
            if (oSession.hostname == "steam.live.bhvrdbd.com" || oSession.hostname == "grdk.live.bhvrdbd.com" || oSession.hostname == "brill.live.bhvrdbd.com" || oSession.hostname == "cdn.live.dbd.bhvronline.com" || oSession.hostname == "latest.ptb.bhvrdbd.com" || oSession.hostname == "cdn.ptb.dbd.bhvronline.com")
            {
                if (oSession.uriContains("api/v1/config"))
                {
                    if (Variable.RemoveProxy)
                    {
                        RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
                        registryKey.SetValue("ProxyServer", 1);
                        registryKey.SetValue("ProxyEnable", 0);
                    }
                    Main.BHVRSession = oSession.oRequest["Cookie"].Replace("bhvrSession=", "");
                    if (oSession.uriContains("steam.live"))
                    {
                        Main.Host = "steam";
                        Main.Kraken = "steam";
                    }
                    else if (oSession.uriContains("grdk.live"))
                    {
                        Main.Kraken = "grdk";

                        Main.Host = "grdk";
                    }
                    else if (oSession.uriContains("brill.live"))
                    {
                        Main.Kraken = "egs";
                        Main.Host= "brill";
                    }
                    return;
                }
                if (oSession.uriContains("api/v1/friends/richPresence"))
                {
                   Variable.PID= oSession.url.Remove(0, oSession.url.LastIndexOf("/") + 1);
                    return;
                }
                if (oSession.uriContains("api/v1/inventories"))
                {
                    if (oSession.oRequest["x-kraken-client-os"] != "21.7.28700.1.768.64bit")
                    {
                        oSession.utilCreateResponseAndBypassServer();
                        oSession.utilSetResponseBody(Variable.Market);
                       EmulateRequest(oSession.url);
                    }

                    return;
                }
                if (Variable.NameSpoof)
                {
                    if (oSession.uriContains("api/v1/playername"))
                    {
                        if (oSession.oRequest["x-kraken-client-os"] != "21.7.28700.1.768.64bit")
                        {
                            oSession.utilCreateResponseAndBypassServer();
                            string json = System.Text.Encoding.UTF8.GetString(oSession.responseBodyBytes);
                            string jsson = System.Text.Encoding.UTF8.GetString(oSession.requestBodyBytes);

                            System.IO.File.WriteAllText("uw.txt", jsson);
                            dynamic jsonObj = JsonConvert.DeserializeObject(json);
                            jsonObj["playerName"] = Variable.Playername;
                            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                       

                            oSession.utilSetResponseBody(output);
                            EmulateRequest(oSession.url);
                        }
                    }
                }
                if (Variable.Devotion)
                {
                    if (oSession.uriContains("api/v1/extensions/playerLevels/getPlayerLevel"))
                    {
                        if (oSession.oRequest["x-kraken-client-os"] != "21.7.28700.1.768.64bit")
                        {
                            oSession.utilCreateResponseAndBypassServer();
                            string json = System.Text.Encoding.UTF8.GetString(oSession.responseBodyBytes);
                            dynamic jsonObj = JsonConvert.DeserializeObject(json);
                            jsonObj["level"] = Variable.Level;
                            jsonObj["prestigeLevel"] = Variable.Devotionn;
                            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);


                            oSession.utilSetResponseBody(output);
                            EmulateRequest(oSession.url);
                        }
                    }

                }
                if (Variable.AntiBotMatch)
                {
                    if (oSession.uriContains("api/v1/onboarding/get-bot-match-status"))
                    {
                        oSession.utilCreateResponseAndBypassServer();
                        oSession.utilSetResponseBody("{\"survivorMatchPlayed\":true,\"killerMatchPlayed\":true}");
                        return;
                    }
                }
                if (Variable.EpicSaveFile)
                {
                    if (oSession.uriContains("api/v1/players/me/states/FullProfile/binary"))
                    {
                        if (oSession.oRequest["x-kraken-client-os"] != "21.7.28700.1.768.64bit")
                        {
                            oSession.utilCreateResponseAndBypassServer();
                            oSession.oResponse["Content-Type"] = "application/octet-stream";
                            oSession.oResponse["Kraken-State-Version"] = "1";
                            oSession.oResponse["Kraken-State-Schema-Version"] = "0";
                            oSession.utilSetResponseBody(Variable.Savefile);
                            EmulateRequest(oSession.url);
                        }

                        return;
                    }
                    if (oSession.uriContains("api/v1/players/me/states/binary?schemaVersion"))
                    {
                        oSession.utilCreateResponseAndBypassServer();
                        oSession.utilSetResponseBody("{\"version\":1,\"stateName\":\"FullProfile\",\"schemaVersion\":0,\"playerId\":\"" + Variable.PID + "\"}");
                        return;
                    }

                }
                if (Variable.CurrencySpoof == true)
                {
                    if (oSession.uriContains("api/v1/wallet/currencies"))
                    {
                        if (oSession.oRequest["x-kraken-client-os"] != "21.7.28700.1.768.64bit")
                        {
                            oSession.utilCreateResponseAndBypassServer();
                            oSession.utilSetResponseBody("{\"list\":[{\"balance\":" + Variable.Shards + ",\"currency\":\"Shards\"},{\"balance\":" + Variable.Aurics + ",\"currency\":\"Cells\"},{\"balance\":" + Variable.Bloodpoints + ",\"currency\":\"BonusBloodpoints\"},{\"balance\":0,\"currency\":\"Bloodpoints\"}]}");
                            EmulateRequest(oSession.url);
                        }

                        return;
                    }
                }
                if (Variable.FreeBloodweb == true)
                {
                    if (oSession.uriContains("v1/wallet/withdraw"))
                    {
                        oSession.utilCreateResponseAndBypassServer();
                        oSession.utilSetResponseBody("{\"userId\":\"null\",\"balance\":0,\"currency\":\"USCents\"}");
                        return;
                    }
                }


            }
        }
        public static void EmulateRequest(string URL)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://" + URL);
                request.Timeout = 7000;
                request.ServicePoint.Expect100Continue = true;
                request.UserAgent = Main.UserAgent;

                request.Headers.Add("Cookie", "bhvrSession=" + Main.BHVRSession);
                request.Headers.Add("x-kraken-client-version", "5.2.2");
                request.Headers.Add("x-kraken-client-provider", "steam");
                request.Headers.Add("x-kraken-client-platform", "steam");
                request.Headers.Add("x-kraken-client-os", "21.7.28700.1.768.64bit");
                request.ContentType = "application/json";

                request.GetResponse();
            }
            catch { }
        }
    }
}
