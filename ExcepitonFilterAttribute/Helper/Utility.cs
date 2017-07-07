﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using ExcepitonFilterAttribute.Service;

namespace ExcepitonFilterAttribute.Helper
{
    public class Utility
    {
        public static void ReportError(Exception ex)
        {
            Thread reportThread = new Thread(() =>
            {
                try
                {
                    if (ex == null)
                        return;

                    HttpException httpEx = ex as HttpException;
                    if (httpEx != null && httpEx.GetHttpCode() == 404)
                        return;

                    // The remote server returned an error: (405) Method Not Allowed. (PROPFIND )
                    if (httpEx != null && httpEx.GetHttpCode() == 405)
                        return;

                    if (ex.GetType() == typeof(UnauthorizedAccessException))
                        return;

                    if (ex is ThreadAbortException)
                        return;

                    if (ex is HttpRequestValidationException)
                        return;

                    if (ex.GetType() == typeof(UnauthorizedAccessException))
                        return;

                    if (ex.GetType() == typeof(PathTooLongException))
                        return;

                    if (ex is ViewStateException)
                        return;

                    String errorMessage = ex.Message + "\n\n StackTrace:" + ex.StackTrace;

                    Exception innerEx = ex.InnerException;
                    while (innerEx != null)
                    {
                        errorMessage += "\n\n" + innerEx.Message + "\n\n StackTrace:" + innerEx.StackTrace;
                        innerEx = innerEx.InnerException;
                    }

                    try
                    {
                        errorMessage = "Server IP: " + HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"] + "\n\n" + errorMessage;
                    }
                    catch
                    {
                        // ignored
                    }

                    LogService logService = new LogService();
                    logService.Error(ex, errorMessage);
                }
                catch (Exception)
                {
                    // ignored
                }
            });

            reportThread.Start();
        }
    }
}