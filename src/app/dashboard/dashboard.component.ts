import { Component } from '@angular/core';
import { CredentialsService } from '../Services/credentials.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule, NgFor, NgIf } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';

interface Task {
  taskId: number;
  taskName: string;
  taskDescription: string;
  createdDate: Date;
  taskAdmin: string;
}
@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [HttpClientModule, CommonModule, NgFor, NgIf, FormsModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
})
export class DashboardComponent {
  addTaskFlag: boolean = false;
  updateTaskFlag: boolean = false;
  isAdmin = false;
  baseUrl: string = 'http://localhost:5019/api/task';
  constructor(private service: CredentialsService, private http: HttpClient) {}
  roleOfUser: string = this.service.getCredentials().role;
  Tasks: Task[] = [];
  ngOnInit(): void {
    if (this.service.getCredentials().role === 'admin') {
      this.isAdmin = true;
    }
    this.fetchAllTasks();
  }

  fetchAllTasks() {
    this.http.get<Task[]>(this.baseUrl).subscribe(
      (tasks) => {
        console.log('Fetched tasks:', tasks);
        this.roleOfUser = this.service.getCredentials().role;
        this.Tasks = tasks;
      },
      (error) => console.log('Error fetching tasks:', error)
    );
  }

  onClickDeleteTask(
    TaskId: number,
    taskName: string,
    taskDescription: string,
    createdDate: Date,
    taskAdmin: string
  ): void {
    const currTask: Task = {
      taskId: TaskId,
      taskName: taskName,
      taskDescription: taskDescription,
      createdDate: createdDate,
      taskAdmin: taskAdmin,
    };

    this.http.post(this.baseUrl + '/delete', currTask).subscribe(
      (response) => {
        this.fetchAllTasks();
      },
      (err) => {
        console.log('Error Deleting Task:', err);
      }
    );
  }

  onAddTaskClick() {
    this.addTaskFlag = true;
  }

  addTask(data: any) {
    const newTask = {
      taskName: data.value.taskName,
      taskDescription: data.value.taskDescription,
      createdDate: new Date(),
      taskAdmin: data.value.taskAdmin,
    };
    this.http.post(this.baseUrl + '/add', newTask).subscribe(
      (response) => {
        this.fetchAllTasks();
        this.addTaskFlag = false;
      },
      (err) => {
        console.log('Error Adding Task:', err);
      }
    );
  }
}
