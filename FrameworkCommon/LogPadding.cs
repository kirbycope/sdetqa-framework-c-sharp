using System;

namespace FrameworkCommon
{
    public class LogPadding
    {
        public string Padding { get; set; }
        public string InfoPadding { get; set; }

        /// <summary>
        /// Adds padding to a log line if the method called is called by a framework method.
        /// </summary>
        /// <param name="reflectedType">The Type of the calling method.</param>
        public LogPadding(Type reflectedType)
        {
            this.Padding = "";
            this.InfoPadding = "    ";
            if (reflectedType.ToString().Contains("Framework"))
            {
                this.Padding = "    ";
                this.InfoPadding = "        ";
            }
        }
    }
}
