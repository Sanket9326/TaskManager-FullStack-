import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TaskService {
  constructor() {}

  TaskId: number = 0;
  TaskName: string = '';
  TaskDescription: string = '';
  CreatedDate: Date = new Date();
  TaskAdmin: string = '';
}
