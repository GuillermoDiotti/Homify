import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'admin', loadChildren: () => import('./pages/admin-page/admin.module').then(m => m.AdministratorModule)},
	{ path: 'login', pathMatch: 'full', loadChildren: () => import('./pages/login/login.module').then(m => m.LoginModule) },
	{ path: 'register', pathMatch: 'full', loadChildren: () => import('./pages/register/register.module').then(m => m.RegisterModule) },
  { path: 'companies', loadChildren: () => import('./pages/company-page/company.module').then(m => m.CompanyPageModule) },
  { path: 'devices', loadChildren: () => import('./pages/device-page/device.module').then(m => m.DevicePageModule) },
	{ path: 'homes', loadChildren: () => import('./pages/home-page/home.module').then(m => m.HomePageModule)},
  { path: '**', pathMatch: 'full', loadChildren: () => import('./pages/login/login.module').then(m => m.LoginModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
	export class AppRoutingModule { }