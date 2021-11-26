using Newtonsoft.Json;
using ReverseProxy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpServer
{
    public partial class ServerManager : Form
    {
        public ServerManager()
        {
            InitializeComponent();
        }

        SelfHostedWebServer selfHostedWebServer;
        bool serverStarted = false;
        private void btnStartServer_Click(object sender, EventArgs e)
        {
            if (selfHostedWebServer is null) {
                GetRequestData reqDelegate = new GetRequestData(GetRequestData);
                selfHostedWebServer = new SelfHostedWebServer(new string[] { tbServerPath.Text }, reqDelegate);
            }

            if (!serverStarted)
            {
                serverStarted = true;
                btnStartServer.Text = "Stop Server";
                lblLastReqPath.Text = "Ready !";
                lblLastResponse.Text = "Ready !";
                selfHostedWebServer.Start();
            }
            else
            {
                serverStarted = false;
                btnStartServer.Text = "Start Server";
                lblLastReqPath.Text = "Offline !";
                lblLastResponse.Text = "Offline !";
                selfHostedWebServer.Stop();
                selfHostedWebServer = null;
            }
        }

        private void GetRequestData(HttpListenerContext ctx)
        {
            // Api Callback
            String body = "";
            if (ctx.Request.HasEntityBody)
            {
                using (System.IO.Stream bodyStream = ctx.Request.InputStream) // here we have data
                {
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(bodyStream, ctx.Request.ContentEncoding))
                    {
                        body = reader.ReadToEnd();
                    }
                }
            }
            //String responseString = string.Format("Callback<br>Time: {0}<br>Request:{1}<br>Body: {2}", DateTime.Now, ctx.Request.Url, body);
            var response = JsonConvert.SerializeObject(new { Message = "OK" }) ;
            byte[] buf = Encoding.UTF8.GetBytes(response);
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength64 = buf.Length;
            ctx.Response.OutputStream.Write(buf, 0, buf.Length);

            // UpdateUI
            if (this.InvokeRequired)
            {
                this.BeginInvoke((Action)delegate { UpdateUi(ctx.Request.HttpMethod + ": " + ctx.Request.Url.ToString(), response); });
            }
            else
            {
                UpdateUi(ctx.Request.HttpMethod + ": " + ctx.Request.Url.ToString(), response);
            }
            Application.DoEvents(); //repaint or respond to msg
        }

        private void UpdateUi(string reqUrl, string reqResponse)
        {
            lblLastReqPath.Text = reqUrl;
            lblLastResponse.Text = reqResponse;
        }
    }
}
