import { Component } from '@angular/core';
import { CredentialsService } from '../Services/credentials.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule, NgFor } from '@angular/common';

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
  imports: [HttpClientModule,CommonModule,NgFor],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
})
export class DashboardComponent {
  baseUrl: string = 'http://localhost:5019/api/task';
  constructor(private service: CredentialsService, private http: HttpClient) {}
  roleOfUser: string = this.service.getCredentials().role;
  Tasks: Task[] = [];
  ngOnInit(): void {
    this.http.get<Task[]>(this.baseUrl).subscribe(
      (tasks) => {
        console.log('Fetched tasks:', tasks);  // Log the response
        this.Tasks = tasks;
      },
      (error) => console.log('Error fetching tasks:', error)
    );
  }
  
}
