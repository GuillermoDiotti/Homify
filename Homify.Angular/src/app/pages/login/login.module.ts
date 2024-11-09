import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login.component';
import { ButtonComponent } from '../../components/button/button.component';
import { InputComponent } from '../../components/input/input.component';
import { LoginFormComponent } from '../../business-components/forms/login-form/login-form.component';
import { NonAuthGuard } from '../../guards/non-auth.guard';

const routes: Routes = [
  { path: '', component: LoginComponent, canActivate: [NonAuthGuard] },
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
