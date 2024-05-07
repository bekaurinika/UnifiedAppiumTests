namespace UnifiedAppiumTests.Avatrade.Tests;

using Microsoft.VisualBasic.CompilerServices;
using OpenQA.Selenium.Support.UI;
using UnifiedAppiumTests.Avatrade.Pages.Desktop;
using NUnit.Framework;
using OpenQA.Selenium;
using UnifiedAppiumTests.Avatrade.Utilities;
using UnifiedAppiumTests.Avatrade.Pages;

[TestFixture]
public class RegisterFlowTest
{
    private IWebDriver driver;
    private HomePage homePage;
    private RegisterForm registerForm;


    [SetUp]
    public void Setup()
    {
        driver = WebDriverFactory.CreateDesktopDriver();
        driver.Manage().Window.Maximize();
        homePage = new HomePage(driver);
        homePage.NavigateTo("https://www.avatrade.com/");
        homePage.OpenRegisterForm();

        registerForm = new RegisterForm(driver);
    }

    [Test]
    public void RegisterUserAfghanistan()
    {
        registerForm.FillValidEmailAndPassword($"{Guid.NewGuid()}@gmail.com", "Password1@");

        registerForm.FillValidPersonalDetails(
            "John", "Doe", "01", "01", "1990", "Afghanistan", "New York",
            "123 Main St", "10", "Apt 101", "10001", "5551234", "USD");

        registerForm.SelectValidOptions("Accountancy", "Employed", "Employment", "More than 5 million",
            "More than 5 million", "More than 5 million");

        registerForm.AgreeToTerms();

        registerForm.WaitForMessageAndClose();

        Assert.That(registerForm.GetRegistrationConfirmation(), Is.EqualTo("You Are All Set!"));
    }

    [Test]
    public void RegisterUserFrance()
    {
        registerForm.FillValidEmailAndPassword($"{Guid.NewGuid()}@gmail.com", "Password1@");

        registerForm.FillValidPersonalDetails(
            "John", "Doe", "01", "01", "1990", "France", "New York",
            "123 Main St", "10", "Apt 101", "10001", "55512345", "USD");

        registerForm.SelectValidOptions("Accountancy", "Employed", "Employment", "More than 5 million",
            "More than 5 million", "More than 5 million");

        registerForm.FillPreferences("Yes", "0", "0", "None of the above", "$50,000",
            "The market is moving in favor of my position", "Speculation");

        registerForm.AgreeToTerms();
        
        registerForm.AgreeToAdditinalFields();

        registerForm.WaitForMessageAndClose();

        Assert.That(registerForm.GetRegistrationConfirmation(), Is.EqualTo("You Are All Set!"));
    }

    [TearDown]
    public void Teardown()
    {
        driver.Quit();
    }
}