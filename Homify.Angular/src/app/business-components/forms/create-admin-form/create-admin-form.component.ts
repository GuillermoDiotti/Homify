import { Component } from "@angular/core";
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from "@angular/forms";
import { FormComponent } from "../../../components/form/form/form.component";
import { FormButtonComponent } from "../../../components/form/form-button/form-button.component";
import { FormInputComponent } from "../../../components/form/form-input/form-input.component";
import { AdminService } from "../../../../backend/services/admin/admin.service";
import { CreateAdminRequest } from "../../../../backend/services/admin/models/CreateAdminRequest";
import { SuccessMessageComponent } from "../../../components/success-message/success-message.component";
import { ErrorMessageComponent } from "../../../components/error-message/error-message.component";
import { APIError } from "../../../../interfaces/interfaces";

@Component({
  selector: "app-create-admin-form",
  standalone: true,
  imports: [ReactiveFormsModule, FormComponent, FormButtonComponent, FormInputComponent, 
		SuccessMessageComponent, ErrorMessageComponent],
  templateUrl: "./create-admin-form.component.html",
  styleUrls: ["./create-admin-form.component.css"],
})
export class CreateAdminFormComponent {
  form: FormGroup;
	successMessage = '';
	errorMessage = '';

  constructor(private fb: FormBuilder, private AdminService: AdminService) {
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
      const req: CreateAdminRequest = {
        name,
        email,
        password,
        lastName,
      };

      this.AdminService.create(req).subscribe(
        response => {
					this.successMessage = "Admin created successfully";
        },
        (error: APIError) => {
          this.errorMessage = error.error.message;
        }
      );
    } else {
      console.log("Form is invalid");
    }
  }
}