﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace RevitGuide.Helpers
{
    public class UriHelper
    {
        public static Uri IconUri = new Uri("pack://application:,,,/RevitGuide;component/Resources/icon.png", UriKind.Absolute);
        public static Uri FirstPageUri = new Uri(App.DataFolderPath23 + "first_page.html");
        public static Uri InvalidPageUri = new Uri(App.DataFolderPath23 + "invalid_page.html");
        public static Uri LiveGuidePageUri = new Uri(App.DataFolderPath23 + "live_guide_page.html");
        

        public static Uri StringToUri(string uriString)
        {
            if (File.Exists(uriString))
            {
                return new Uri(uriString);
            }

            if (uriString == "")
            {
                return FirstPageUri;
            }
            else if (Uri.TryCreate(uriString, UriKind.Absolute, out Uri result))
            {
                return result;
            }
            else if (Uri.TryCreate("https://" + uriString, UriKind.Absolute, out result))
            {
                return result;
            }
            else if (Uri.TryCreate("http://" + uriString, UriKind.Absolute, out result))
            {
                return result;
            }
            else
            {
                return InvalidPageUri;
            }

        }

        public static void OpenGithubPage()
        {
            string url = "https://github.com/herzogdemeuron/revit-guide";
            System.Diagnostics.Process.Start(
                new System.Diagnostics.ProcessStartInfo("cmd", $"/c start {url.Replace("&", "^&")}") { CreateNoWindow = true }
                );
        }
    }
}
