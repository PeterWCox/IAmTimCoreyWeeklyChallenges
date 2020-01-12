using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ReadAppSettings();
            //ReadConnectionStringsToConsole();
                     
            WriteAppSetting("Peter", "Cox");
            ReadAppSettings();
        }

        static void ReadAppSettings()
        {
            var appSettings = ConfigurationManager.AppSettings;

            foreach (var key in appSettings.AllKeys)
            {
                Console.WriteLine($"Key: {key} Value: {appSettings[key]}");
            }
        }

        static void ReadConnectionStringsToConsole()
        {
            var connectionStrings = ConfigurationManager.ConnectionStrings;

            foreach (ConnectionStringSettings cnn in connectionStrings)
            {
                Console.WriteLine($"Name: {cnn.Name} Value: {cnn.ConnectionString}");
                Console.WriteLine();
            }            
        }

        static void WriteAppSetting(string key, string value)
        {
            var appConfigFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var appSettings = appConfigFile.AppSettings.Settings;

            if (appSettings[key] == null)
            {
                appSettings.Add(key, value);
            }
            else
            {
                appSettings[key].Value = value;
            }
            
            appConfigFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(appConfigFile.AppSettings.SectionInformation.Name);
        }


    }
}

