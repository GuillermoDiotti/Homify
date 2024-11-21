import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CompanyOwnerPageComponent } from './company-owner-page.component';
import { AdminGuard } from '../../guards/admin.guard';
import { CreateOwnerFormComponent } from '../../business-components/forms/create-owner-form/create-owner-form.component';

const routes: Routes = [
  { path: '', component: CompanyOwnerPageComponent, canActivate: [AdminGuard] }
];

@NgModule({
  declarations: [
    CompanyOwnerPageComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
		CreateOwnerFormComponent
  ]
})
export class CompanyOwnerPageModule { }