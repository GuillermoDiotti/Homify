import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'admin', pathMatch: 'full', loadChildren: () => import('./business-components/admin/admin-page/admin.module').then(m => m.AdministratorModule)},
	{ path: 'login', pathMatch: 'full', loadChildren: () => import('./business-components/login/login.module').then(m => m.LoginModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }