import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CredentialsService {
  constructor() {}
  public setCredentials(email: string, password: string): void {
    localStorage.setItem('Email', email);
    localStorage.setItem('Password', password);
  }
  public getCredentials() : any {
    return {
      Email: localStorage.getItem('Email'),
      Password: localStorage.getItem('Password'),
    };
  }
  public clearCredentials(): void {
    localStorage.removeItem('Email');
    localStorage.removeItem('Password');
  }
}
