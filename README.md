# Outage Management System (OMS)

## Overview

The Outage Management System (OMS) is a tool for managing faults and planned operations in an electrical distribution network. It tracks and records planned and unplanned interruptions to ensure efficient management and resolution.

## Key Technologies

- Programming Language: .NET (C#)

- Database: MS SQL Server, Oracle, SQLite, or XML-based storage

- Methodology: Agile/Scrum using Azure DevOps

- Architecture: Adheres to SOLID principles and Clean Architecture

- Testing: Comprehensive Unit Testing for reliability

## How It Works

1.  Fault Management:

* Automatically generates unique Fault IDs and timestamps.

* Records details such as affected elements, descriptions, actions taken, and statuses (e.g., "In Repair").

2.  Element Records:

* Stores details about electrical elements, including ID, type, location, and voltage levels.

3.  Priority Assignment:

* Calculates fault priority based on the time since registration and actions performed.

4.  Document Export:

* Supports Excel, PDF, and CSV formats for fault and action summaries.

## SOLID Principles

* Single Responsibility: Each class handles a specific aspect of fault or element management.

* Open/Closed: Modules can be extended for new formats (e.g., additional export types) without modifying existing code.

* Liskov Substitution: Interchangeable components ensure fault-tolerant behavior.

* Interface Segregation: Interfaces are minimal and focused on specific functionalities.

* Dependency Inversion: High-level modules depend on abstractions, not implementations.
