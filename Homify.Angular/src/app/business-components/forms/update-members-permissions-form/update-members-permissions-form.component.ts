import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HomeService } from '../../../../backend/services/homes/home.service';
import { UpdateMembersPermissionRequest } from '../../../../backend/services/homes/models/UpdateMembersPermissionRequest';
import { APIError } from '../../../../interfaces/interfaces';

@Component({
  selector: 'app-update-members-permissions-form',
  standalone: true,
  imports: [],
  templateUrl: './update-members-permissions-form.component.html',
  styleUrl: './update-members-permissions-form.component.css'
})
export class UpdateMembersPermissionsFormComponent {
  form: FormGroup;
	successMessage = '';
	errorMessage = '';
  @Input() selectedHomeId: string | null = null;
  onHomeSelected(id: string) { this.selectedHomeId = id; }

  constructor(private fb: FormBuilder, private HomeService: HomeService) {
    this.form = this.fb.group({
      canAddAdvices: [false],
			canListDevices: [false],
    });
  }

  handleSubmit() {
		this.successMessage = '';
		this.errorMessage = '';
    if (this.form.valid) {
      const { canAddAdvices, canListDevices } = this.form.value;
      const req: UpdateMembersPermissionRequest = {
        canAddAdvices,
        canListDevices
      };

      this.HomeService.UpdatePermissions(this.selectedHomeId ?? "",req, this.memberId).subscribe(
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
