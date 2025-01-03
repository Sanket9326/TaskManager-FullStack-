import { Component } from '@angular/core';
import { CredentialsService } from '../Services/credentials.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {
   constructor (private service : CredentialsService){}
   roleOfUser : string = this.service.getCredentials().role;

   baseUrl : string = 'http://localhost/api/task';

   

}
