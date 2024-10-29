import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AdminPageComponent } from './admin-page.component';
import { CreateAdminFormComponent } from '../../business-components/forms/create-admin-form/create-admin-form.component';

const routes: Routes = [
  { path: '', component: AdminPageComponent },
];

@NgModule({
  declarations: [AdminPageComponent],
  imports: [
		CommonModule,
    RouterModule.forChild(routes),
		CreateAdminFormComponent,
  ]
})
export class AdministratorModule { }
