import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CompanyListPageComponent } from './list/companyList-page.component';
import { CreateCompanyPageComponent } from './create/companyList-page.component';
import { CreateCompanyFormComponent } from '../../business-components/forms/create-companies-form/create-company-form.component';
import { CompaniesListComponent } from '../../business-components/lists/companies-list/companies-list.component';

const routes: Routes = [
  { path: '', component: CompanyListPageComponent },
  { path: 'create', component: CreateCompanyPageComponent },
  { path: 'list', component: CompanyListPageComponent }
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