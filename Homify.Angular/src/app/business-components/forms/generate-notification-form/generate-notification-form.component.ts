import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormInputComponent } from '../../../components/form/form-input/form-input.component';
import { FormButtonComponent } from '../../../components/form/form-button/form-button.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';
import { NotificationService } from '../../../../backend/services/notification/Notification.service';
import { GenerateNotificationRequest } from '../../../../backend/services/notification/models/GenerateNotificationRequest';
import { APIError } from '../../../../interfaces/interfaces';
import { GetDevicesResponse } from '../../../../backend/services/device/models/GetDevicesResponse';

@Component({
  selector: 'app-generate-notification-form',
  standalone: true,
  imports: [FormInputComponent, ReactiveFormsModule, FormButtonComponent,
		ErrorMessageComponent, SuccessMessageComponent
	],
  templateUrl: './generate-notification-form.component.html',
  styleUrl: './generate-notification-form.component.css',
})
export class GenerateNotificationFormComponent {
  form: FormGroup;
	successMessage = '';
	errorMessage = '';

	notiType = 'window-movement';
	device: GetDevicesResponse | null = null;

  constructor(
    public dialogRef: MatDialogRef<GenerateNotificationFormComponent>,
    private fb: FormBuilder,
		private readonly NotificationService: NotificationService,
		@Inject(MAT_DIALOG_DATA) public data: { device: GetDevicesResponse | null }
  ) {
		this.device = data.device;
    this.form = this.fb.group({
      detail: [''],
    });
  }

	handleSubmit() {
		this.successMessage = '';
		this.errorMessage = '';

		const req: GenerateNotificationRequest = {
			deviceId: this.device?.deviceId ?? '',
			hardwareId: this.device?.hardwareId ?? '',
			personDetectedId: this.form.value.detail ?? '',
			action: this.form.value.detail ?? '',
		};

		this.NotificationService.createNotification(req, this.notiType).subscribe(
			res => this.successMessage = 'Notification successfully created',
			(err: APIError) => this.errorMessage = err.error.message,
		)
	}

	onNotiTypeChange(event: Event) {
		const selectElement = event.target as HTMLSelectElement;
		this.notiType = selectElement.value;
	}

  close(): void {
    this.dialogRef.close();
  }
}
