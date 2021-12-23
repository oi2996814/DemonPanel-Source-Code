using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demon_Panel
{
	internal class InjectorRequests
	{
		internal class Injector
		{
			public static string Base64Encode(string plainText)
			{
				return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
			}

			public static string Base64Decode(string base64EncodedData)
			{
				return Encoding.UTF8.GetString(Convert.FromBase64String(base64EncodedData));
			}

			public static string Dump_FullProfile()
			{
				ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"https://{Main.Host}.live.bhvrdbd.com/api/v1/players/me/states/FullProfile/binary");
				httpWebRequest.Method = "GET";
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.Accept = "*/*";
				httpWebRequest.Headers["Accept-Encoding"] = "deflate, gzip";
				httpWebRequest.UserAgent = Main.UserAgent;
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.Headers["x-kraken-client-platform"] = Main.Kraken;
				httpWebRequest.Headers["x-kraken-client-provider"] = Main.Kraken;
				httpWebRequest.Headers["x-kraken-client-version"] = "4.0.2";
				Cookie cookie = new Cookie();
				cookie.Name = "bhvrSession";
				cookie.Value = Main.BHVRSession;
				cookie.Domain = $"{Main.Host}.live.bhvrdbd.com";
				httpWebRequest.CookieContainer = new CookieContainer();
				httpWebRequest.CookieContainer.Add(cookie);
				krakenstate = string.Empty;
				string result = null;
				try
				{
					using (WebResponse response = httpWebRequest.GetResponse())
					{
						using (HttpWebResponse httpWebResponse = (HttpWebResponse)response)
						{
							krakenstate = httpWebResponse.Headers["Kraken-State-Version"].Split(new char[]
							{
							';'
							})[0];
							using (Stream responseStream = response.GetResponseStream())
							{
								using (StreamReader streamReader = new StreamReader(responseStream))
								{
									result = streamReader.ReadLine();
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
				return result;
			}

			public static string krakenstate;
			public static bool Inject_FullProfile(string fullProfile)
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"https://{Main.Host}.live.bhvrdbd.com/api/v1/players/me/states/binary?stateName=FullProfile&version={krakenstate}&schemaVersion=0");
				httpWebRequest.Method = "POST";
				httpWebRequest.ProtocolVersion = HttpVersion.Version11;
				httpWebRequest.Host = $"{Main.Host}.live.bhvrdbd.com";
				httpWebRequest.Accept = "*/*";
				httpWebRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "deflate, gzip");
				httpWebRequest.Headers.Add("Cookie", "bhvrSession=" + Main.BHVRSession);
				byte[] bytes = Encoding.UTF8.GetBytes(fullProfile);
				httpWebRequest.ContentType = "application/octet-stream";
				httpWebRequest.Headers["x-kraken-client-platform"] = Main.Kraken;
				httpWebRequest.Headers["x-kraken-client-provider"] = Main.Kraken;
				httpWebRequest.Headers["x-kraken-client-version"] = "4.0.2";
				httpWebRequest.UserAgent = Main.UserAgent;
				httpWebRequest.ContentLength = (long)bytes.Length;
				bool result;
				try
				{
					using (System.IO.Stream requestStream = httpWebRequest.GetRequestStream())
					{
						requestStream.Write(bytes, 0, bytes.Length);
					}
					httpWebRequest.GetResponse();
					result = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					result = false;
				}
				return result;
			}

		}
	}
}