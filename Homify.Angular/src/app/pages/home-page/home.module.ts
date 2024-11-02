import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CreateHomeComponent } from './create-home/create-home.component';
import { CreateHomeFormComponent } from '../../business-components/forms/create-home-form/create-home-form.component';
import { OwnerHomeListComponent } from '../../business-components/lists/owner-home-list/owner-home-list.component';
import { AddMemberComponent } from './add-member/add-member.component';

const routes: Routes = [
  { path: 'create', component: CreateHomeComponent },
  { path: 'add-member', component: AddMemberComponent },

];

@NgModule({
  declarations: [CreateHomeComponent, AddMemberComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    CreateHomeFormComponent,
    OwnerHomeListComponent
  ]
})
export class HomePageModule { }