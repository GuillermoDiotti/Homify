
import { Component, OnInit } from '@angular/core';
import { SessionService, User } from '../../../backend/services/session/Session.service';
import { APIError } from '../../../interfaces/interfaces';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  username: string = 'admin@domain.com';
  password: string = '.Popso212';
  currentUserToken: string | null = null;
  errorMessage: string = '';

  constructor(private sessionService: SessionService) {}

  ngOnInit(): void {
    this.sessionService.getCurrentUserToken().subscribe(
      resp => {
        this.currentUserToken = resp;
      }
    );
  }

  onPasswordChange(newPassword: string){
    this.password = newPassword;
  }

  onUsernameChange(newUsername: string){
    this.username = newUsername;
  }

  onSubmit(event: Event) {
    event.preventDefault();

    this.sessionService.login(this.username, this.password).subscribe(
      resp => {
				console.log(resp)
        this.sessionService.setCurrentUserToken(resp.token);
        localStorage.setItem('token', resp.token);
        this.errorMessage = '';
      },
      (error: APIError) => {
        console.error('Login failed:', error.error);
        this.errorMessage = error.error.message;
      }
    );
  }

  onLogout(){
    this.currentUserToken = null;
    this.sessionService.setCurrentUserToken(null);
  }
}
