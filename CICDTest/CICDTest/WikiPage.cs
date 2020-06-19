using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CICDTest.Helpers;
using CICDTest.Page_Objects;
using CICDTest.Types;
using System.Diagnostics;
using System.IO;
using AutoIt;

namespace CICDTest
{
    public partial class WikiPage : ProjectBase
    {
        //  private DriverContext driverContext;

        public WikiPage(DriverContext driverContext) : base(driverContext)
        {

        }

        private readonly ElementLocator
            googleSearch = new ElementLocator(Locator.Xpath, "//input[contains(@class,'gLFyf gsfi')]");
        //basicAuthLink = new ElementLocator(Locator.XPath, "//a[contains(text(),'Auth')]"),
        //dropdownPageByLinkTextLocator = new ElementLocator(Locator.LinkText, "Dropdown"),
        //partialLinkTextLocator = new ElementLocator(Locator.PartialLinkText, "Drag");

        private readonly By search = By.XPath("//input[contains(@class,'gLFyf gsfi')]");
        private readonly By searchBtn = By.Name("btnK");
        private readonly By WellsFargoLink = By.PartialLinkText("Wells Fargo - Wikipedia");


        public WikiPage OpenPage()
        {
            var url = BaseConfiguration.GetUrlValue;
            this.Driver.NavigateTo(new Uri(url));
            return this;
        }


        public WikiPage EnterSearchValue()
        {
            this.Driver.FindElement(search).SendKeys("WellsFargo");
            System.Threading.Thread.Sleep(2000);
           // this.Driver.FindElements(searchBtn)[0].Click();
            var projectDirectory = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;            
            AutoItX.Send("{ENTER}");
            return this;
        }

        public WikiPage SeachFOrWellFargoWIKILink()
        {
            System.Threading.Thread.Sleep(5000);
            this.Driver.FindElement(WellsFargoLink).Click();
            return this;
        }




    }
}
