import { Component, Input } from '@angular/core';
import { AdminService } from '../../../../backend/services/admin/admin.service';

@Component({
  selector: 'app-delete-admin-button',
  standalone: true,
  imports: [],
  templateUrl: './delete-admin-button.component.html',
  styleUrl: './delete-admin-button.component.css'
})
export class DeleteAdminButtonComponent {
	@Input() adminId: string = '';

	constructor(private AdminService: AdminService) {}

	handleClick() {
		this.AdminService.deleteAdmin(this.adminId).subscribe(
			resp => console.log(resp),
			err => console.error(err)
		)
	}
}
