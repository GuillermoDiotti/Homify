import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login.component';
import { ButtonComponent } from '../../components/button/button.component';
import { InputComponent } from '../../components/input/input.component';
import { LoginFormComponent } from '../../business-components/forms/login-form/login-form.component';

const routes: Routes = [
  { path: '', component: LoginComponent, canActivate: [] },
];

@NgModule({
  declarations: [
    LoginComponent,
  ],
  imports: [
		ButtonComponent,
		InputComponent,
		LoginFormComponent,
    CommonModule,
    RouterModule.forChild(routes),
  ]
})
export class LoginModule { }
