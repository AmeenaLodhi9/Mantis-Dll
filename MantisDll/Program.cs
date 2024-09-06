using System;
using Mantis.LVision.RFLogin;
using Mantis.LVision.Interfaces;
using Mantis.LVision.RFApi;

namespace MantisDll
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create RFForm instance
            RFForm frm = new RFForm();

            // Set up connection string and other properties
            frm.ConnectionString = "Data Source=DESKTOP-HSSFLUB\\SQLEXPRESS;Initial Catalog=mantisdb;User ID=sa;Password=sa1234;";
            frm.UserID = 1;
            frm.EmployeeID = 1;
            frm.LogisticSiteID = 2;
            frm.LanguageID = 1;
            frm.DataBaseType = 1;
            frm.ExecutablePath = ".";
            frm.ShowMaximized = true;
            frm.DatasetPath = @"C:\\Program Files\\LV3Plus";
            frm.DebugLevel = 1;
            frm.LogisticUnitID = 9;
            frm.Local = false;

            // Variables used in the GetUserInfo method
            int userID = frm.UserID;
            int employeeID = frm.EmployeeID;
            string defaultLogisticSiteCode = "HELLO"; // Default value
            int defaultLanguageID = -1;
            int defaultUnitID = -1;
            int defaultSiteID = -1;
            bool logErrorsLED = false;
            int userIdleTimeout = 0;

            // Surround the call to GetUserInfo with detailed logging
            try
            {
                

                bool isAuthenticated = CLogin.GetUserInfo(
                    frm,
                    "a", // username
                    "a", // password
                    ref userID,
                    ref employeeID,
                    ref defaultLogisticSiteCode,
                    UseLoginInfo: false,
                    ref defaultLanguageID,
                    ref defaultUnitID,
                    ref defaultSiteID,
                    ref logErrorsLED,
                    ref userIdleTimeout
                );
                Console.WriteLine(isAuthenticated);

                //if (isAuthenticated)
                //{
                //    Console.WriteLine("User authenticated successfully!");
                //    Console.WriteLine($"UserID: {userID}");
                //    Console.WriteLine($"EmployeeID: {employeeID}");
                //    Console.WriteLine($"Default Logistic Site Code: {defaultLogisticSiteCode}");
                //    Console.WriteLine($"Default Language ID: {defaultLanguageID}");
                //    Console.WriteLine($"Default Unit ID: {defaultUnitID}");
                //    Console.WriteLine($"Default Site ID: {defaultSiteID}");
                //    Console.WriteLine($"Log Errors LED: {logErrorsLED}");
                //    Console.WriteLine($"User Idle Timeout: {userIdleTimeout}");
                    
                //}
                Console.ReadKey();
                
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
            
        }
    }
}
