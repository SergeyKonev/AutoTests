using NUnit.Allure.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestProject
{
    [AllureNUnit]
    public class Tests
    {
        public Tests()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
            
        private static IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();
        WebDriverWait wait = new WebDriverWait(driver, timeout: TimeSpan.FromSeconds(5));
        private readonly By _textArea = By.XPath("/html/body[1]/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[2]/div[3]/c-wiz[1]/span/span/div/textarea");
        private readonly By _allLanguagesToTranlateButton = By.XPath("/html/body/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[1]/c-wiz/div[1]/c-wiz/div[5]/button/div[3]");
        private readonly By _translateToEnglishButton = By.XPath("//*[@id=\"yDmH0d\"]/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[1]/c-wiz/div[2]/c-wiz/div[2]/div/div[3]/div/div[2]/div[6]");
        private readonly By _translatedField = By.XPath("//span[@class='ryNqvb']");
        private readonly string _login = "TestUser172898";
        private readonly string _password = "6RRZKx4zowRs";
        private readonly By _loginButton = By.XPath("//span[text()='Войти']");
        private readonly By _loginTextArea = By.XPath("/html/body/div[3]/div[3]/div[4]/div[1]/div[3]/form/div/div[1]/div/input");
        private readonly By _passwordTextArea = By.XPath("/html/body/div[3]/div[3]/div[4]/div[1]/div[3]/form/div/div[2]/div/input");
        private readonly By _loginSubmitButton = By.XPath("/html/body/div[3]/div[3]/div[4]/div[1]/div[3]/form/div/div[4]/div/button");
        private readonly By _logoutButton = By.XPath("/html/body/div[4]/div[1]/nav/div/ul/li[10]/a/span");

        
        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://translate.google.com/?hl=ru");
            driver.FindElement(_textArea).SendKeys("Тестирование переводчика");
            driver.FindElement(_allLanguagesToTranlateButton).Click();
            wait.Until(driver => (driver.FindElement(_translateToEnglishButton).Text == "английский"));
            driver.FindElement(_translateToEnglishButton).Click();
            wait.Until(driver => (driver.FindElement(_translatedField).Text == "Translator testing"));
        }

        
        [Test]
        public void Test2()
        {
            driver.Navigate().GoToUrl("https://ru.wikipedia.org/");
            driver.FindElement(_loginButton).Click();
            driver.FindElement(_loginTextArea).SendKeys(_login);
            driver.FindElement(_passwordTextArea).SendKeys(_password);
            driver.FindElement(_loginSubmitButton).Click();
            var logoutButton = driver.FindElement(_logoutButton);
            Assert.AreEqual("Выйти", logoutButton.Text);
        }


        [Test]
        public void Test3()
        {
            driver.FindElement(_logoutButton).Click();
            var loginButton = driver.FindElement(_loginButton);
            Assert.AreEqual("Войти", loginButton.Text);
            driver.Quit();
        }

    }
}