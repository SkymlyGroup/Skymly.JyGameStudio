using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skymly.JyGameStudio.BlazorApp.Shared
{
    public static class Constants
    {
        private static string ProjectNmae { get; set; } = "Skymly.JyGameStudio";

        private static string Host { get; set; } = "http://6game.xyz";

        private static int ApiPort { get; set; } = 12345;

        private static int BlazorAppPort { get; set; } = 12300;

        private static int SeqPort = 5341;

        public static string ApiUrl => $"{Host}:{ApiPort}/swagger/index.html";

        public static string ApiLogDashboardUrl => $"{Host}:{ApiPort}/LogDashboard";

        public static string BlazorAppLogDashboardUrl => $"{Host}:{BlazorAppPort}/LogDashboard";

        public static string BlazorAppUrl => $"{Host}:{BlazorAppPort}";

        public static string ProjectUrl => $"https://github.com/SkymlyGroup/{ProjectNmae}";

        public static string LogSeqUrl => $"{Host}:{SeqPort}";
    }
}
