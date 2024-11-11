import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CreateHomeComponent } from './create-home/create-home.component';
import { CreateHomeFormComponent } from '../../business-components/forms/create-home-form/create-home-form.component';
import { OwnerHomeListComponent } from '../../business-components/lists/owner-home-list/owner-home-list.component';
import { AddMemberComponent } from './add-member/add-member.component';
import { AddHomeMemberFormComponent } from '../../business-components/forms/add-home-member-form/add-home-member-form.component';
import { UpdateMembersPermissionsComponent } from './update-members-permissions/update-members-permissions.component';
import { UpdateMembersPermissionsFormComponent } from '../../business-components/forms/update-members-permissions-form/update-members-permissions-form.component';
import { HomeMemberListComponent } from '../../business-components/lists/home-member-list/home-member-list.component';
import { HomedevicesListComponent } from '../../business-components/lists/homedevices-list/homedevices-list.component';
import { HomedevicesComponent } from './homedevices/homedevices.component';
import { MemberHomeListComponent } from '../../business-components/lists/member-home-list/member-home-list.component';
import { HomeOwnerGuard } from '../../guards/home-owner.guard';
import { MakeUserNotificableFormComponent } from '../../business-components/forms/make-user-notificable-form/make-user-notificable-form.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';

const routes: Routes = [
  { path: 'create', component: CreateHomeComponent, canActivate: [HomeOwnerGuard] },
  { path: 'add-member', component: AddMemberComponent, canActivate: [HomeOwnerGuard] },
  { path: 'update-permissions', component: UpdateMembersPermissionsComponent, canActivate: [HomeOwnerGuard] },
	{ path: 'devices', component: HomedevicesComponent, canActivate: [HomeOwnerGuard] },
];

@NgModule({
  declarations: [CreateHomeComponent, AddMemberComponent, 
		UpdateMembersPermissionsComponent, HomedevicesComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    CreateHomeFormComponent,
    OwnerHomeListComponent,
    AddHomeMemberFormComponent,
    UpdateMembersPermissionsFormComponent,
    HomeMemberListComponent,
		HomedevicesListComponent,
		MemberHomeListComponent,
		MakeUserNotificableFormComponent,
		MatButtonModule,
    MatDialogModule,
		ReactiveFormsModule,
  ]
})
export class HomePageModule { }