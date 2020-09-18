### First of all you need to run follow commands: :point_down:

```bash
git clone https://github.com/1nk1/Gmail.git
cd Gmail
```

### Open in top toolbar Microsoft Visual Studio 2017/2019 (anyway version) 
- Tools -> NuGet Package Manager -> Package Manager Console

next step: :smile:


```Power Shell
PM> Update-Package -reinstall
```

### after this step you can run tests: :rocket:

![alt text](https://i.ibb.co/4PVj0cv/232.png)<br>


### Drag and Drop

```C#
[TestMethod]
public void DragAndDrop()
{
    this.driver.Navigate().GoToUrl(@"http://loopj.com/jquery-simple-slider/");
    IWebElement element = driver.FindElement(By.XPath("//*[@id='project']/p[1]/div/div[2]"));
    Actions move = new Actions(driver);
    move.DragAndDropToOffset(element, 30, 0).Perform();
}
```

### Upload a File

```C#
[TestMethod],  
public void DragAndDrop() 
{
  this.driver.Navigate().GoToUrl(@"http://loopj.com/jquery-simple-slider/"); 
  IWebElement element = driver.FindElement(By.XPath("//*[@id='project']/p[1]/div/div[2]")); 
  Actions move = new Actions(driver); 
  move.DragAndDropToOffset(element, 30, 0).Perform(); 
} 
```

### Handle JavaScript Pop-ups
```C#
[TestMethod]
public void JavaScripPopUps()
{
    this.driver.Navigate().GoToUrl(
    @"http://www.w3schools.com/js/tryit.asp?filename=tryjs_confirm");
    this.driver.SwitchTo().Frame("iframeResult");
    IWebElement button = driver.FindElement(By.XPath("/html/body/button"));
    button.Click();
    IAlert a = driver.SwitchTo().Alert();
    if (a.Text.Equals("Press a button!"))
    {
        a.Accept();
    }
    else
    {
        a.Dismiss();
    }
}
```

### Switch Between Browser Windows or Tabs

```C#
[TestMethod]
public void MovingBetweenTabs()
{
    this.driver.Navigate().GoToUrl(@"http://automatetheplanet.com/compelling-sunday-14022016/");
    driver.FindElement(By.LinkText("10 Advanced WebDriver Tips and Tricks Part 1")).Click();
    driver.FindElement(By.LinkText("The Ultimate Guide To Unit Testing in ASP.NET MVC")).Click();
    ReadOnlyCollection<String> windowHandles = driver.WindowHandles;
    String firstTab = windowHandles.First();
    String lastTab = windowHandles.Last();
    driver.SwitchTo().Window(lastTab);
    Assert.AreEqual<string>("The Ultimate Guide To Unit Testing in ASP.NET MVC", driver.Title);
    driver.SwitchTo().Window(firstTab);
    Assert.AreEqual<string>("Compelling Sunday – 19 Posts on Programming and Quality Assurance", driver.Title);
}
```

### Navigation History

```C#
[TestMethod]
public void NavigationHistory()
{
    this.driver.Navigate().GoToUrl(
        @"http://www.codeproject.com/Articles/1078541/Advanced-WebDriver-Tips-and-Tricks-Part");
    this.driver.Navigate().GoToUrl(
        @"http://www.codeproject.com/Articles/1017816/Speed-up-Selenium-Tests-through-RAM-Facts-and-Myth");
    driver.Navigate().Back();
    Assert.AreEqual<string>(
        "10 Advanced WebDriver Tips and Tricks - Part 1 - CodeProject", 
        driver.Title);
    driver.Navigate().Refresh();
    Assert.AreEqual<string>(
        "10 Advanced WebDriver Tips and Tricks - Part 1 - CodeProject", 
        driver.Title);
    driver.Navigate().Forward();
    Assert.AreEqual<string>(
        "Speed up Selenium Tests through RAM Facts and Myths - CodeProject", 
        driver.Title);
}
```

### Change User Agent

```C#
  FirefoxProfileManager profileManager = new FirefoxProfileManager();
  FirefoxProfile profile = new FirefoxProfile();
  profile.SetPreference(
  "general.useragent.override",
  "Mozilla/5.0 (BlackBerry; U; BlackBerry 9900; en) AppleWebKit/534.11+ (KHTML, like Gecko) Version/7.1.0.346 Mobile Safari/534.11+");
  this.driver = new FirefoxDriver(profile);
```

### Set HTTP Proxy for Browser

```C#
  FirefoxProfile firefoxProfile = new FirefoxProfile();
  firefoxProfile.SetPreference("network.proxy.type", 1);
  firefoxProfile.SetPreference("network.proxy.http", "myproxy.com");
  firefoxProfile.SetPreference("network.proxy.http_port", 3239);
  driver = new FirefoxDriver(firefoxProfile);
```

### Scroll Focus to Control

```C#
[TestMethod]
public void ScrollFocusToControl()
{
    this.driver.Navigate().GoToUrl(@"http://automatetheplanet.com/compelling-sunday-14022016/");
    IWebElement link = driver.FindElement(By.PartialLinkText("Previous post"));
    string jsToBeExecuted = string.Format("window.scroll(0, {0});", link.Location.Y);
    ((IJavaScriptExecutor)driver).ExecuteScript(jsToBeExecuted);
    link.Click();
    Assert.AreEqual<string>("10 Advanced WebDriver Tips and Tricks - Part 1", driver.Title);
}
```

### Focus on a Control

```C#
[TestMethod]
public void FocusOnControl()
{
    this.driver.Navigate().GoToUrl(
    @"http://automatetheplanet.com/compelling-sunday-14022016/");
    IWebElement link = driver.FindElement(By.PartialLinkText("Previous post"));
    // 9.1. Option 1.
    link.SendKeys(string.Empty);
    // 9.1. Option 2.
    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].focus();", link);
}
```

### Handle SSL Certificate Error

#### For Chrome browser
```C#
  DesiredCapabilities capability = DesiredCapabilities.Chrome();
  Environment.SetEnvironmentVariable("webdriver.chrome.driver", "C:PathToChromeDriver.exe");
  capability.SetCapability(CapabilityType.AcceptSslCertificates, true);
  driver = new RemoteWebDriver(capability);
```


#### For Firefox browser
```C#
  FirefoxProfile firefoxProfile = new FirefoxProfile();
  firefoxProfile.AcceptUntrustedCertificates = true;
  firefoxProfile.AssumeUntrustedCertificateIssuer = false;
  driver = new FirefoxDriver(firefoxProfile);
```

### Handle SSL Certificate Error InternetExplorerDriver


```C#
  DesiredCapabilities capability = DesiredCapabilities.InternetExplorer();
  Environment.SetEnvironmentVariable("webdriver.ie.driver", "C:PathToIEDriver.exe");
  capability.SetCapability(CapabilityType.AcceptSslCertificates, true);
  driver = new RemoteWebDriver(capability);
```
