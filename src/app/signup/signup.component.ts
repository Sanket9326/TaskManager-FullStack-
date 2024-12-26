import { NgIf } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [FormsModule, HttpClientModule, RouterModule, NgIf],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css',
})
export class SignupComponent {
  baseurl = 'http://localhost:5019/api/user';
  showError: boolean = true;
  showSuccess: boolean = false;

  constructor(private http: HttpClient, private router: Router) {}

  onSubmit(data: NgForm): void {
    
    const userCred = {
      Email: data.value.email,
      Password: data.value.password,
      Contact: data.value.contact,
      FullName: data.value.fullname,
    };

    this.http.put(this.baseurl + '/add', userCred).subscribe(
      (res) => {
        this.showError = false;
        this.showSuccess = true;
        this.router.navigate(['/dashboard']);
      },
      (err) => {
        this.showError = true;
        console.error(err);
        alert('Failed to signup. Please try again.');
      }
    );
  }
}
