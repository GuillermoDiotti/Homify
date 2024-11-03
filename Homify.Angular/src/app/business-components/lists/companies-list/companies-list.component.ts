import { Component, OnInit } from '@angular/core';
import { CompanyService } from '../../../../backend/services/company/Company.service';
import UserBasicInfo from '../../../../backend/services/admin/models/UserBasicInfo';
import { DeleteAdminButtonComponent } from '../../buttons/delete-admin-button/delete-admin-button.component';
import CompanyBasicInfo from '../../../../backend/services/company/models/CompanyBasicInfo';

@Component({
  selector: 'app-companies-list',
  standalone: true,
  imports: [],
  templateUrl: './companies-list.component.html',
  styleUrl: './companies-list.component.css'
})
export class CompaniesListComponent implements OnInit {
	companies: CompanyBasicInfo[] = [];
	limit = '10';
  	offset = '0';
	constructor(private CompanyService: CompanyService){}

	ngOnInit() {
		this.CompanyService.getAllCompanies(this.limit, this.offset).subscribe(
			response => {
				this.companies = response;
			},
			error => {
				console.error("Error listing companies", error);
			}
		)
	}

	handleRefresh() {
		this.CompanyService.getAllCompanies(this.limit, this.offset).subscribe(
			response => {
				this.companies = response;
			},
			error => {
				console.error("Error listing companies", error);
			}
		)
	}
}
