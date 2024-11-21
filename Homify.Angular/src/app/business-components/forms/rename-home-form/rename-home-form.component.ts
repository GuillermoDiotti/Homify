import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { GetDevicesResponse } from '../../../../backend/services/device/models/GetDevicesResponse';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { HomeService } from '../../../../backend/services/homes/home.service';
import { RenameHomeRequest } from '../../../../backend/services/homes/models/RenameHomeRequest';
import { APIError } from '../../../../interfaces/interfaces';
import { FormButtonComponent } from '../../../components/form/form-button/form-button.component';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { FormInputComponent } from '../../../components/form/form-input/form-input.component';

@Component({
  selector: 'app-rename-home-form',
  standalone: true,
  imports: [FormInputComponent, ReactiveFormsModule, FormButtonComponent,
		ErrorMessageComponent, SuccessMessageComponent],
  templateUrl: './rename-home-form.component.html',
  styleUrl: './rename-home-form.component.css'
})
export class RenameHomeFormComponent {
	form: FormGroup;
	successMessage = '';
	errorMessage = '';

	device: GetDevicesResponse | null = null;

  constructor(
    public dialogRef: MatDialogRef<RenameHomeFormComponent>,
    private fb: FormBuilder,
		private readonly HomeService: HomeService,
		@Inject(MAT_DIALOG_DATA) public data: { homeId: string }
  ) {
    this.form = this.fb.group({
      customName: [''],
    })}

		handleSubmit() {
			this.successMessage = '';
			this.errorMessage = '';
	
			const req: RenameHomeRequest = {
				alias: this.form.value.customName,
			}
	
			this.HomeService.renameHome(this.data.homeId, req).subscribe(
				res => this.successMessage = "Home renamed successfully",
				(err: APIError) => this.errorMessage = err.error.message,
			)
		}
	
		close(): void {
			this.dialogRef.close();
		}
}
