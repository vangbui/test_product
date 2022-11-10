using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using AutoItX3Lib;
using OpenQA.Selenium.Interactions;

namespace Test_product
{

    [TestFixture]
    class AddProduct
    {
        private IWebDriver driver;
        private string baseURL;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "http://nhom7.epizy.com/nhom7/quan_tri/?menu=ql_sanpham&i=1";
        }
        [TearDown]
        public void TeardownTest()
        {
            driver.Quit();
        }
        [Test]
        public void TCAddValid()
        {
            AutoItX3 autoIt = new AutoItX3();

            driver.Navigate().GoToUrl(baseURL);
            Thread.Sleep(1000);
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div/div[2]/div/form/div[1]/input")).SendKeys("admin2");
            driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div/div[2]/div/form/div[2]/input")).SendKeys("123");
            driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div/div[2]/div/form/input")).Click();
            Thread.Sleep(1000);
            autoIt.Send("{Enter}");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("/html/body/div/div[1]/nav/div[1]/div/a[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div/div[1]/nav/div[1]/div/div[1]/nav/a[3]")).Click();
            driver.FindElement(By.XPath("/html/body/div/div[2]/main/div/div/div/div/div/form/table[1]/tbody/tr[2]/td[1]/input")).Click();
            driver.FindElement(By.XPath("/html/body/div/div[2]/main/div/div/div/div/div/form/table[1]/tbody/tr[2]/td[1]/input")).SendKeys("quan kaki");
            driver.FindElement(By.XPath("/html/body/div/div[2]/main/div/div/div/div/div/form/table[1]/tbody/tr[2]/td[2]/input")).SendKeys("500000");
            driver.FindElement(By.XPath("/html/body/div/div[2]/main/div/div/div/div/div/form/table[1]/tbody/tr[2]/td[3]/input")).SendKeys("10");
            driver.FindElement(By.XPath("/html/body/div/div[2]/main/div/div/div/div/div/form/table[1]/tbody/tr[2]/td[4]/select")).SendKeys("Quần lửng");

            IWebElement image1, image2, image3, image4;

            image1 = driver.FindElement(By.XPath("/html/body/div/div[2]/main/div/div/div/div/div/form/table[2]/tbody/tr[2]/td[2]/input[1]"));
            image2 = driver.FindElement(By.XPath("/html/body/div/div[2]/main/div/div/div/div/div/form/table[2]/tbody/tr[2]/td[2]/input[2]"));
            image3 = driver.FindElement(By.XPath("/html/body/div/div[2]/main/div/div/div/div/div/form/table[2]/tbody/tr[2]/td[2]/input[3]"));
            image4 = driver.FindElement(By.XPath("/html/body/div/div[2]/main/div/div/div/div/div/form/table[2]/tbody/tr[2]/td[2]/input[4]"));


            Actions edit = new Actions(driver);
            edit.MoveToElement(image1).Click().Build().Perform();

            
            autoIt.WinActivate("chon tep");
            Thread.Sleep(1000);
            autoIt.Send(@"C:\Users\Admin\OneDrive\Hình ảnh\Saved Pictures\img1.jpg");
            Thread.Sleep(1000);
            autoIt.Send("{Enter}");
            Thread.Sleep(1000);

            Actions edit1 = new Actions(driver);
            edit.MoveToElement(image1).Click().Build().Perform();


            autoIt.WinActivate("chon tep 2");
            Thread.Sleep(1000);
            autoIt.Send(@"C:\Users\Admin\OneDrive\Hình ảnh\Saved Pictures\img2.jpg");
            Thread.Sleep(1000);
            autoIt.Send("{Enter}");
            Thread.Sleep(1000);

            Actions edit2 = new Actions(driver);
            edit.MoveToElement(image1).Click().Build().Perform();


            autoIt.WinActivate("chon tep 3");
            Thread.Sleep(1000);
            autoIt.Send(@"C:\Users\Admin\OneDrive\Hình ảnh\Saved Pictures\img3.jpg");
            Thread.Sleep(1000);
            autoIt.Send("{Enter}");
            Thread.Sleep(1000);

            Actions edit3 = new Actions(driver);
            edit.MoveToElement(image1).Click().Build().Perform();


