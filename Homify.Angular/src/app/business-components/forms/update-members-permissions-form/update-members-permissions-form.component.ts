import { Component, Input } from '@angular/core';

import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
} from '@angular/forms';
import { HomeService } from '../../../../backend/services/homes/home.service';
import { UpdateMembersPermissionRequest } from '../../../../backend/services/homes/models/UpdateMembersPermissionRequest';
import { APIError } from '../../../../interfaces/interfaces';
import { FormComponent } from '../../../components/form/form/form.component';
import { FormButtonComponent } from '../../../components/form/form-button/form-button.component';
import { FormInputComponent } from '../../../components/form/form-input/form-input.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';

@Component({
  selector: 'app-update-members-permissions-form',

  standalone: true,

  imports: [
    ReactiveFormsModule,
    FormComponent,
    FormButtonComponent,
    FormInputComponent,

    SuccessMessageComponent,
    ErrorMessageComponent,
  ],

  templateUrl: './update-members-permissions-form.component.html',

  styleUrl: './update-members-permissions-form.component.css',
})
export class UpdateMembersPermissionsFormComponent {
  form: FormGroup;
  successMessage = '';
  errorMessage = '';

  @Input() selectedMemberId: string | null = null;
  @Input() selectedHomeId: string | null = null;
  constructor(private fb: FormBuilder, private homeService: HomeService) {
    this.form = this.fb.group({
      canAddDevices: [false],
      canListDevices: [false],
    });
  }

  handleSubmit(event:Event) {
    event.preventDefault();
    this.successMessage = '';
    this.errorMessage = '';

    if (this.form.valid) {
      const { canAddDevices, canListDevices } = this.form.value;
      const req: UpdateMembersPermissionRequest = {
        canAddDevices:Boolean(canAddDevices),
        canListDevices:Boolean(canListDevices),
      };
      this.homeService
        .UpdatePermissions(this.selectedHomeId ?? '', req, this.selectedMemberId ?? '')
        .subscribe(
          (response) => {
            this.successMessage = 'Permissions updated successfully';
          },
          (error: APIError) => {
            this.errorMessage = error.error.message;
          }
        );
    } else {
      this.errorMessage = 'Form is invalid';
    }
  }
}
