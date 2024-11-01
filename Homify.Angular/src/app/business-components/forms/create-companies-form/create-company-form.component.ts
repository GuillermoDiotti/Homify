import { Component } from "@angular/core";
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from "@angular/forms";
import { FormComponent } from "../../../components/form/form/form.component";
import { FormButtonComponent } from "../../../components/form/form-button/form-button.component";
import { FormInputComponent } from "../../../components/form/form-input/form-input.component";
import CreateCompanyRequest from "../../../../backend/services/company/models/CreateCompanyRequest";
import { CompanyService } from "../../../../backend/services/company/Company.service";

@Component({
  selector: "app-create-company-form",
  standalone: true,
  imports: [ReactiveFormsModule, FormComponent, FormButtonComponent, FormInputComponent],
  templateUrl: "./create-company-form.component.html",
  styleUrls: ["./create-company-form.component.css"],
})
export class CreateCompanyFormComponent {
  form: FormGroup;

  constructor(private fb: FormBuilder, private CompanyService: CompanyService) {
    this.form = this.fb.group({
      Name: ["", [Validators.required]],
      LogoUrl: ["", [Validators.required]],
      Rut: ["", [Validators.required]],
    });
  }

  handleSubmit() {
    if (this.form.valid) {
      const { Name, LogoUrl, Rut} = this.form.value;
      const req: CreateCompanyRequest = {
        Name,
        LogoUrl,
        Rut
      };

      this.CompanyService.create(req).subscribe(
        response => {
          console.log("Company created successfully", response);
        },
        error => {
          console.error("Error creating company", error);
        }
      );
    } else {
      console.log("Form is invalid");
    }
  }
}