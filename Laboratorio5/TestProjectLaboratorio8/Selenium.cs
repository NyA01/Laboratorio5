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
            string URL = "https://localhost:44336/Pais";
            driver.Manage().Window.Maximize();

            //Act: se pone la url indicada
            driver.Url = URL;
            //click en bot�n de crear pa�s
            driver.FindElement(By.Name("Crear pais")).Click();
            //se llena el formulario de crear pa�s
            driver.FindElement(By.Name("Nombre del pais")).SendKeys("Alemania");
            driver.FindElement(By.Name("Contienente")).SendKeys("Europa");
            driver.FindElement(By.Name("Idioma")).SendKeys("Aleman");
            //se env�a el formulario
            driver.FindElement(By.Name("Crear")).Click();
            mensajeCrear = driver.FindElement(By.ClassName("alert-success"));

            //Assert: comprobar que el pa�s se cre� exitosamente 
            Assert.IsNotNull(mensajeCrear);
        }

    }
}