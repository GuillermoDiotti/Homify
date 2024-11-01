import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CreateHomeComponent } from './create-home/create-home.component';
import { CreateHomeFormComponent } from '../../business-components/forms/create-home-form/create-home-form.component';

const routes: Routes = [
  { path: 'create', component: CreateHomeComponent },
];

@NgModule({
  declarations: [CreateHomeComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    CreateHomeFormComponent
  ]
})
export class HomePageModule { }