using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace TestProject1_Nunit
{
    [TestFixture]
    public class Tests
    {

        public IWebDriver driver;
        private ExtentReports _extent;
        private ExtentHtmlReporter _htmlReporter;

        private ExtentTest test;

        [OneTimeSetUp]
        public void Setup()
        {
            // Inicializar ExtentReports
            _extent = new ExtentReports();

            // Configurar ExtentHtmlReporter
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string solutionPath = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\" + @"Reports/Report.html"));
            _htmlReporter = new ExtentHtmlReporter(solutionPath);

            // Adjuntar el reporter a ExtentReports
            _extent.AttachReporter(_htmlReporter);
        }

        [SetUp]
        public void BeforeTest()
        {
            driver = new ChromeDriver(@"C:\Program Files\Google\Chrome\Application\chromedriver.exe");
            test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void TestAddElement()
        {
            test.Log(Status.Info, "Inicio el test de el regis   tro.");

            driver.Navigate().GoToUrl("https://naughty-euclid-f5b756.netlify.app/");
            driver.Manage().Window.Size = new System.Drawing.Size(1552, 880);
            driver.FindElement(By.CssSelector("img")).Click();
            driver.FindElement(By.CssSelector("input:nth-child(2)")).SendKeys("rony");
            driver.FindElement(By.CssSelector("input:nth-child(3)")).SendKeys("rony");
            driver.FindElement(By.CssSelector("input:nth-child(4)")).SendKeys("12");
            driver.FindElement(By.CssSelector(".btn-1")).Click();
            driver.FindElement(By.CssSelector(".btn-2")).Click();

            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string imgPath = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\" + @"Reports/" + test.Model.Name + ".png"));
            screenshot.SaveAsFile(imgPath, ScreenshotImageFormat.Png);
            test.AddScreenCaptureFromPath(imgPath);
            test.Log(Status.Pass, "Se completó el test de el registro");

            driver.Close();
        }

        [Test]
        public void TestEditElement()
        {
            test.Log(Status.Pass, "Inicio de pruaba para editar elemento.");

            driver.Navigate().GoToUrl("https://naughty-euclid-f5b756.netlify.app/");
            driver.Manage().Window.Size = new System.Drawing.Size(1054, 848);
            Thread.Sleep(400);
            driver.FindElement(By.CssSelector(".btn-edit")).Click();
            driver.FindElement(By.CssSelector("input:nth-child(4)")).Click();
            driver.FindElement(By.CssSelector("input:nth-child(4)")).SendKeys("126");
            driver.FindElement(By.CssSelector(".btn-1")).Click();

            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string imgPath = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\" + @"Reports/" + test.Model.Name + ".png"));
            screenshot.SaveAsFile(imgPath, ScreenshotImageFormat.Png);
            test.AddScreenCaptureFromPath(imgPath);
            test.Log(Status.Pass, "Final de pruaba para editar elemento.");

            driver.Close();
        }

        [Test]
        public void TestDeleteElement()
        {
            test.Log(Status.Info, "inicio de pruaba para elimnar elemento.");

            driver.Navigate().GoToUrl("https://naughty-euclid-f5b756.netlify.app/");
            driver.Manage().Window.Size = new System.Drawing.Size(1054, 848);
            Thread.Sleep(400);
            driver.FindElement(By.CssSelector(".btn-delete")).Click();

            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string imgPath = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\" + @"Reports/" + test.Model.Name + ".png"));
            screenshot.SaveAsFile(imgPath, ScreenshotImageFormat.Png);
            test.AddScreenCaptureFromPath(imgPath);
            test.Log(Status.Pass, "Final de pruaba para eliminar elemento.");

            driver.Close();
        }

        [OneTimeTearDown]
        public void AfterTests()
        {
            _extent.Flush();
        }

    }
}