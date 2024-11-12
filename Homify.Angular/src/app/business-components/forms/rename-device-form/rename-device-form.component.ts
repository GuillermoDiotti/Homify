import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { GetDevicesResponse } from '../../../../backend/services/device/models/GetDevicesResponse';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { HomeDeviceService } from '../../../../backend/services/homedevice/HomeDevice.service';
import { UpdateHomeDeviceRequest } from '../../../../backend/services/homedevice/models/UpdateHomeDeviceRequest';
import { FormInputComponent } from '../../../components/form/form-input/form-input.component';
import { FormButtonComponent } from '../../../components/form/form-button/form-button.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';
import { APIError } from '../../../../interfaces/interfaces';

@Component({
  selector: 'app-rename-device-form',
  standalone: true,
  imports: [FormInputComponent, ReactiveFormsModule, FormButtonComponent,
		ErrorMessageComponent, SuccessMessageComponent],
  templateUrl: './rename-device-form.component.html',
  styleUrl: './rename-device-form.component.css'
})
export class RenameDeviceFormComponent {
	form: FormGroup;
	successMessage = '';
	errorMessage = '';

	device: GetDevicesResponse | null = null;

  constructor(
    public dialogRef: MatDialogRef<RenameDeviceFormComponent>,
    private fb: FormBuilder,
		private readonly HomeDeviceService: HomeDeviceService,
		@Inject(MAT_DIALOG_DATA) public data: { device: GetDevicesResponse | null }
  ) {
		this.device = data.device;
    this.form = this.fb.group({
      customName: [''],
    });
  }

	handleSubmit() {
		this.successMessage = '';
		this.errorMessage = '';

		const req: UpdateHomeDeviceRequest = {
			customName: this.form.value.customName,
		}

		this.HomeDeviceService.renameDevice(req, this.device?.id ?? '').subscribe(
			res => this.successMessage = "Device renamed successfully",
			(err: APIError) => this.errorMessage = err.error.message,
		)
	}

  close(): void {
    this.dialogRef.close();
  }
}
