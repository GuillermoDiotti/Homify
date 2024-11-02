import { Component } from "@angular/core";
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from "@angular/forms";
import { FormComponent } from "../../../components/form/form/form.component";
import { FormButtonComponent } from "../../../components/form/form-button/form-button.component";
import { FormInputComponent } from "../../../components/form/form-input/form-input.component";
import CreateCompanyRequest from "../../../../backend/services/company/models/CreateCompanyRequest";
import { CompanyService } from "../../../../backend/services/company/Company.service";
import { SuccessMessageComponent } from "../../../components/success-message/success-message.component";
import { ErrorMessageComponent } from "../../../components/error-message/error-message.component";
import { APIError } from "../../../../interfaces/interfaces";

@Component({
  selector: "app-create-company-form",
  standalone: true,
  imports: [ReactiveFormsModule, FormComponent, FormButtonComponent, FormInputComponent,
		SuccessMessageComponent, ErrorMessageComponent
	],
  templateUrl: "./create-company-form.component.html",
  styleUrls: ["./create-company-form.component.css"],
})
export class CreateCompanyFormComponent {
  form: FormGroup;
	successMessage = '';
	errorMessage = '';

  constructor(private fb: FormBuilder, private CompanyService: CompanyService) {
    this.form = this.fb.group({
      Name: ["", [Validators.required]],
      LogoUrl: ["", [Validators.required]],
      Rut: ["", [Validators.required]],
    });
  }

  handleSubmit() {
		this.successMessage = '';
		this.errorMessage = '';
    if (this.form.valid) {
      const { Name, LogoUrl, Rut} = this.form.value;
      const req: CreateCompanyRequest = {
        Name,
        LogoUrl,
        Rut
      };

      this.CompanyService.create(req).subscribe(
        response => {
          this.successMessage = "Company created successfully";
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