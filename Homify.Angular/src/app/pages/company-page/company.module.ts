import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CompanyListPageComponent } from './list/companyList-page.component';
import { CreateCompanyFormComponent } from '../../business-components/forms/create-companies-form/create-company-form.component';
import { CompaniesListComponent } from '../../business-components/lists/companies-list/companies-list.component';
import { CreateCompanyPageComponent } from './create/companyList-page.component';

const routes: Routes = [
  { path: 'companies/create', component: CreateCompanyPageComponent },
  { path: 'get', component: CompanyListPageComponent }
];

@NgModule({
  declarations: [CompanyListPageComponent, CreateCompanyPageComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    CreateCompanyFormComponent,
    CompaniesListComponent
  ]
})
export class CompanyPageModule { }
