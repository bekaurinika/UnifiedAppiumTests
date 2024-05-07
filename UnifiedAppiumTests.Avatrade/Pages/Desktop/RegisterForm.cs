using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace UnifiedAppiumTests.Avatrade.Pages.Desktop;

public class RegisterForm : BasePage
{
    private WebDriverWait wait;

    public By EmailTitle = By.CssSelector("label[for='input-email']");
    public By EmailInput = By.CssSelector("input[type='email'][name='email']");
    public By PasswordTitle = By.CssSelector("label[for='input-password']");

    public By RegisterDetailsIframe = By.CssSelector("iframe[data-qa='iframe__container']");
    public By PasswordInput = By.Id("input-password");
    public By CreateAccountButton = By.Id("btn_ga_real_main menu_cfd");


    public By FirstNameField = By.CssSelector("input[type='text'][name='FirstName']");
    public By LastNameField = By.CssSelector("input[type='text'][name='LastName']");
    public By DateOfBirthDField = By.CssSelector("input[name='date-of-birth-day']");
    public By DateOfBirthMField = By.CssSelector("input[name='date-of-birth-month']");
    public By DateOfBirthYField = By.CssSelector("input[name='date-of-birth-year']");
    public By CountryInputField = By.CssSelector("input[type='text'][name='Country']");
    public By CountryDropdownItem = By.CssSelector("span.country-name");
    public By CityField = By.CssSelector("input[type='text'][name='City']");
    public By StreetNameField = By.CssSelector("input[type='text'][name='Street']");
    public By BuildingNumberField = By.CssSelector("input[type='text'][name='BuildingNumber']");
    public By ApartmentField = By.CssSelector("input[type='text'][name='Flat']");
    public By PostalCodeField = By.CssSelector("input[type='text'][name='ZipCode']");
    public By PhoneNumberField = By.CssSelector("input[type='tel'][name='Phone']");
    public By BaseCurrencyDropdownField = By.Id("question-25_189");
    public By BaseCurrencyDropdownItem = By.CssSelector("#list-189 div[role='option']");

    public By SubmitButton = By.CssSelector("button[type='submit']");


    public By OccupationField =
        By.XPath(
            "//label[contains(text(), 'What is your primary occupation?')]/following-sibling::div//div[contains(@class,'v-select__slot')]/div[contains(@class,'v-select__selections')]");

    public By EmploymentStatusField =
        By.XPath(
            "//label[contains(text(), 'Are you currently employed?')]/following-sibling::div//div[contains(@class,'v-select__selections')]");

    public By SourceOfFundsField =
        By.XPath(
            "//label[contains(text(), 'What is the source of the funds you intend to invest?')]/following-sibling::div//div[contains(@class,'v-select__selections')]");

    public By AnnualIncomeField =
        By.XPath(
            "//label[contains(text(), 'What is your estimated annual income?')]/following-sibling::div//div[contains(@class,'v-select__selections')]");

    public By SavingsInvestmentsField =
        By.XPath(
            "//label[contains(text(), 'What is the estimated value of your savings & investments?')]/following-sibling::div//div[contains(@class,'v-select__selections')]");

    public By FinancialRiskField =
        By.XPath(
            "//label[contains(text(), 'What level of financial risk are you comfortable with?')]/following-sibling::div//div[contains(@class,'v-select__selections')]");

    public By TermsToggle = By.XPath("//span[contains(text(), 'I have read, understood and accepted the')]");

    public By CloseButton = By.Id("typ-close-icon");
    public By AlmostThereMessage = By.XPath("//p[contains(text(), 'Almost There')]");

    public By ExperienceField =
        By.XPath(
            "//label[contains(text(), 'What was the extent of your trading experience over the last year?')]/following-sibling::div//div[contains(@class,'v-select__slot')]/div[contains(@class,'v-select__selections')]");

    public By EstimateValueField =
        By.XPath(
            "//label[contains(text(), 'What was the estimated value of those trades?')]/following-sibling::div//div[contains(@class,'v-select__slot')]/div[contains(@class,'v-select__selections')]");

    public By LeverageField =
        By.XPath(
            "//label[contains(text(), 'Which of the following statements can be applied to trading with leverage?')]/following-sibling::div//div[contains(@class,'v-select__slot')]/div[contains(@class,'v-select__selections')]");

    public By LeverageQuestionField =
        By.XPath(
            "//label[contains(text(), 'If you have 1000$ in your account and you are trading with 50:1 leverage, what is the maximum size position you can open?')]/following-sibling::div//div[contains(@class,'v-select__slot')]/div[contains(@class,'v-select__selections')]");

    public By ClosePositionField =
        By.XPath(
            "//label[contains(text(), 'My open position may close automatically when:')]/following-sibling::div//div[contains(@class,'v-select__slot')]/div[contains(@class,'v-select__selections')]");

    public By WhyTradeWithUsField =
        By.XPath(
            "//label[contains(text(), 'Which of the options below best describe your primary purpose of trading with us?')]/following-sibling::div//div[contains(@class,'v-select__slot')]/div[contains(@class,'v-select__selections')]");

    public By PreferencesCheckbox = By.Id("question-11_297");
    public By AdditionalFieldsCheckbox = By.XPath("//label[contains(text(), 'I agree')]");

    public RegisterForm(IWebDriver driver) : base(driver)
    {
        wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
    }


