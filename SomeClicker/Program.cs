using NReco.PhantomJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SomeClicker
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            var driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            int index = 0;
            int willWait = 0;
            driver.Navigate().GoToUrl("http://www.quality.gskp.by/2");
            while (1==1)
            {
                try
                {
                    var element = driver.FindElement(By.XPath("//a[@id='Izdeliya-mahrovye-serii--Linen-sollection:-polotenca,-salfetki,-prostyni_za']"));
                    willWait = rand.Next(3000, 5000);
                    Console.WriteLine("\t Searching for the element [" + willWait + "]...");
                    System.Threading.Thread.Sleep(willWait);

                    willWait = rand.Next(3000, 5000);
                    Console.WriteLine("\tMoving to the button [" + willWait + "]...");
                    Actions scroll = new Actions(driver);
                    scroll.MoveToElement(element);
                    System.Threading.Thread.Sleep(willWait);

                    willWait = rand.Next(3000, 5000);
                    element.Click();
                    Console.WriteLine("\tClicking [" + willWait + "]...");

                    Console.WriteLine("I click " + index++ + " times!");
                    if (index == 1000000)
                    {
                        driver.Close();
                        Console.WriteLine("I cannot do it more!");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }

                    System.Threading.Thread.Sleep(willWait);
                    driver.Navigate().Refresh();
                    Console.WriteLine("\tRefreshing...");
                }
                catch(Exception)
                {
                    willWait = rand.Next(3000, 10000);
                    Console.WriteLine("!!Some exception [" + willWait + "]...");
                    driver.Quit();
                    driver = new ChromeDriver();
                    driver.Navigate().GoToUrl("http://www.quality.gskp.by/2");
                }
            }
        }
    }
}
