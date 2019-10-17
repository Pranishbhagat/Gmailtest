# Project Assessment:
The provided repository contains an incomplete automated test for email sending functionality via Gmail.

The test is supposed to:
- Login to Gmail
- Compose an email with unique subject, body, and attachment
- Label email as "Social"
- Send the email to the same account which was used to login (from and to addresses would be the same)
- Wait for the email to arrive in the Inbox
- Open the received email
- Verify email came under proper Label i.e. "Social"
- Verify the subject, body and attachment name of the received email
- Generate test execution report at the end
- Provide the video recording of your test execution with the submission

# Notes
- Update the config.json file to replace dummy credentials before you run the tests. You may remove your login details before submitting this assessment.
- Don't include downloaded packages and any auto-generated folders like bin or obj.
- Please enable "Social" label for your gmail account using following steps:
	-Go to Settings of your gmail account
	-Click on "Labels" tab and click on "Show" for "Social" label under Categories
	-Click on "Inbox" tab and mark the checkbox for "Social" and "Primary" under Categories so that "Social" and "Primary" tabs appears on the main page of your gmail account 

# Tasks:
1. Complete the automated test to include the missing functionality, refer to the section titled 'Project Assessment' for requirements.
2. There are a few bugs in the existing code that we'd like you to fix, the test case seems to be failing right now. Even though the project might not be in a great structure, please do not spend your valuable time on structure modifications unless explicitly asked to, just focus on fixing bugs.
3. Refactor the code in existing 'Should_Send_Email' test case to use Page Object Model.

PLEASE NOTE THAT ALL THE TASKS LISTED ABOVE ARE MANDATORY. We'll be evaluating your submission on the following parameters:

- Implementation of new test cases
- Bug fixes

# Prerequisites:
- .NET Core SDK v2.0 or higher
- Any IDE (Visual Studio 2017 recommended)

# Development Environment:
On any terminal move to the "CrossMail.Tests" folder (the folder containing the "CrossMail.Tests.csproj" file) and execute the following commands:
- dotnet restore
- dotnet test

# How to deliver:
This is how we are going to access and evaluate your submission, so make sure you go through the following steps before submitting your answer.

1. Make sure that the tests are passing, there are no errors, and any new dependencies are specified in package.json.
2. Zip your project folder and name it 'cross-mail-selenium-cs_<YourNameHere>.zip'.
3. Store your file in a shared location where Crossover team can access and download it for evaluation. Do not forget to paste the shared link in the answer field of this question.