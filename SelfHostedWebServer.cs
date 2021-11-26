﻿using System;
using System.Net;
using System.Text;
using System.Threading;

namespace ReverseProxy
{
    public delegate void GetRequestData(HttpListenerContext ctx);
    /// <summary>
    /// Self-hosted Web Server class
    /// https://codehosting.net/blog/BlogEngine/post/Simple-C-Web-Server
    /// </summary>
    public class SelfHostedWebServer
    {
        private readonly GetRequestData _reqDelegate;
        private readonly HttpListener _listener = new HttpListener();
        private string[] _pathsToListen;
        private bool LogOnEachRequest { get; set; } = false;

        /// <summary>
        /// Creates an HTTP Listener
        /// </summary>
        /// Array of paths to listen to (e.g. 'http://localhost:8081/test1/','http://localhost:8081/test2/')
        /// A callback method which will be called on each request and which allows you to create a corresponding response
        /// A callback method for providing logs
        public SelfHostedWebServer(string[] pathsToListen, GetRequestData reqDelegate = null)
        {
            if (reqDelegate != null)
            {
                _reqDelegate = reqDelegate;
            }
            _pathsToListen = pathsToListen;

            if (!HttpListener.IsSupported)
                throw new NotSupportedException(
                    "Needs Windows XP SP2, Server 2003 or later.");

            // URI prefixes are required, for example 
            // "http://localhost:8080/index/".
            if (pathsToListen == null || pathsToListen.Length == 0)
                throw new ArgumentException("pathsToListen are missing!");

            foreach (string s in pathsToListen)
            {
                string s1 = s;
                if (!s1.EndsWith("/"))
                    s1 = s1 + "/";
                _listener.Prefixes.Add(s1);
            }
        }

        /// <summary>
        /// Start listening
        /// </summary>
        public void Start()
        {
            _listener.Start();
            ThreadPool.QueueUserWorkItem(o =>
            {
                Console.WriteLine("SelfHostedWebServer - started. Will listen to " + String.Join(" , ", _pathsToListen));
                try
                {
                    while (_listener.IsListening)
                    {
                        ThreadPool.QueueUserWorkItem(c =>
                        {
                            var ctx = c as HttpListenerContext;
                            try
                            {
                                if (LogOnEachRequest)
                                    Console.WriteLine(String.Format("SelfHostedWebServer - request: {0} {1}", ctx.Request.HttpMethod, ctx.Request.Url));
                                _reqDelegate(ctx);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("SelfHostedWebServer exception: " + ex);
                            }
                            finally
                            {
                                // always close the stream
                                ctx.Response.OutputStream.Close();
                            }
                        }, _listener.GetContext());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SelfHostedWebServer exception: " + ex);
                }
            });
        }

        /// <summary>
        /// Stop listening
        /// </summary>
        public void Stop()
        {
            if (_listener.IsListening)
            {
                _listener.Stop();
                _listener.Close();
                Console.WriteLine("SelfHostedWebServer stopped.");
            }
        }

        /// <summary>
        /// Just a sample response callback which writes some text to the output stream.
        /// You should provide your own response callback method in the constructor.
        /// </summary>
        /// 
        //public static void BuiltInResponseCallback(HttpListenerContext ctx)
        //{
        //    // Is it request with Body?
        //    String body = "";
        //    if (ctx.Request.HasEntityBody)
        //    {
        //        using (System.IO.Stream bodyStream = ctx.Request.InputStream) // here we have data
        //        {
        //            using (System.IO.StreamReader reader = new System.IO.StreamReader(bodyStream, ctx.Request.ContentEncoding))
        //            {
        //                body = reader.ReadToEnd();
        //            }
        //        }
        //    }

        //    String responseString = string.Format("SelfHostedWebServer BuiltInResponseCallback<br>Time: {0}<br>Request:{1}<br>Body: {2}", DateTime.Now, ctx.Request.Url, body);
        //    byte[] buf = Encoding.UTF8.GetBytes(responseString);
        //    ctx.Response.ContentLength64 = buf.Length;
        //    ctx.Response.OutputStream.Write(buf, 0, buf.Length);
        //    ctx.Response.ContentType = "text/html";
        //}

    }
}