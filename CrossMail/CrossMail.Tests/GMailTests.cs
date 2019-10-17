using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using Xunit;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CrossMail.Tests
{
    public class GMailTests: IDisposable
    {
        IWebDriver _browserDriver;
        

        public GMailTests()
        {
            _browserDriver = new ChromeDriver("./");
           
        }

        public void Dispose()
        {
            _browserDriver.Quit();
        }

        private const string SignInButtonCssLocator = "a.login";
        private const string RegistrationPageTitleCssLocator = "head title";
        private const string RegistrationgEmailTextBoxCssLocator = "input#email_create";
        private const string CreateAccountButtonCssLocator = "button#SubmitCreate";
        private const string PersonalInformationTitleCssLocator = "div.account_creation h3.page-subheading";
        private const string MaleGenderRadioButtonCssLocator = "input#id_gender1";
        private const string FemaleGenderRadioButtonCssLocator = "input#id_gender2";
        private const string FirstNameTextBoxCssLocator = "input#customer_firstname";
        private const string LastNameTextBoxCssLocator = "input#customer_lastname";
        private const string EmailTextBoxCssLocator = "input#email";
        private const string PasswordTextBoxCssLocator = "input#passwd";
        private const string AddressFirstNameTextBoxCssLocator = "input#firstname";
        private const string AddressLastNameTextBoxCssLocator = "input#lastname";
        private const string AddressTextBoxCssLocator = "input#address1";
        private const string CityTextboxCssLocator = "input#city";
        private const string StateDropDownCssLocator = "select#id_state";
        private const string ZipPostalCodeCssLocator = "input#postcode";
        private const string MobilePhoneTextBoxCssLocator = "input#phone_mobile";
        private const string AliasEmailTextBoxCssLocator = "input#alias";
        private const string RegisterButtonCssLocator = "button#submitAccount";
        private const string BackHomeButtonXPath = "//a[@title='Home']";
        private const string DressCategoryXPath = "//a[@title='Dresses']";
        private const string TshirtsCategoryXPath = "//a[@title='T-shirts']";
        private const string ItemXPath = "//a[@title='Printed Dress']";
        private const string Item2CssLocator = "a.product_img_link";
        private const string ItemAddToCartButtonXPath = "//p[@id='add_to_cart']//span[text()='Add to cart']";
        private const string ContinueShoppingButtonXPath = "//span[@title='Continue shopping']";
        private const string ProceedToCheckOutButtonCssLocator = "div.button-container >a.btn";
        private const string AgreeCheckBoxCssLocator = "input#cgv";
        private const string ProcessCarrierName = "processCarrier";
        private const string PayByChequeButtonXPath = "//a[@title='Pay by check.']";
        private const string OrderConfirmation = "p#cart_navigation button";
        private const string ProceedToCheckOutSummaryButtonCssLocator = "p.cart_navigation a.btn";
        private const string ProceedToCheckOutAddressButtonName = "processAddress";
        [Fact]
        public void Should_Order_Items()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            _browserDriver.Navigate().GoToUrl("http://automationpractice.com");
            _browserDriver.Manage().Window.Maximize();
            var SignInButton = _browserDriver.FindElement(By.CssSelector(SignInButtonCssLocator));
            SignInButton.Click();
            //Login Page Validation
            _browserDriver.FindElement(By.CssSelector(RegistrationPageTitleCssLocator)).Text.Equals("Login - My Store");
            _browserDriver.FindElement(By.CssSelector(RegistrationgEmailTextBoxCssLocator))
                .SendKeys(finalString + "@gmail.com");
            _browserDriver.FindElement(By.CssSelector(CreateAccountButtonCssLocator)).Click();
            //Registration Page Validation
            WebDriverWait wait = new WebDriverWait(_browserDriver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(PersonalInformationTitleCssLocator)));
            //_browserDriver.FindElements(By.CssSelector(PersonalInformationTitleCssLocator))[0].Text.Equals("Your personal information");
            //Entering Details
            _browserDriver.FindElement(By.CssSelector(MaleGenderRadioButtonCssLocator)).Click();
            _browserDriver.FindElement(By.CssSelector(FirstNameTextBoxCssLocator)).SendKeys("Pranish");
            _browserDriver.FindElement(By.CssSelector(LastNameTextBoxCssLocator)).SendKeys("Bhagat");
            _browserDriver.FindElement(By.CssSelector(PasswordTextBoxCssLocator)).SendKeys("123456");
            _browserDriver.FindElement(By.CssSelector(AddressFirstNameTextBoxCssLocator)).SendKeys("Pranish");
            _browserDriver.FindElement(By.CssSelector(AddressLastNameTextBoxCssLocator)).SendKeys("Bhagat");
            _browserDriver.FindElement(By.CssSelector(AddressTextBoxCssLocator)).SendKeys("Pulchowk");
            _browserDriver.FindElement(By.CssSelector(CityTextboxCssLocator)).SendKeys("Kathmandu");
            var State = new SelectElement(_browserDriver.FindElement(By.CssSelector(StateDropDownCssLocator)));
            State.SelectByText("California");
            _browserDriver.FindElement(By.CssSelector(ZipPostalCodeCssLocator)).SendKeys("44640");
            _browserDriver.FindElement(By.CssSelector(MobilePhoneTextBoxCssLocator)).SendKeys("9857023452");
            _browserDriver.FindElement(By.CssSelector(AliasEmailTextBoxCssLocator)).Clear();
            _browserDriver.FindElement(By.CssSelector(AliasEmailTextBoxCssLocator)).SendKeys("prainshbhagat1@gmail.com");
            _browserDriver.FindElement(By.CssSelector(RegisterButtonCssLocator)).Click();

            //Verifying if the Back Home Button is Present
            IsElementPresentByXpath(BackHomeButtonXPath).Equals(true);
            _browserDriver.FindElement(By.XPath(BackHomeButtonXPath)).Click();

            //Selecting Dress Category
            _browserDriver.FindElements(By.XPath(DressCategoryXPath))[1].Click();
            //Thread.Sleep(1000);
            var item = _browserDriver.FindElements(By.XPath(ItemXPath))[0];
            Actions builder = new Actions(_browserDriver);
            builder.MoveToElement(item).Click()
                .Build().Perform();
            _browserDriver.SwitchTo().Frame(_browserDriver.FindElement(By.TagName("iframe")));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(ItemAddToCartButtonXPath)));
            _browserDriver.FindElement(By.XPath(ItemAddToCartButtonXPath)).Click();

            //Continue Shopping
            wait.Until(ExpectedConditions.ElementExists(By.XPath(ContinueShoppingButtonXPath)));
            _browserDriver.FindElement(By.XPath(ContinueShoppingButtonXPath)).Click();

            //Select Tshirts Category
            _browserDriver.FindElements(By.XPath(TshirtsCategoryXPath))[1].Click();
             _browserDriver.FindElement(By.CssSelector(Item2CssLocator)).Click();
            //builder.MoveToElement(item1)
              //  .Click().Build().Perform();
            _browserDriver.SwitchTo().Frame(_browserDriver.FindElement(By.TagName("iframe")));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(ItemAddToCartButtonXPath)));
            _browserDriver.FindElement(By.XPath(ItemAddToCartButtonXPath)).Click();
            //_browserDriver.SwitchTo().Window(_browserDriver.CurrentWindowHandle);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(ProceedToCheckOutButtonCssLocator)));
            _browserDriver.FindElement(By.CssSelector(ProceedToCheckOutButtonCssLocator)).Click();

            _browserDriver.FindElements(By.CssSelector(ProceedToCheckOutSummaryButtonCssLocator))[0].Click();
            _browserDriver.FindElement(By.Name(ProceedToCheckOutAddressButtonName)).Click();
            _browserDriver.FindElement(By.CssSelector(AgreeCheckBoxCssLocator)).Click();
            _browserDriver.FindElement(By.Name(ProcessCarrierName)).Click();
            _browserDriver.FindElement(By.XPath(PayByChequeButtonXPath)).Click();
            _browserDriver.FindElement(By.CssSelector(OrderConfirmation)).Click();

            
            #region LocalMethods

            bool IsElementPresentByXpath(string xpathSelector)
            {
                try
                {
                    IWebElement element = _browserDriver.FindElement(By.XPath(xpathSelector));
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }

            #endregion
        }
    }
}
