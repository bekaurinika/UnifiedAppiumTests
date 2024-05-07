using OpenQA.Selenium;

namespace UnifiedAppiumTests.Avatrade.Pages.Desktop;

public abstract class BasePage
{
    protected IWebDriver Driver;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
    }

    public void NavigateTo(string url)
    {
        Driver.Navigate().GoToUrl(url);
    }
}