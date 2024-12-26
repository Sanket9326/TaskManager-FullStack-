import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {
  constructor(public router: Router) {}

  onLogin() {
    this.router.navigate(['/login']);
  }
  onSignup() {
    this.router.navigate(['/signup']);
  }
}
