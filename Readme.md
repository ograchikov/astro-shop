# Astro Shop Demo Project

## Summary
- The goal of this project is to test different tools and frameworks and demonstrate various approaches to software testing. The project meant to be platform and technology agnostic.

## Repository Structure
- The project uses single repository for demo purposes.  
  Real project may be splitted into independent repositories for security and maintainability purposes.

## Getting Started
- The project currently has two parts
  - Simple vanilla js shop in src\js\web-frontend
  - Test framework written in .net core in test\dotnet\AstroShop.Tests.sln

- In order to run tests on your machine, you need to specify path to AstroShop index.html in test\dotnet\AstroShop.UiTests\Configs\appsetings.yaml
````
AstroShopBaseUrl: "file:///x:/path-to-repository/src/web-frontend/index.html"
````