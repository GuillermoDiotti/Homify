import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../../../backend/services/admin/admin.service';
import UserBasicInfo from '../../../../backend/services/admin/models/UserBasicInfo';
import { DeleteAdminButtonComponent } from '../../buttons/delete-admin-button/delete-admin-button.component';
import { InputComponent } from '../../../components/input/input.component';
import { PaginationComponent } from '../../../components/pagination/pagination.component';

@Component({
  selector: 'app-accounts-list',
  standalone: true,
  imports: [DeleteAdminButtonComponent, InputComponent, PaginationComponent],
  templateUrl: './accounts-list.component.html',
  styleUrl: './accounts-list.component.css'
})
export class AccountsListComponent implements OnInit {
	accounts: UserBasicInfo[] = [];
	filterByRole = '';
	filterByFullName = '';
	userId = '';
	constructor(private AdminService: AdminService){}

	limit = 10;
  offset = 0;

  updateLimit(newLimit: number) {
    this.limit = newLimit;
  }

  updateOffset(newOffset: number) {
    this.offset = newOffset;
  }
	
	ngOnInit() {
		this.userId = localStorage.getItem('userId') ?? '';
		this.AdminService.getAllAccounts().subscribe(
			response => {
				this.accounts = response;
			},
			error => {
				console.error("Error creating admin", error);
			}
		)
	}

	onRoleChange(event: Event) {
		const selectElement = event.target as HTMLSelectElement;
		this.filterByRole = selectElement.value;
	}

	onFullNameChange(event: Event) {
		this.filterByFullName = (event.target as HTMLInputElement).value;
	}	

	handleRefresh() {
		this.AdminService.getAllAccounts(this.limit.toString(), this.offset.toString(), this.filterByRole, this.filterByFullName).subscribe(
			response => {
				this.accounts = response;
			},
			error => {
				console.error("Error creating admin", error);
			}
		)
	}
}
