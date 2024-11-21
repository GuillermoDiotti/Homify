import { Component, OnInit } from '@angular/core';
import { ImportService } from '../../../../backend/services/importer/Importer.service';
import { ImportRequest } from '../../../../backend/services/importer/models/ImportRequest';
import { APIError } from '../../../../interfaces/interfaces';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { ButtonComponent } from '../../../components/button/button.component';
import { take } from 'rxjs';
import { InputComponent } from '../../../components/input/input.component';

@Component({
  selector: 'app-import-devices-form',
  standalone: true,
  imports: [
    SuccessMessageComponent,
    ErrorMessageComponent,
		ButtonComponent,
		InputComponent
  ],
  templateUrl: './import-devices-form.component.html',
  styleUrl: './import-devices-form.component.css',
})
export class ImportDevicesFormComponent implements OnInit {
  successMessage = '';
  errorMessage = '';
	importPath = 'C:/Users/Juan/Desktop/devices2.json';

  constructor(private ImportService: ImportService) {}

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
      const req: ImportRequest = {
        importerSelected: this.selectedImporter,
        filePath: this.importPath,
      };

      this.ImportService.addImportedDevices(req).subscribe(
        (response) => {
          this.successMessage = 'Devices added successfully';
        },
        (error: APIError) => {
          this.errorMessage = error.error.message;
        }
      );
  }

	onImporterChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    this.selectedImporter = selectElement.value;
  }

	onPathChange(event: Event) {
		this.importPath = (event.target as HTMLInputElement).value;
	}
}
