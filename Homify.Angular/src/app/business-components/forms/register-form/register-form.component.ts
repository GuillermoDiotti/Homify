import { Component } from '@angular/core';
import { FormComponent } from '../../../components/form/form/form.component';
import { FormInputComponent } from '../../../components/form/form-input/form-input.component';
import { ButtonComponent } from '../../../components/button/button.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SessionService } from '../../../../backend/services/session/Session.service';
import { APIError } from '../../../../interfaces/interfaces';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';

@Component({
  selector: 'app-register-form',
  standalone: true,
  imports: [FormComponent, FormInputComponent, ButtonComponent, 
		ErrorMessageComponent, SuccessMessageComponent],
  templateUrl: './register-form.component.html',
  styleUrl: './register-form.component.css'
})
export class RegisterFormComponent {
	form: FormGroup;
  currentUserToken: string | null = null;
  errorMessage: string = '';
	successMessage: string = '';

  constructor(private fb: FormBuilder, private sessionService: SessionService) {
		this.form = this.fb.group({
      email: ["", [Validators.required, Validators.email]],
      password: ["", [Validators.required]],
			name: ["", [Validators.required]],
      lastName: ["", [Validators.required]],
			profilePicUrl: ["", [Validators.required]],
    });
	}

  ngOnInit(): void {
    const { token } = this.sessionService.getCurrentUser();
		this.currentUserToken = token ?? null;
  }

  onSubmit(event: Event) {
    event.preventDefault();
		this.errorMessage = '';
		this.successMessage = '';

		if (!this.form.valid) {
			this.errorMessage = "Form is not valid";
			return;
		}
    
		const { email, password, name, lastName, profilePicUrl } = this.form.value;

    this.sessionService.register(email, password, name, lastName, profilePicUrl).subscribe(
      resp => {
        this.errorMessage = '';
				this.successMessage = 'Account created successfully!'
      },
      (error: APIError) => {
        this.errorMessage = error.error.message;
				this.successMessage = '';
      }
    );
		return;
  }
}
