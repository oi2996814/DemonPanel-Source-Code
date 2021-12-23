using Fiddler;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Demon_Panel
{
    internal class BHVRSeession
    {
        public static event CookieHandler OnTokenReceived
        {
            add
            {
                CookieHandler cookieHandler = BhvrSession;
                CookieHandler cookieHandler2;
                do
                {
                    cookieHandler2 = cookieHandler;
                    CookieHandler value2 = (CookieHandler)Delegate.Combine(cookieHandler2, value);
                    cookieHandler = Interlocked.CompareExchange(ref BhvrSession, value2, cookieHandler2);
                }
                while (cookieHandler != cookieHandler2);
            }
            remove
            {
                CookieHandler cookieHandler = BhvrSession;
                CookieHandler cookieHandler2;
                do
                {
                    cookieHandler2 = cookieHandler;
                    CookieHandler value2 = (CookieHandler)Delegate.Remove(cookieHandler2, value);
                    cookieHandler = Interlocked.CompareExchange(ref BhvrSession, value2, cookieHandler2);
                }
                while (cookieHandler != cookieHandler2);
            }
        }


        public static void start()
        {


            FiddlerApplication.BeforeRequest += new SessionStateHandler(CatchBeforeRequest);
            EnsureRootCertificate();
            if (Main.Host == "steam")
                Process.Start("steam://rungameid/381210");
            else
            {
                MessageBox.Show("Please launch the game manually over your launcher.");
            }
            FiddlerApplication.Startup(((FiddlerCoreStartupSettingsBuilder<FiddlerCoreStartupSettingsBuilder, FiddlerCoreStartupSettings>)((FiddlerCoreStartupSettingsBuilder<FiddlerCoreStartupSettingsBuilder, FiddlerCoreStartupSettings>)((FiddlerCoreStartupSettingsBuilder<FiddlerCoreStartupSettingsBuilder, FiddlerCoreStartupSettings>)((FiddlerCoreStartupSettingsBuilder<FiddlerCoreStartupSettingsBuilder, FiddlerCoreStartupSettings>)((FiddlerCoreStartupSettingsBuilder<FiddlerCoreStartupSettingsBuilder, FiddlerCoreStartupSettings>)new FiddlerCoreStartupSettingsBuilder().ListenOnPort(0)).RegisterAsSystemProxy()).ChainToUpstreamGateway()).DecryptSSL()).OptimizeThreadPool()).Build());
        }

        public static void Stop()
        {
            DisableProxy();
            FiddlerApplication.Shutdown();
        }

        public static void CookieAdd(string cookie)
        {
            BhvrSession(cookie);
        }

        public static bool RemoveRootCertificate()
        {
            bool result;
            try
            {
                CertMaker.removeFiddlerGeneratedCerts(true);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static void DisableProxy()
        {
            try
            {
                FiddlerApplication.Shutdown();
                string keyName = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
                Registry.SetValue(keyName, "ProxyEnable", 0);
                Registry.SetValue(keyName, "ProxyServer", "");
                Registry.SetValue(keyName, "ProxyOverride", "");
            }
            catch
            {
            }
        }

        public static bool EnsureRootCertificate()
        {
            if (!CertMaker.rootCertExists())
            {
                if (!CertMaker.createRootCert())
                {
                    return false;
                }
                if (!CertMaker.trustRootCert())
                {
                    return false;
                }
                FiddlerApplication.Prefs.GetStringPref("fiddler.certmaker.bc.cert", null);
                FiddlerApplication.Prefs.GetStringPref("fiddler.certmaker.bc.key", null);
            }
            return true;
        }

        public static void CatchBeforeRequest(Session Core)
        {
            if (Core.uriContains("api/v1/Inventories"))
            {
                if (Core.uriContains("steam.live"))
                {
                    Main.Host = "steam";
                    Main.Kraken = "steam";

                }
                else if (Core.uriContains("grdk.live"))
                {
                    Main.Host = "grdk";
                    Main.Kraken = "grdk";

                }
                else if (Core.uriContains("brill.live"))
                {
                    Main.Host = "brill";
                    Main.Kraken = "egs";

                }
                Main.UserAgent = Core.oRequest.headers["User-Agent"];
                CookieAdd(Core.oRequest["Cookie"]);
            }
        }


        public static CookieHandler BhvrSession;

        public delegate void CookieHandler(string cookie);
    }
}
