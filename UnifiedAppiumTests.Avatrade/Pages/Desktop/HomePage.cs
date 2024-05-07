using OpenQA.Selenium.Support.UI;
using UnifiedAppiumTests.Avatrade.Pages;

namespace UnifiedAppiumTests.Avatrade.Pages.Desktop;

using OpenQA.Selenium;

public class HomePage : BasePage
{
    private By RegisterNowButton = By.Id("btn_ga_real_header");
    private By RegisterFormContent = By.ClassName("registry-popup-content");
    private WebDriverWait wait;

    public HomePage(IWebDriver driver) : base(driver)
    {
        wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
    }

    // Method to click the 'Register Now' button
    public void OpenRegisterForm()
    {
        var registerButton = Driver.FindElement(RegisterNowButton);
        registerButton.Click();
        wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(RegisterFormContent));

    }
    
}