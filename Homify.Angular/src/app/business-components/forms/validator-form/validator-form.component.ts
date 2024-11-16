import { Component } from '@angular/core';
import { ImportService } from '../../../../backend/services/importer/Importer.service';
import { APIError } from '../../../../interfaces/interfaces';
import { CompanyService } from '../../../../backend/services/company/Company.service';
import AddValidatorBasicInfo from '../../../../backend/services/company/models/AddValidatorBasicInfo';
import { ButtonComponent } from '../../../components/button/button.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';

@Component({
  selector: 'app-validator-form',
  standalone: true,
  imports: [
    SuccessMessageComponent,
    ErrorMessageComponent,
		ButtonComponent,],
  templateUrl: './validator-form.component.html',
  styleUrl: './validator-form.component.css'
})
export class ValidatorFormComponent {
  successMessage = '';
  errorMessage = '';

  constructor(private ImportService: ImportService, private CompanyService: CompanyService) {
    
  }

  validators: string[] = [];
	selectedValidator = '';

  ngOnInit(): void {
    this.successMessage = '';
    this.errorMessage = '';

    this.ImportService.getValidators().subscribe(
      (res) => {
				this.validators = res;
				this.selectedValidator = res[0];
			},
      (err: APIError) => (this.errorMessage = err.error.message)
    );
  }

	handleRefreshValidators() {
		this.successMessage = '';
    this.errorMessage = '';

    this.ImportService.getValidators().subscribe(
      (res) => {
				this.validators = res;
				this.selectedValidator = res[0];
			},
      (err: APIError) => (this.errorMessage = err.error.message)
    );
	}

  handleSubmit() {
    this.successMessage = '';
    this.errorMessage = '';
    const req: AddValidatorBasicInfo = {
      model: this.selectedValidator
    };
      this.CompanyService.addValidator(req).subscribe(
        (response) => {
          this.successMessage = 'Validator added successfully';
        },
        (error: APIError) => {
          this.errorMessage = error.error.message;
        }
      );
  }

	onValidatorChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    this.selectedValidator = selectElement.value;
  }
}
