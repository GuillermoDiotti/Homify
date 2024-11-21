import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { FormComponent } from '../../../components/form/form/form.component';
import { FormButtonComponent } from '../../../components/form/form-button/form-button.component';
import { FormInputComponent } from '../../../components/form/form-input/form-input.component';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { APIError } from '../../../../interfaces/interfaces';
import { CompanyOwnerService } from '../../../../backend/services/company-owner/CompanyOwner.service';
import CreateCompanyOwnerRequest from '../../../../backend/services/company-owner/models/CreateCompanyOwnerRequest';

@Component({
  selector: 'app-create-owner-form',
  standalone: true,
  imports: [ReactiveFormsModule, FormComponent, FormButtonComponent, FormInputComponent, 
		SuccessMessageComponent, ErrorMessageComponent],
  templateUrl: './create-owner-form.component.html',
  styleUrl: './create-owner-form.component.css'
})
export class CreateOwnerFormComponent {
	form: FormGroup;
	successMessage = '';
	errorMessage = '';

  constructor(private fb: FormBuilder, private OwnerService: CompanyOwnerService) {
    this.form = this.fb.group({
      name: ["", [Validators.required]],
      email: ["", [Validators.required, Validators.email]],
      password: ["", [Validators.required]],
      lastName: ["", [Validators.required]],
    });
  }

  handleSubmit() {
		this.successMessage = '';
		this.errorMessage = '';
    if (this.form.valid) {
      const { name, email, password, lastName } = this.form.value;
      const req: CreateCompanyOwnerRequest = {
        name,
        email,
        password,
        lastName,
      };

      this.OwnerService.create(req).subscribe(
        response => {
					this.successMessage = "Company owner created successfully";
        },
        (error: APIError) => {
          this.errorMessage = error.error.message;
        }
      );
    } else {
      this.errorMessage = "Form is invalid";
    }
  }
}
