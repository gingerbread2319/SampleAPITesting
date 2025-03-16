# SampleAPITesting Documentation

This will serve as a documentation on how to install and use the SampleAPITesting framework.

## Pre-Requisites:
**Install the following tools:**
- Visual Studio 2022 Community Edition - https://visualstudio.microsoft.com/vs/community/
- .Net 8.0
- Github account

## Retrieving the framework from GitHub
After installing the required tools, you can clone the test framework from GitHub. Follow the steps below:

1. **Open Visual Studio 2022**
    - Launch Visual Studio 2022 on your system.

2. **Open the Clone Repository Window**
    - On the start window, select "Clone a repository" under the "Get started" section.
3. **Enter the Repository URL**
    - In the "**Repository location**" field, paste the GitHub repository URL: https://github.com/gingerbread2319/SampleAPITesting.git

4. **Select a Local Path**
    - Choose a folder where the repository will be stored on your local machine.

5. **Authenticate (If Required)**
    - If prompted, sign in to GitHub using your credentials.
You may need to generate a personal access token if you haven't set up authentication.

6. **Click "Clone"**
    - Visual Studio will fetch the repository. Wait until it downloads all the files.

## Running the tests

1. **Build the Project**
    - Go to Build > Build Solution (Ctrl + Shift + B) to compile the project.

2. **Open the Test Explorer**
    - Navigate to Test > Test Explorer from the top menu. This will display all available test cases, including Reqnroll feature files.

3. **Run the Feature Files**
    - In Test Explorer, locate the feature files or test scenarios.
    - Right-click on the test you want to run and select "Run".
    - Alternatively, click "Run All Tests" to execute all scenarios.

## Viewing the test results
After executing the test, the results will be displayed in Test Explorer, indicating the pass/fail status along with logs. Additionally, the framework generates a detailed report using the **ExtentReports** plugin.

An HTML report is automatically created under **\TestResults\index.html**. You can view it by opening the file in a web browser.


## SampleAPITesting Framework Structure and Folder Breakdown
This document provides an overview of the test framework structure, describing the purpose of each folder and its corresponding files.

### Project Structure
| **Folder/File**                             | **Description** |
|---------------------------------------------|---------------|
| `Core/`                                     | Contains essential framework utilities. You can add something like Selenium element and driver managers here. |
| `Core/API/`                                 | Contains API-related framework utilities. |
| `Core/ExtentReport.cs`                  | Manages test reporting using the ExtentReports plugin to generate HTML reports. |
| `Hooks/ReqNRollHooks.cs`               | Defines setup and teardown methods executed before and after test runs. |
| `StepDefinitions/`                          | Houses the implementation of test steps corresponding to feature files. |
| `StepDefinitions/Common/`                   | Defines reusable step definitions that can be used by all tests. |
| `StepDefinitions/Common/API/APISteps.cs`    | Defines reusable step definitions for API-related tests. |
| `StepDefinitions/Tmsandbox/Tmsandbox_APISteps.cs` | Implements step definitions specific to the Tmsandbox API testing. |
| `TestResults/`                              | This is where the ExtentReports HTML file is created after a test run. |
| `Tests/`                                    | Contains all feature files that define test scenarios in Gherkin syntax. |
| `Tests/Tmsandbox/APITest.feature`          | Contains feature files/test scenarios for the Tmsandbox API. |
