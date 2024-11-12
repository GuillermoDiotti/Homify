import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ImportService } from '../../../../backend/services/importer/importer.service';
import { ImportRequest } from '../../../../backend/services/importer/models/ImportRequest';
import { APIError } from '../../../../interfaces/interfaces';
import { FormComponent } from '../../../components/form/form/form.component';
import { FormButtonComponent } from '../../../components/form/form-button/form-button.component';
import { FormInputComponent } from '../../../components/form/form-input/form-input.component';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';

@Component({
  selector: 'app-import-devices-form',
  standalone: true,
  imports: [ReactiveFormsModule, FormComponent, FormButtonComponent, FormInputComponent,
		SuccessMessageComponent, ErrorMessageComponent],
  templateUrl: './import-devices-form.component.html',
  styleUrl: './import-devices-form.component.css'
})
export class ImportDevicesFormComponent {
  form: FormGroup;
	successMessage = '';
	errorMessage = '';

  constructor(private fb: FormBuilder, private ImportService: ImportService) {
    this.form = this.fb.group({
      importerSelected: ["", [Validators.required]],
      filePath: ["", [Validators.required]],  
    });
  }

  handleSubmit() {
		this.successMessage = '';
		this.errorMessage = '';
    if (this.form.valid) {
      const { importerSelected, filePath } = this.form.value;
      const req: ImportRequest = {
        importerSelected,
        filePath
      };

      this.ImportService.add(req).subscribe(
        response => {
         	this.successMessage = "Devices added successfully";
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