            autoIt.WinActivate("chon tep");
            Thread.Sleep(1000);
            autoIt.Send(@"C:\Users\Admin\OneDrive\Hình ảnh\Saved Pictures\img4.jpg");
            Thread.Sleep(1000);
            autoIt.Send("{Enter}");
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("/html/body/div/div[2]/main/div/div/div/div/div/form/table[3]/tbody/tr[1]/td[2]/input")).SendKeys("thoáng");


            driver.FindElement(By.XPath("/html/body/div/div[2]/main/div/div/div/div/div/form/input")).Click();
        }

        [TestCase("", "400000", "10", "quan kaki", "thoáng", "Product name is not nulll")]
        [TestCase("ao thun", "", "10", "quan kaki", "thoáng", "product price is not nulll")]
        [TestCase("ao thun", "400000", "", "quan kaki", "thoáng", "Product quantity is not nulll")]
        [TestCase("ao thun", "400000", "10", "", "thoáng", "Product type is not nulll")]
        [TestCase("ao thun", "400000", "10", "quan kaki", "", "Product describe is not nulll")]

        public void TCAddInvalid(string nameProduct, string price, string amount, string type, string decription, string expected)
        {
            AutoItX3 autoIt = new AutoItX3();

            driver.Navigate().GoToUrl(baseURL);
            Thread.Sleep(1000);
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div/div[2]/div/form/div[1]/input")).SendKeys("admin2");
            driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div/div[2]/div/form/div[2]/input")).SendKeys("123");
            driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div/div[2]/div/form/input")).Click();
            Thread.Sleep(1000);
            autoIt.Send("{Enter}");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("/html/body/div/div[1]/nav/div[1]/div/a[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div/div[1]/nav/div[1]/div/div[1]/nav/a[3]")).Click();
            driver.FindElement(By.XPath("/html/body/div/div[2]/main/div/div/div/div/div/form/table[1]/tbody/tr[2]/td[1]/input")).Click();
            driver.FindElement(By.XPath("/html/body/div/div[2]/main/div/div/div/div/div/form/table[1]/tbody/tr[2]/td[1]/input")).SendKeys(nameProduct);
            driver.FindElement(By.XPath("/html/body/div/div[2]/main/div/div/div/div/div/form/table[1]/tbody/tr[2]/td[2]/input")).SendKeys(price);
            driver.FindElement(By.XPath("/html/body/div/div[2]/main/div/div/div/div/div/form/table[1]/tbody/tr[2]/td[3]/input")).SendKeys(amount);
            driver.FindElement(By.XPath("/html/body/div/div[2]/main/div/div/div/div/div/form/table[1]/tbody/tr[2]/td[4]/select")).SendKeys(type);

            IWebElement image1, image2, image3, image4;

            image1 = driver.FindElement(By.XPath("/html/body/div/div[2]/main/div/div/div/div/div/form/table[2]/tbody/tr[2]/td[2]/input[1]"));
            image2 = driver.FindElement(By.XPath("/html/body/div/div[2]/main/div/div/div/div/div/form/table[2]/tbody/tr[2]/td[2]/input[2]"));
            image3 = driver.FindElement(By.XPath("/html/body/div/div[2]/main/div/div/div/div/div/form/table[2]/tbody/tr[2]/td[2]/input[3]"));
            image4 = driver.FindElement(By.XPath("/html/body/div/div[2]/main/div/div/div/div/div/form/table[2]/tbody/tr[2]/td[2]/input[4]"));


            Actions edit = new Actions(driver);
            edit.MoveToElement(image1).Click().Build().Perform();


            autoIt.WinActivate("chon tep");
            Thread.Sleep(1000);
            autoIt.Send(@"C:\Users\Admin\OneDrive\Hình ảnh\Saved Pictures\img1.jpg");
            Thread.Sleep(1000);
            autoIt.Send("{Enter}");
            Thread.Sleep(1000);

            Actions edit1 = new Actions(driver);
            edit.MoveToElement(image2).Click().Build().Perform();


            autoIt.WinActivate("chon tep 2");
            Thread.Sleep(1000);
            autoIt.Send(@"C:\Users\Admin\OneDrive\Hình ảnh\Saved Pictures\img2.jpg");
            Thread.Sleep(1000);
            autoIt.Send("{Enter}");
            Thread.Sleep(1000);

            Actions edit2 = new Actions(driver);
            edit.MoveToElement(image3).Click().Build().Perform();


            autoIt.WinActivate("chon tep 3");
            Thread.Sleep(1000);
            autoIt.Send(@"C:\Users\Admin\OneDrive\Hình ảnh\Saved Pictures\img3.jpg");
            Thread.Sleep(1000);
            autoIt.Send("{Enter}");
            Thread.Sleep(1000);

            Actions edit3 = new Actions(driver);
            edit.MoveToElement(image4).Click().Build().Perform();


            autoIt.WinActivate("chon tep");
            Thread.Sleep(1000);
            autoIt.Send(@"C:\Users\Admin\OneDrive\Hình ảnh\Saved Pictures\img4.jpg");
            Thread.Sleep(1000);
            autoIt.Send("{Enter}");
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("/html/body/div/div[2]/main/div/div/div/div/div/form/table[3]/tbody/tr[1]/td[2]/input")).SendKeys(decription);


            driver.FindElement(By.XPath("/html/body/div/div[2]/main/div/div/div/div/div/form/input")).Click();

        }

    }
}
