import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'admin', pathMatch: 'full', loadChildren: () => import('./admin/admin.module').then(m => m.AdministratorModule)},
	{ path: 'login', pathMatch: 'full', loadChildren: () => import('../app/authentication/authetication-page/authetication-page.component').then(m => m.AutheticationPageComponent) },
  { path: '', pathMatch: 'full', loadChildren: () => import('./authentication/authetication-page/login/login.module').then(m => m.LoginModule) },
  { path: '**', pathMatch: 'full', loadChildren: () => import('./authentication/authetication-page/login/login.module').then(m => m.LoginModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }