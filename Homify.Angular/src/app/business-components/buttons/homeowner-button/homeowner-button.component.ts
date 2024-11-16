import { Component } from '@angular/core';
import { ButtonComponent } from '../../../components/button/button.component';
import { RoleService } from '../../../../backend/services/roles/Role.service';
import { APIError } from '../../../../interfaces/interfaces';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';

@Component({
  selector: 'app-homeowner-button',
  standalone: true,
  imports: [ButtonComponent, SuccessMessageComponent, ErrorMessageComponent],
  templateUrl: './homeowner-button.component.html',
  styleUrl: './homeowner-button.component.css'
})
export class HomeownerButtonComponent {
	errorMessage = '';
	successMessage = '';

	constructor (private readonly RoleService: RoleService) {}

	onClick() {
		this.errorMessage = '';
		this.successMessage = '';

		this.RoleService.addRoleToExistingUser().subscribe(
			res => this.successMessage = "New role added successfully",
			(err: APIError) => this.errorMessage = err.error.message,
		)
	}

}
