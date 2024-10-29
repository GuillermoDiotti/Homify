import { Component } from "@angular/core";
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from "@angular/forms";
import { FormComponent } from "../../../components/form/form/form.component";
import { FormButtonComponent } from "../../../components/form/form-button/form-button.component";
import { FormInputComponent } from "../../../components/form/form-input/form-input.component";
import { AdminService } from "../../../../backend/services/admin/admin.service";
import { CreateAdminRequest } from "../../../../backend/services/admin/models/CreateAdminRequest";

@Component({
  selector: "app-create-admin-form",
  standalone: true,
  imports: [ReactiveFormsModule, FormComponent, FormButtonComponent, FormInputComponent],
  templateUrl: "./create-admin-form.component.html",
  styleUrls: ["./create-admin-form.component.css"],
})
export class CreateAdminFormComponent {
  form: FormGroup;

  constructor(private fb: FormBuilder, private AdminService: AdminService) {
    this.form = this.fb.group({
      name: ["", [Validators.required]],
      email: ["", [Validators.required, Validators.email]],
      password: ["", [Validators.required]],
      lastName: ["", [Validators.required]],
    });
  }

  handleSubmit() {
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
          console.log("Admin created successfully", response);
        },
        error => {
          console.error("Error creating admin", error);
        }
      );
    } else {
      console.log("Form is invalid");
    }
  }
}