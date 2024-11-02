import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CreateHomeComponent } from './create-home/create-home.component';
import { CreateHomeFormComponent } from '../../business-components/forms/create-home-form/create-home-form.component';
import { OwnerHomeListComponent } from '../../business-components/lists/owner-home-list/owner-home-list.component';
import { AddMemberComponent } from './add-member/add-member.component';
import { AddHomeMemberFormComponent } from '../../business-components/forms/add-home-member-form/add-home-member-form.component';
import { UpdateMembersPermissionsComponent } from './update-members-permissions/update-members-permissions.component';

const routes: Routes = [
  { path: 'create', component: CreateHomeComponent },
  { path: 'add-member', component: AddMemberComponent },
];

@NgModule({
  declarations: [CreateHomeComponent, AddMemberComponent, UpdateMembersPermissionsComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    CreateHomeFormComponent,
    OwnerHomeListComponent,
    AddHomeMemberFormComponent,
  ]
})
export class HomePageModule { }