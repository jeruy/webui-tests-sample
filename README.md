[![Build Status](https://dev.azure.com/azrul-jeruy/jeruy-github/_apis/build/status/jeruy-github-CI?branchName=master)](https://dev.azure.com/azrul-jeruy/jeruy-github/_build/latest?definitionId=4&branchName=master)

# Introduction 
Hello World~! This repo is to host my sample code for my [gig](https://www.fiverr.com/share/oDZ7V) in fiverr. This sample test code is how I implement web UI test automation using Selenium, .Net Core and xUnit. Feel free to clone this repo and extend the tests for your own testing requirements.

There are 10 sample tests that I automate to test GitHub's registration/join page. The tests are :

 ![alt text](docs/img/TestExplorer.PNG)

The test methods are using extensible steps class and follow [fluent interface](https://martinfowler.com/bliki/FluentInterface.html) and applying [BDD](https://en.wikipedia.org/wiki/Behavior-driven_development) style [Given-When-Then](https://martinfowler.com/bliki/GivenWhenThen.html) convention to increase tests readability.  

The selenium pages in this project are following [Page Object Model](https://www.pluralsight.com/guides/getting-started-with-page-object-pattern-for-your-selenium-tests) design pattern : 

**Advantages of POM model:**

-   **Reusability:**  We can reuse the page class if required in different test cases which means we don’t need to write code for identifying the web elements and methods to interact with them for every test case.
-   **Maintainability:**  Test case and page class are different from each other which means we can easily update the code if any new web element is added or existing one updated.
-   **Readability:**  Page code is separated form test code which helps to improve code readability.

 ![alt text](docs/img/SampleTestMethods.PNG)
 
 More info in the [Wiki](https://github.com/jeruy/webui-tests-sample/wiki/Introduction)
 
 # Getting Started
 
 Since this sample tests code is written in .NET Core 2.1, you can just build and run the test using [.NET Core SDK](https://dotnet.microsoft.com/download). If you have Visual Studio installed in your machine, you can build and run the tests from  Visual Studio's Test Explorer  
 
 More info in the [Wiki](https://github.com/jeruy/webui-tests-sample/wiki/Getting-Started)

# Build and running the tests locally
If you already have Visual Studio and .NET Core installed in you machine, you can follow below steps : 

**(Using [Visual Studio](https://visualstudio.microsoft.com/vs/community/))**

STEP 1 : Clone this repo to your local  
STEP 2 : Open and Build the solution (```src\WebUI.Tests.Sample.sln```) in Visual Studio  
STEP 3 : If the build is succeeded, you will see the list of tests in Test Explorer window  
STEP 4 : Run all the tests

Youtube video for these steps could be found : [here](https://youtu.be/yxbQ6iQUuiU) 

**(Using .NET Core [SDK](https://dotnet.microsoft.com/download))** 

STEP 1 : Clone the repo to your local  
STEP 2 : Go to csproj file path (```src/WebUI.Tests.Sample```)  
STEP 3 : Run "dotnet build"  
STEP 4 : Run all the tests using "dotnet test" command  

Youtube video for these steps could be found : [here](https://youtu.be/gOCDgAT5N88) 


# About me and my [gig](https://www.fiverr.com/share/N7y5N) on [fiverr](https://www.fiverr.com/share/N7y5N)
Thanks for visiting my repo.   

I've extensive experience with the following technologies:

 - Selenium 
 - xUnit 
 - C# 
 - Angular 
 - Typescript 
 - Jasmine

If you have requirements to write a automation tests, please support my [gig](https://www.fiverr.com/share/N7y5N) at fiverr or contact me via [email](mailto:azrul81@gmail.com)
