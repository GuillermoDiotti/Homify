import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../../../backend/services/admin/admin.service';
import UserBasicInfo from '../../../../backend/services/admin/models/UserBasicInfo';
import { DeleteAdminButtonComponent } from '../../buttons/delete-admin-button/delete-admin-button.component';

@Component({
  selector: 'app-accounts-list',
  standalone: true,
  imports: [DeleteAdminButtonComponent],
  templateUrl: './accounts-list.component.html',
  styleUrl: './accounts-list.component.css'
})
export class AccountsListComponent implements OnInit {
	accounts: UserBasicInfo[] = [];
	constructor(private AdminService: AdminService){}
	
	ngOnInit() {
		this.AdminService.getAllAccounts().subscribe(
			response => {
				this.accounts = response;
			},
			error => {
				console.error("Error creating admin", error);
			}
		)
	}

	handleRefresh() {
		this.AdminService.getAllAccounts().subscribe(
			response => {
				this.accounts = response;
			},
			error => {
				console.error("Error creating admin", error);
			}
		)
	}
}
