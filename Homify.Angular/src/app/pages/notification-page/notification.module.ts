import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { NotificationPageComponent } from './notification-page.component';
import { HomeOwnerGuard } from '../../guards/home-owner.guard';
import { NotificationListComponent } from '../../business-components/lists/notification-list/notification-list.component';

const routes: Routes = [
  { path: '', component: NotificationPageComponent, canActivate: [HomeOwnerGuard] },
];

@NgModule({
  declarations: [
		NotificationPageComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
		NotificationListComponent
  ]
})
export class NotificationModule { }