import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ImportService } from '../../../../backend/services/importer/importer.service';
import { ImportRequest } from '../../../../backend/services/importer/models/ImportRequest';
import { APIError } from '../../../../interfaces/interfaces';
import { FormComponent } from '../../../components/form/form/form.component';
import { FormButtonComponent } from '../../../components/form/form-button/form-button.component';
import { FormInputComponent } from '../../../components/form/form-input/form-input.component';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { ButtonComponent } from '../../../components/button/button.component';

@Component({
  selector: 'app-import-devices-form',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    FormComponent,
    FormButtonComponent,
    FormInputComponent,
    SuccessMessageComponent,
    ErrorMessageComponent,
		ButtonComponent,
  ],
  templateUrl: './import-devices-form.component.html',
  styleUrl: './import-devices-form.component.css',
})
export class ImportDevicesFormComponent implements OnInit {
  form: FormGroup;
  successMessage = '';
  errorMessage = '';

  constructor(private fb: FormBuilder, private ImportService: ImportService) {
    this.form = this.fb.group({
      filePath: ['', [Validators.required]],
    });
  }

  importers: string[] = [];
	selectedImporter = '';

  ngOnInit(): void {
    this.successMessage = '';
    this.errorMessage = '';

    this.ImportService.getImporters().subscribe(
      (res) => {
				this.importers = res;
				this.selectedImporter = res[0];
			},
      (err: APIError) => (this.errorMessage = err.error.message)
    );
  }

	handleRefreshImporters() {
		this.successMessage = '';
    this.errorMessage = '';

    this.ImportService.getImporters().subscribe(
      (res) => (this.importers = res),
      (err: APIError) => (this.errorMessage = err.error.message)
    );
	}

  handleSubmit() {
    this.successMessage = '';
    this.errorMessage = '';
    if (this.form.valid) {
      const { filePath } = this.form.value;
      const req: ImportRequest = {
        importerSelected: this.selectedImporter,
        filePath,
      };

      this.ImportService.add(req).subscribe(
        (response) => {
          this.successMessage = 'Devices added successfully';
        },
        (error: APIError) => {
          this.errorMessage = error.error.message;
        }
      );
    } else {
      this.errorMessage = 'Form is invalid';
    }
  }

	onImporterChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    this.selectedImporter = selectElement.value;
  }
}
