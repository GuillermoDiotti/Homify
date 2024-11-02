import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HomeService } from '../../../../backend/services/homes/home.service';
import { UpdateMemberListRequest } from '../../../../backend/services/homes/models/UpdateMemberListRequest';
import { APIError } from '../../../../interfaces/interfaces';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { FormButtonComponent } from '../../../components/form/form-button/form-button.component';
import { FormInputComponent } from '../../../components/form/form-input/form-input.component';
import { FormComponent } from '../../../components/form/form/form.component';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';

@Component({
  selector: 'app-add-home-member-form',
  standalone: true,
  imports: [ReactiveFormsModule, FormComponent, FormButtonComponent, FormInputComponent,
		SuccessMessageComponent, ErrorMessageComponent],
  templateUrl: './add-home-member-form.component.html',
  styleUrl: './add-home-member-form.component.css'
})
export class AddHomeMemberFormComponent {
  form: FormGroup;
	successMessage = '';
	errorMessage = '';
  @Input() selectedHomeId: string | null = null;
  onHomeSelected(id: string) { this.selectedHomeId = id; }

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

      this.HomeService.UpdateMembers(this.selectedHomeId ?? "",req).subscribe(
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
