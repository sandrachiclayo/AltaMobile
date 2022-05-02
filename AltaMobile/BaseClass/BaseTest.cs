using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Interfaces;
using System;

namespace AltaMobile.BaseClass
{
    public class BaseTest
    {
        public AppiumDriver<AndroidElement> _driver { get; set; }


        [SetUp]
        public void Setup()
        {
            var appPath = @"C:\Users\MidasM2022\Desktop\Mobile\AltaMobile\apk\25398440-7d55-4525-9427-df5fa92e4c7b-646f3791af164a9aa8bff3d6b556e909 (1).apk";

            //Platform, Device, Application

            var driverOption = new AppiumOptions();
            driverOption.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOption.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Pixel 5 API 30");
            driverOption.AddAdditionalCapability(MobileCapabilityType.App, appPath);

            driverOption.AddAdditionalCapability("chromedriverExecutable", @"C:\Users\MidasM2022\Desktop\Mobile\AltaMobile\chromedriver\chromedriver.exe");


            _driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), driverOption);

            var context = ((IContextAware)_driver).Contexts;
            string webviewContext = null;
            for (var i = 0; i < context.Count; i++)
            {
                Console.WriteLine(context[i]);
                if (context[i].Contains("WEBVIEW"))
                {
                    webviewContext = context[i];
                    break;
                }
            }
            ((IContextAware)_driver).Context = webviewContext;


        }
    }
}
