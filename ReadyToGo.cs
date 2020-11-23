using System;
using System.Collections.Generic;
using System.Text;

namespace HLesson_AsyncTaskGetReady
{
    public static class ReadyToGo
    {
        public static bool Ready { get; set; } = false;
        public static int TargetPassengerCount { get; set; }
        public static int MorningPassengerCount { get; set; }
        public static DateTime StartDateTime { get; set; }
        public static DateTime EndDateTime { get; set; }

        public static void ArePassengersReadyToGoYet()
        {
            if (TargetPassengerCount == MorningPassengerCount)
            {
                Console.Write("\n"); 
                Console.WriteLine("All passengers are accounted for and ready to go. \n");
                Ready = true;
            }
            else
            {
                // Console.WriteLine("Passengers are not ready.");
                Ready = false;
            }

            GetLeavingStatus();

        }

        public static void GetLeavingStatus()
        {
            if (Ready == true)
            {
                EndDateTime = DateTime.Now;

                System.TimeSpan diff = EndDateTime.Subtract(StartDateTime);
                Console.WriteLine($"It took {ReformatDateTimeSpan(diff)} for them to get ready. \n");
                Console.WriteLine($"They are ready to go at {EndDateTime}.");
            }
        }

        public static string ReformatDateTimeSpan(System.TimeSpan diff) 
        {

            StringBuilder objStringBuilder = new StringBuilder();

            string ddText = string.Empty;
            string hhText = string.Empty;
            string mmText = string.Empty;
            string ssText = string.Empty;
            string msText = string.Empty;

            if (diff.Days > 0)
            {

                ddText = $"{diff.Days} days";
                hhText = $", {diff.Hours} hours";
                mmText = $", {diff.Minutes} mins";
                ssText = $", {diff.Seconds} secs";
                msText = $" and {diff.Milliseconds} ms";

            }
            else if (diff.Hours > 0)
            {

                hhText = $"{diff.Hours} hours";
                mmText = $", {diff.Minutes} mins";
                ssText = $", {diff.Seconds} secs";
                msText = $" and {diff.Milliseconds} ms";

            }
            else if (diff.Minutes > 0)
            {

                mmText = $"{diff.Minutes} mins";
                ssText = $", {diff.Seconds} secs";
                msText = $" and {diff.Milliseconds} ms";

            }
            else if (diff.Seconds > 0)
            {

                ssText = $"{diff.Seconds} secs";
                msText = $" and {diff.Milliseconds} ms";

            }
            else if (diff.Milliseconds > 0)
            {

                msText = $"{diff.Milliseconds} ms";

            }

            objStringBuilder.Append(ddText)
                              .Append(hhText)
                              .Append(mmText)
                              .Append(ssText)
                              .Append(msText);

            return objStringBuilder.ToString();

        }


    }
}

