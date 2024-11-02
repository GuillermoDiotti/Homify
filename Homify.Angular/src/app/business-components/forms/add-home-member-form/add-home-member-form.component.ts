import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HomeService } from '../../../../backend/services/homes/home.service';
import { UpdateMemberListRequest } from '../../../../backend/services/homes/models/UpdateMemberListRequest';
import { APIError } from '../../../../interfaces/interfaces';

@Component({
  selector: 'app-add-home-member-form',
  standalone: true,
  imports: [],
  templateUrl: './add-home-member-form.component.html',
  styleUrl: './add-home-member-form.component.css'
})
export class AddHomeMemberFormComponent {
  form: FormGroup;
	successMessage = '';
	errorMessage = '';

  constructor(private fb: FormBuilder, private HomeService: HomeService) {
    this.form = this.fb.group({
      email: ["", [Validators.required]],
    });
  }

  handleSubmit() {
		this.successMessage = '';
		this.errorMessage = '';
    if (this.form.valid) {
      const { email } = this.form.value;
      const req: UpdateMemberListRequest = {
        email
      };

      this.HomeService.UpdateMembers(req).subscribe(
        response => {
         	this.successMessage = "Member added successfully";
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
