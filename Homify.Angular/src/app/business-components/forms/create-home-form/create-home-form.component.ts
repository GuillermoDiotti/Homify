import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { FormComponent } from '../../../components/form/form/form.component';
import { FormButtonComponent } from '../../../components/form/form-button/form-button.component';
import { FormInputComponent } from '../../../components/form/form-input/form-input.component';
import { HomeService } from '../../../../backend/services/homes/home.service';
import { CreateHomeRequest } from '../../../../backend/services/homes/models/CreateHomeRequest';

@Component({
  selector: "app-create-home-form",
  standalone: true,
  imports: [ReactiveFormsModule, FormComponent, FormButtonComponent, FormInputComponent],
  templateUrl: "./create-home-form.component.html",
  styleUrls: ["./create-home-form.component.css"],
})
export class CreateHomeFormComponent {
  form: FormGroup;

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
          console.log("Home created successfully", response);
        },
        error => {
          console.error("Error creating home", error);
        }
      );
    } else {
      console.log("Form is invalid");
    }
  }
}