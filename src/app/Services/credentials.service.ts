import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CredentialsService {
  constructor() {}
  public setCredentials(email: string, password: string, role : string): void {
    localStorage.setItem('Email', email);
    localStorage.setItem('Password', password);
    localStorage.setItem('Role', role);
  }
  public getCredentials() : any {
    return {
      Email: localStorage.getItem('Email'),
      Password: localStorage.getItem('Password'),
      Role: localStorage.getItem('Role'),
    };
  }
  public clearCredentials(): void {
    localStorage.removeItem('Email');
    localStorage.removeItem('Password');
    localStorage.removeItem('Role');
  }
}
