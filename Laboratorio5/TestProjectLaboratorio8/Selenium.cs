using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace TestProjectLaboratorio8
{
    public class Selenium
    {
        IWebDriver driver;
        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void PruebaIngresoListaPaises()
        {
            //Arrange: crea el driver de chrome
            string URL = "https://localhost:44336/";
            driver.Manage().Window.Maximize();

            //Act: se pone la url indicada
            driver.Url = URL;

            //Assert
            Assert.IsNotNull(driver);
        }

        [Test]
        public void PruebaCrearPais()
        {

            //Arrange: crea el driver de chrome
            IWebElement mensajeCrear;
            string URL = "https://localhost:44390/Paises";
            driver.Manage().Window.Maximize();
            //Act: se pone la url indicada
            driver.Url = URL;
            //click en botón de crear país
            driver.FindElement(By.ClassName("btn-success")).Click();
            //se llena el formulario de crear país
            driver.FindElement(By.Name("Nombre")).SendKeys("Alemania");
            driver.FindElement(By.Name("Continente")).SendKeys("Europa");
            driver.FindElement(By.Name("Idioma")).SendKeys("Aleman");
            //se envía el formulario
            driver.FindElement(By.ClassName("btn-success")).Click();
            mensajeCrear = driver.FindElement(By.ClassName("alert-success"));

            //Assert: comprobar que el país se creó exitosamente 
            Assert.IsNotNull(mensajeCrear);
        }

    }
}