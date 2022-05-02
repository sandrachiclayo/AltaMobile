using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Interfaces;
using System;
using AltaMobile.BaseClass;
using OpenQA.Selenium.Support.PageObjects;
using AltaMobile.PObjects;

namespace AltaMobile
{
    public class Tests:BaseTest
    {
        
        //reporte
        ExtentReports extent = null;


        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\MidasM2022\Desktop\Mobile\AltaMobile\Report\Reporte.html");
            extent.AttachReporter(htmlReporter);
            
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }
        //

        [Test]
        public void Test1_CreacionCuenta()
        {
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("Passing Tests").Info("Test Started");
                // test.Log(Status.Info,"log de prueba");
                MainPage mainPage = new MainPage(_driver);
                mainPage.clickCrearCuenta();
                mainPage.EnterEmail("john.doe.2@gmail.com");
                mainPage.EnterPw("Abcd1234");
                mainPage.RepeatPw("Abcd1234");
                mainPage.ClickContinue();
                string textoprueba = mainPage.text_logueado.GetAttribute("value");
                test.Log(Status.Info,"El valor del texto es: "+textoprueba);
                //Assert.IsTrue(textoprueba== "Usuario logueado");
                

            }catch (NoSuchElementException ex)

            {
                test.Fail(ex.StackTrace);
            }


        }
    }
}