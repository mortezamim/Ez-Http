# Ez-Http
lightweight, low-ceremony, framework for building HTTP based services on .NET Framework/Winform



How To Use.
```csharp
        SelfHostedWebServer selfHostedWebServer;
        private void btnStartServer_Click(object sender, EventArgs e)
        {
                GetRequestData reqDelegate = new GetRequestData(GetRequestData);
                selfHostedWebServer = new SelfHostedWebServer(new string[] { tbServerPath.Text }, reqDelegate);
        }
```

Create CallBackFunction
```csharp
        private void GetRequestData(HttpListenerContext ctx)
        {
            // Get Request BODY !
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
            
            
            
            // Generate response
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
            //lblLastReqPath.Text = reqUrl;
            //lblLastResponse.Text = reqResponse;
        }
```
