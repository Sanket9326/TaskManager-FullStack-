# Task Manager Application

![Angular](https://img.shields.io/badge/Frontend-Angular-blue)
![C%23](https://img.shields.io/badge/Backend-C%23_.NET_Core-brightgreen)
![MySQL](https://img.shields.io/badge/Database-MySQL-orange)
![Entity Framework](https://img.shields.io/badge/ORM-Entity_Framework_Core-yellow)
![License](https://img.shields.io/badge/License-MIT-lightgrey)

## Overview
The **Task Manager Application** is a full-stack project designed to streamline task assignment and tracking within a team. Built with modern technologies, it features a role-based system that simplifies the task management process for admins and team members.

## Features

### Admin Functionalities
- **Assign Tasks:** Admins can assign tasks to team members.
- **Update Tasks:** Admins can modify task details as needed.
- **Delete Tasks:** Admins can remove tasks from the system.

### Team Member Functionalities
- **View Tasks:** Team members can view the tasks assigned to them.
- **Mark Tasks Completed:** Team members can mark tasks as completed once done.

### General Features
- **Role-Based System:** Ensures that only authorized users (admins or team members) can perform their respective actions.
- **REST API Integration:** The backend services are exposed as REST APIs for smooth communication with the frontend.
- **Database Management:** All task-related data is securely stored and managed using MySQL Server.
- **Responsiveness:** The application provides an intuitive and user-friendly interface powered by Angular and TypeScript.

## Technology Stack
- **Frontend:** Angular, TypeScript
- **Backend:** C# .NET Core, REST APIs
- **Database:** MySQL Server
- **ORM:** Entity Framework Core

## Problem Solved
This application addresses common challenges in task management, such as:
- Streamlining the task assignment process.
- Reducing the chances of forgetting assigned tasks.
- Providing a centralized system for task tracking and updates.

## Installation

### Prerequisites
1. Node.js and Angular CLI installed on your machine.
2. .NET SDK installed.
3. MySQL Server installed and configured.

### Steps
1. Clone the repository:
   ```bash
   git clone https://github.com/Sanket9326
   ```
2. Navigate to the project directory and install frontend dependencies:
   ```bash
   cd frontend
   npm install
   ```
3. Configure the database connection in the backend project:
   - Update the connection string in `appsettings.json` with your MySQL Server credentials.

4. Apply database migrations:
   ```bash
   dotnet ef database update
   ```
5. Start the backend server:
   ```bash
   dotnet run
   ```
6. Start the Angular frontend:
   ```bash
   ng serve
   ```
7. Open the application in your browser:
   ```
   http://localhost:4200
   ```

## Code Snippets

### Admin Task Assignment Example
```csharp
[HttpPost("/assign-task")]
public IActionResult AssignTask([FromBody] TaskDto task)
{
    if (ModelState.IsValid)
    {
        _taskService.AssignTask(task);
        return Ok("Task assigned successfully");
    }
    return BadRequest("Invalid data");
}
```

### Angular Service for Task Fetching
```typescript
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private apiUrl = 'http://localhost:5000/api/tasks';

  constructor(private http: HttpClient) {}

  getTasks(): Observable<any> {
    return this.http.get(this.apiUrl);
  }
}
```

## Usage
1. **Admin Login:** Access the admin dashboard to manage tasks.
2. **Team Member Login:** View and update tasks assigned to you.
3. Use the intuitive UI to navigate between features such as task assignment, updates, and completion marking.

## Future Enhancements
- Add email notifications for task updates and completions.
- Implement a dashboard with analytics for better task monitoring.
- Introduce multi-language support for a wider audience.

## Contributing
Contributions are welcome! Please create a pull request with detailed information about the proposed changes.

## License
This project is licensed under the [MIT License](LICENSE).

## Contact
For queries or support, please contact:
- **Email:** sawantsanket640@gmail.com
- **GitHub Issues:** [Repository Issues](https://github.com/Sanket9326/issues)

