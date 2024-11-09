import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AdminPageComponent } from './admin-page.component';
import { CreateAdminFormComponent } from '../../business-components/forms/create-admin-form/create-admin-form.component';
import { AccountsListComponent } from '../../business-components/lists/accounts-list/accounts-list.component';
import { AdminGuard } from '../../guards/admin.guard';

const routes: Routes = [
  { path: '', component: AdminPageComponent, canActivate: [AdminGuard] },
];

@NgModule({
  declarations: [AdminPageComponent],
  imports: [
		CommonModule,
    RouterModule.forChild(routes),
		CreateAdminFormComponent,
		AccountsListComponent,
  ]
})
export class AdministratorModule { }
