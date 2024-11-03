import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ButtonComponent } from '../../components/button/button.component';
import { InputComponent } from '../../components/input/input.component';
import { RegisterComponent } from './register.component';
import { RegisterFormComponent } from '../../business-components/forms/register-form/register-form.component';

const routes: Routes = [
  { path: '', component: RegisterComponent },
];

@NgModule({
  declarations: [
    RegisterComponent,
  ],
  imports: [
		ButtonComponent,
		InputComponent,
		RegisterFormComponent,
    CommonModule,
    RouterModule.forChild(routes),
  ]
})
export class RegisterModule { }
