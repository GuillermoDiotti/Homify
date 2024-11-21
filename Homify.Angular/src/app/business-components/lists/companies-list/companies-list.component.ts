import { Component, OnInit } from '@angular/core';
import { CompanyService } from '../../../../backend/services/company/Company.service';
import CompanyBasicInfo from '../../../../backend/services/company/models/CompanyBasicInfo';
import { PaginationComponent } from '../../../components/pagination/pagination.component';

@Component({
  selector: 'app-companies-list',
  standalone: true,
  imports: [PaginationComponent],
  templateUrl: './companies-list.component.html',
  styleUrl: './companies-list.component.css'
})
export class CompaniesListComponent implements OnInit {
	companies: CompanyBasicInfo[] = [];

	constructor(private CompanyService: CompanyService){}

	limit = 10;
  offset = 0;
	ownerFullnameFilter = '';
	companyFilter = '';

  updateLimit(newLimit: number) {
    this.limit = newLimit;
  }

  updateOffset(newOffset: number) {
    this.offset = newOffset;
  }

	onCompanyChange(event: Event) {
		this.companyFilter = (event.target as HTMLInputElement).value;
	}

	onOwnerFullnameChange(event: Event) {
		this.ownerFullnameFilter = (event.target as HTMLInputElement).value;
	}

	ngOnInit() {
		this.CompanyService.getAllCompanies(this.limit.toString(), this.offset.toString(), this.ownerFullnameFilter, this.companyFilter).subscribe(
			response => {
				this.companies = response;
			},
			error => {
				console.error("Error listing companies", error);
			}
		)
	}

	handleRefresh() {
		this.CompanyService.getAllCompanies(this.limit.toString(), this.offset.toString(), this.ownerFullnameFilter, this.companyFilter).subscribe(
			response => {
				this.companies = response;
			},
			error => {
				console.error("Error listing companies", error);
			}
		)
	}
}
