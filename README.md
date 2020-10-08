# Web Testing Mini Project

### Project Aims

The goal of this project is to produce an automated test framework for the Sauce Demo website (https://www.saucedemo.com/).

The framework is to test all major features of the website including:

+ Login & Authentication
+ Inventory
+ Cart
+ Checkout

### Tools

+ C#
+ Selenium Web Driver
+ NUnit
+ SpecFlow

### Framework

The framework uses the concept of a page object model (POM) in order to encapsulate possible user actions on a given page (such as entering text into a field, clicking a button), and to abstract away the use of Selenium by encapsulating all calls to Selenium inside the POM. Public methods and properties of the POM are descriptive of the action or data they represent and require no knowledge of Selenium to use. Access to POM objects is provided by an instance of the `SauceDemoWebsite` class, which contains an instance of each POM class.

![](/class_diagram.png)

Individual test cases are specified in Gherkin syntax, and individual steps of a test case are translated into a method call using SpecFlow. The method calls representing steps are contained in classes whose name ends in "Steps", for example - the `LoginSteps` class contains methods for steps pertaining to logging in.

Classes containing methods for test steps have access to an instance of the `SauceDemoWebsite` class, and interact with the website by calling methods of the POM classes. The instance of the `SauceDemoWebsite` class is provided to the class constructor through Context Injection, and this instance is shared by instances of all step classes at runtime. This means that a single test case can use methods from more than one class, as they will all have access to the same instance of `SauceDemoWebsite`.

The instance of `SauceDemoWebsite` shared by step classes is configured in the `WebsiteSupport` class. In order to change the browser used for tests change the following line of code in the `InitializeWebsite` method:

```csharp
SauceDemoWebsite website = new SauceDemoWebsite(Browser.Chrome);
```

`Browser.Chrome` can be changed to `Browser.Firefox`.

New test cases can be specified using Gherkin syntax in feature files. Preconditions are specified using `Given`, actions are specified using `When`, and postconditions are specified using `Then`. An example of a test case is as follows:

```gherkin
Given I am on the home page
And I enter the username "standard_user"
And I enter the password "secret_sauce"
When I click the login button
Then I am on the inventory page
```

Many relevant phrases are already mapped to steps in code, and these phrases can be freely used and recombined in order to generate new test cases without writing new C# code. Note that some steps will have certain preconditions which must be met. For example, in order to enter a username, you must first be on the home page.

If a new phrase is needed which does not have a step definition, the relevant step definition must be written in the relevant class. If this pertains to the login page, it should go in the `LoginSteps` class, and so on.

URLs for the different pages of the Sauce Demo website are specified in the `config.json` file. If a URL changes, it should be updated in this file. However, do not change the attribute name (e.g. `home-page-url`), as this is needed by the program to locate the URL in the file.

### Running Tests

In order to run the tests, open the project in Visual Studio, open the Test Explorer, and click "Run All Tests".

### Project Review

The project has been a success as all major project aims have been met. Tests have been written for all features of the Sauce Demo website, and a robust and extensible testing framework has been produced. At the time of writing, all tests have passed.
