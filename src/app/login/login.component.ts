import { NgIf } from '@angular/common';
import { Component, ElementRef, Renderer2, ViewChild } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { CredentialsService } from '../Services/credentials.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, NgIf, RouterModule, HttpClientModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  @ViewChild('message') pTag!: ElementRef;

  baseurl = 'http://localhost:5019/api/user';

  constructor(
    private router: Router,
    private creds: CredentialsService,
    private http: HttpClient,
    private renderer: Renderer2
  ) {}

  onClick(data: NgForm): void {
    const userCred = {
      Email: data.value.username,
      Password: data.value.password,
    };

    this.http
      .post(
        `${this.baseurl}/login?Email=${userCred.Email}&Password=${userCred.Password}`,
        {},
        { responseType: 'text' }
      )
      .subscribe(
        (res) => {
          if (res === "success") {
            console.log(res);
            this.creds.setCredentials(userCred.Email, userCred.Password);
            this.router.navigate(['/dashboard']);
          } else {
            console.log(res);
          }
        },
        (err) => {
          console.log('Error:', err);
        }
      );
  }

  


}
