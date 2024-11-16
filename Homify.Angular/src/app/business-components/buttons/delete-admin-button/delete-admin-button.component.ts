import { Component, Input } from '@angular/core';
import { AdminService } from '../../../../backend/services/admin/admin.service';
import { APIError } from '../../../../interfaces/interfaces';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';

@Component({
  selector: 'app-delete-admin-button',
  standalone: true,
  imports: [SuccessMessageComponent, ErrorMessageComponent],
  templateUrl: './delete-admin-button.component.html',
  styleUrl: './delete-admin-button.component.css'
})
export class DeleteAdminButtonComponent {
	@Input() adminId: string = '';

	constructor(private AdminService: AdminService) {}
	errorMessage = '';
	successMessage = '';

	handleClick() {
		this.AdminService.deleteAdmin(this.adminId).subscribe(
			resp => this.successMessage = 'Admin deleted successfully',
			(err: APIError) => this.errorMessage = err.error.message,
		)
	}
}
