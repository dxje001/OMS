Outage Management System (OMS)

The Outage Management System (OMS) is an application designed for managing faults and planned operations in an electrical distribution network. It helps monitor and document interruptions caused by planned maintenance or unexpected failures.

Key Features

1. Fault Entry

Automatic Data Generation:

Fault ID: Auto-generated as a combination of the timestamp and sequence number (format: yyyyMMddhhmmss_rb).

Creation Time: Automatically recorded and immutable.

Status: Defaults to "Nepotvrđen" (Unconfirmed), with possible states:

"U popravci" (In Repair)

"Testiranje" (Testing)

"Zatvoreno" (Closed)

User-Entered Details:

Short description of the fault

Electric element affected

Detailed description of the problem

List of actions performed, including:

Action timestamp

Description of work done

2. Electric Element Records

Interface for Adding Elements:

Details include:

Element ID

Name

Type

Geographic Location: Stored as coordinates

Voltage Level: Defaults to "Medium Voltage," with options for "High Voltage" and "Low Voltage"

Text-Based Storage for Element Types:

Managed via text files (no interface required).

3. Fault List Display

Search and Filter:

View faults within a specified time range.

Display includes:

Fault date

Short description

Status

Fault Detail View:

Update fault details unless the status is "Zatvoreno" (Closed).

Priority Definition:

If the status is "U popravci" (In Repair):

Priority increases by 1 for each day since fault registration.

Priority increases by 0.5 for each action performed.

4. Document Generation

Export Formats:

Excel (default): Includes columns:

Fault ID

Element Name

Voltage Level

List of Actions

Additional formats: PDF, CSV

Technical Requirements

Development Methodology

Follows Agile/Scrum principles.

Utilizes Azure DevOps for project management.

Database

Options:

Relational Databases: MS SQL Server, Oracle

Embedded Databases: SQLite, MS Access

XML-based storage

Code Principles

Adheres to SOLID principles and Clean Architecture.

Includes comprehensive Unit Tests to ensure reliability.

Setup Instructions

Prerequisites

Development environment:

IDE (e.g., Visual Studio, IntelliJ)

Azure DevOps account

Database setup:

Choose and configure a compatible database system.

Install dependencies:

Ensure libraries/frameworks for PDF/Excel/CSV generation are installed.

Running the Application

Clone the repository:

git clone <repository-url>

Set up the database connection in the configuration file.

Build and run the application:

dotnet build
dotnet run

Testing

Run unit tests:

   dotnet test
