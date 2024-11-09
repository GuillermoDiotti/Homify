import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CompanyListPageComponent } from './list/companyList-page.component';
import { CreateCompanyPageComponent } from './create/companyList-page.component';
import { CreateCompanyFormComponent } from '../../business-components/forms/create-companies-form/create-company-form.component';
import { CompaniesListComponent } from '../../business-components/lists/companies-list/companies-list.component';
import { AdminGuard } from '../../guards/admin.guard';
import { CompanyOwnerGuard } from '../../guards/company-owner.guard';

const routes: Routes = [
  { path: 'create', component: CreateCompanyPageComponent, canActivate: [CompanyOwnerGuard] },
  { path: 'list', component: CompanyListPageComponent, canActivate: [AdminGuard] }
];

@NgModule({
  declarations: [
    CompanyListPageComponent,
    CreateCompanyPageComponent,
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
		CreateCompanyFormComponent,
		CompaniesListComponent,
  ]
})
export class CompanyPageModule { }