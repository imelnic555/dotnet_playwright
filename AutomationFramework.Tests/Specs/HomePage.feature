Feature: HomePage
  As a user
  I want to navigate to the homepage
  So that I can verify the title and interactions

  Scenario: Verify Home Page Title
    Given I open the browser
    When I navigate to "https://example.com"
    Then the page title should contain "Example Domain"

  Scenario: Verify Button Click
    Given I open the browser
    When I navigate to "https://example.com"
