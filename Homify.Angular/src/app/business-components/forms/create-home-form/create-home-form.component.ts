import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { FormComponent } from '../../../components/form/form/form.component';
import { FormButtonComponent } from '../../../components/form/form-button/form-button.component';
import { FormInputComponent } from '../../../components/form/form-input/form-input.component';
import { HomeService } from '../../../../backend/services/homes/home.service';
import { CreateHomeRequest } from '../../../../backend/services/homes/models/CreateHomeRequest';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { APIError } from '../../../../interfaces/interfaces';

@Component({
  selector: "app-create-home-form",
  standalone: true,
  imports: [ReactiveFormsModule, FormComponent, FormButtonComponent, FormInputComponent,
		SuccessMessageComponent, ErrorMessageComponent
	],
  templateUrl: "./create-home-form.component.html",
  styleUrls: ["./create-home-form.component.css"],
})
export class CreateHomeFormComponent {
  form: FormGroup;
	successMessage = '';
	errorMessage = '';

  constructor(private fb: FormBuilder, private HomeService: HomeService) {
    this.form = this.fb.group({
      street: ["", [Validators.required]],
      number: ["", [Validators.required]],
      latitude: ["", [Validators.required]],
      longitud: ["", [Validators.required]],
      alias: ["", [Validators.required]],
      maxMembers: ["", [Validators.required, Validators.pattern("^[0-9]*$")]]  
    });
  }

  handleSubmit() {
		this.successMessage = '';
		this.errorMessage = '';
    if (this.form.valid) {
      const { street, number, latitude, longitud, alias, maxMembers } = this.form.value;
      const req: CreateHomeRequest = {
        street,
        number,
        latitude,
        longitud,
        alias,
        maxMembers
      };

      this.HomeService.create(req).subscribe(
        response => {
         	this.successMessage = "Home created successfully";
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