import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AutheticationPageComponent } from './authetication-page/authetication-page.component';
import { FormButtonComponent } from '../components/form/form-button/form-button.component';
import { FormInputComponent } from '../components/form/form-input/form-input.component';
import { FormComponent } from '../components/form/form/form.component';



@NgModule({
  declarations: [AutheticationPageComponent],
  imports: [
    CommonModule,
    FormComponent,
    FormInputComponent,
    FormButtonComponent
  ]
})
export class AuthenticationModule { }
