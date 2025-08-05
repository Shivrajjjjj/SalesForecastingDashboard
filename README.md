SalesForecastingDashboard - Setup Guide
=======================================

This project is a Sales Forecasting Dashboard built with ASP.NET Core Razor Pages and ML.NET.

Prerequisites:
--------------
- Visual Studio 2022+ with ASP.NET & EF Core workloads
- .NET 6.0 or later
- SQL Server LocalDB
- Internet connection for NuGet packages

-------------------------------------------------
STEP 1: Restore NuGet packages (if not already)
-------------------------------------------------

Go to:
Tools → NuGet Package Manager → Package Manager Console (PMC)

Run:
> Update-Package -reinstall

-------------------------------------------------
STEP 2: Install EF Core Tools (if not installed)
-------------------------------------------------

In PMC, run:
> Install-Package Microsoft.EntityFrameworkCore.Tools

-------------------------------------------------
STEP 3: Apply Database Migration
-------------------------------------------------

> Add-Migration AddTechnologyAndLanguagesToSalesEntry
> Update-Database

This will create the database and add the missing columns: `TechnologyFocus`, `Languages`.

-------------------------------------------------
STEP 4: Ensure CSV File is Present
-------------------------------------------------

Place your `sales_data.csv` file inside:
> wwwroot\uploads\sales_data.csv

CSV must have the format:

Date,Sales,Technology Focus,Primary Language(s)
2023-01-01,1200,.NET Core Web APIs,C#
2023-02-01,1350,"Razor Pages, Bootstrap UI","C#, HTML, CSS"
...

-------------------------------------------------
STEP 5: Run the Project
-------------------------------------------------

dotnet run --project SalesForecastingDashboard.Web

Use F5 or Ctrl + F5 in Visual Studio to launch the app.

Navigate to:
> https://localhost:{port}/Forecast

You will see:
- Historical Sales Chart
- Forecasted Sales (ML.NET)
- Technology and Language tooltips

