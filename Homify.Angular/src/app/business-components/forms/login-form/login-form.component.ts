import { Component } from '@angular/core';
import { APIError } from '../../../../interfaces/interfaces';
import { SessionService } from '../../../../backend/services/session/Session.service';
import { FormComponent } from '../../../components/form/form/form.component';
import { ButtonComponent } from '../../../components/button/button.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormInputComponent } from '../../../components/form/form-input/form-input.component';
import { HomeownerButtonComponent } from '../../buttons/homeowner-button/homeowner-button.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';

@Component({
  selector: 'app-login-form',
  standalone: true,
  imports: [FormComponent, FormInputComponent, ButtonComponent, 
		HomeownerButtonComponent, ErrorMessageComponent],
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.css'
})
export class LoginFormComponent {
	form: FormGroup;
  currentUserToken: string | null = null;
	currentUserName: string = '';
  errorMessage: string = '';

  constructor(private fb: FormBuilder ,private sessionService: SessionService) {
		this.form = this.fb.group({
      email: ["admin@domain.com", [Validators.required, Validators.email]],
      password: [".Popso212", [Validators.required]],
    });
	}

  ngOnInit(): void {
    const { token, name } = this.sessionService.getCurrentUser();
		this.currentUserToken = token ?? null;
		this.currentUserName = name;
  }

  onSubmit(event: Event) {
    event.preventDefault();
		this.errorMessage = '';

		if (!this.form.valid) {
			this.errorMessage = "Form is not valid";
			return;
		}
    
		const { email, password } = this.form.value;

    this.sessionService.login(email, password).subscribe(
      resp => {
        this.sessionService.setCurrentUser(resp.token, resp.roles, resp.name);
				this.currentUserToken = resp.token;
        this.errorMessage = '';
      },
      (error: APIError) => {
        this.errorMessage = error.error.message;
      }
    );
		return;
  }

  onLogout(){
    this.currentUserToken = null;
		this.sessionService.removeCurrentUserToken();
  }
}