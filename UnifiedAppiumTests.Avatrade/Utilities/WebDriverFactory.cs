using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Chrome;

namespace UnifiedAppiumTests.Avatrade.Utilities
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Enums;
    using OpenQA.Selenium.Appium.Service;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Chrome;


    public static class WebDriverFactory
    {
        public static IWebDriver CreateDesktopDriver()
        {
            var driverPath = Environment.GetEnvironmentVariable("CHROMEDRIVER_PATH");
            if (string.IsNullOrEmpty(driverPath))
            {
                throw new InvalidOperationException("CHROMEDRIVER_PATH not set in the environment variables.");
            }

            return new ChromeDriver(driverPath);
        }

        public static AndroidDriver<AndroidElement> CreateMobileDriver()
        {
            // Assuming you want to test an Android app
            var appiumOptions = new AppiumOptions();
            appiumOptions.PlatformName = "Android";
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Android Emulator");
            // You might also need to set the app path or other capabilities

            var appiumService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            appiumService.Start();

            return new AndroidDriver<AndroidElement>(appiumService, appiumOptions);
        }
    }
}