    public void FillValidEmailAndPassword(string emailText, string passwordText)
    {
        wait.Until(ExpectedConditions.ElementIsVisible(EmailInput));
        Driver.FindElement(EmailInput).SendKeys(emailText);
        Driver.FindElement(PasswordInput).SendKeys(passwordText);
        Driver.FindElement(CreateAccountButton).Click();
    }


    public void FillValidPersonalDetails(string firstName, string lastName, string dateOfBirthD, string dateOfBirthM,
        string dateOfBirthY, string country, string city, string streetName, string buildingNumber, string apartment,
        string postalCode, string phoneNumber, string baseCurrency)
    {
        wait.Until(ExpectedConditions.UrlContains("https://webtrader6.avatrade.com/trade/70411/EURUSD"));
        Driver.SwitchTo().Frame(Driver.FindElement(RegisterDetailsIframe));
        wait.Until(ExpectedConditions.ElementExists(FirstNameField));

        Driver.FindElement(FirstNameField).SendKeys(firstName);
        Driver.FindElement(LastNameField).SendKeys(lastName);
        Driver.FindElement(DateOfBirthDField).SendKeys(dateOfBirthD);
        Driver.FindElement(DateOfBirthMField).SendKeys(dateOfBirthM);
        Driver.FindElement(DateOfBirthYField).SendKeys(dateOfBirthY);
        Driver.FindElement(CountryInputField).SendKeys(country);
        Driver.FindElements(CountryDropdownItem)
            .FirstOrDefault(element => element.Text.Equals(country, StringComparison.OrdinalIgnoreCase)).Click();
        Driver.FindElement(CityField).SendKeys(city);
        Driver.FindElement(StreetNameField).SendKeys(streetName);
        Driver.FindElement(BuildingNumberField).SendKeys(buildingNumber);
        Driver.FindElement(ApartmentField).SendKeys(apartment);
        Driver.FindElement(PostalCodeField).SendKeys(postalCode);
        Driver.FindElement(PhoneNumberField).SendKeys(phoneNumber);
        // IWebElement Element = Driver.FindElement(BaseCurrencyDropdownField);
        // ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", Element);
        Driver.FindElement(SubmitButton).Click();
    }

    public void SelectDropdownOption(By dropdown, string item)
    {
        var dropdownElement = wait.Until(ExpectedConditions.ElementToBeClickable(dropdown));
        ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", dropdownElement);
        dropdownElement.Click();

        By optionSelector =
            By.XPath(
                $"//*[contains(@class, 'menuable__content__active')]//div[contains(@class, 'v-list-item__title') and text()='{item}']");
        var optionElement = wait.Until(ExpectedConditions.ElementIsVisible(optionSelector));
        ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", optionElement);
        optionElement.Click();
    }

    public void SelectValidOptions(string occupation, string employment, string source, string annualIncome,
        string savings, string financialRisk)
    {
        SelectDropdownOption(OccupationField, occupation);
        SelectDropdownOption(EmploymentStatusField, employment);
        SelectDropdownOption(SourceOfFundsField, source);
        SelectDropdownOption(AnnualIncomeField, annualIncome);
        SelectDropdownOption(SavingsInvestmentsField, savings);
        SelectDropdownOption(FinancialRiskField, financialRisk);
        wait.Until(ExpectedConditions.ElementToBeClickable(SubmitButton));
        Driver.FindElement(SubmitButton).Click();
    }

    public void AgreeToTerms()
    {
        var termsToggle = wait.Until(ExpectedConditions.ElementToBeClickable(TermsToggle));
        termsToggle.Click();
        Driver.FindElement(SubmitButton).Click();
    }

    public void WaitForMessageAndClose()
    {
        wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(AlmostThereMessage));
        Driver.FindElement(CloseButton).Click();
        Driver.SwitchTo().DefaultContent();
    }

    public string GetRegistrationConfirmation()
    {
        By allSetMessageSelector = By.CssSelector("div.tour-popup_title__BY4W2[data-qa='tour-popup__start-title']");
        IWebElement allSetMessageElement =
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(allSetMessageSelector)).FirstOrDefault();

        return allSetMessageElement.Text;
    }

    public void FillPreferences(string buttonText, string experience, string estimateValue, string leverageValue,
        string leverageQuestion, string closePosition, string whyTradeWithUs)
    {
        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(), 'Yes')]")));
        Driver.FindElement(By.XPath("//span[contains(text(), 'Yes')]")).Click();
        SelectDropdownOption(ExperienceField, experience);
        SelectDropdownOption(EstimateValueField, estimateValue);
        SelectDropdownOption(LeverageField, leverageValue);
        SelectDropdownOption(LeverageQuestionField, leverageQuestion);
        SelectDropdownOption(ClosePositionField, closePosition);
        SelectDropdownOption(WhyTradeWithUsField, whyTradeWithUs);
        Driver.FindElement(PreferencesCheckbox).Click();
        Driver.FindElement(SubmitButton).Click();
    }

    public void AgreeToAdditinalFields()
    {
        wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(AdditionalFieldsCheckbox));
        wait.Until(ExpectedConditions.ElementToBeClickable(AdditionalFieldsCheckbox));
        Driver.FindElement(AdditionalFieldsCheckbox).Click();
        Driver.FindElement(SubmitButton).Click();
    }
}