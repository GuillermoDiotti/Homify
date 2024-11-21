import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeOwnerGuard } from '../../guards/home-owner.guard';
import { RoomsPageComponent } from './rooms-page.component';
import { OwnerHomeListComponent } from '../../business-components/lists/owner-home-list/owner-home-list.component';
import { AddRoomsFormComponent } from '../../business-components/forms/add-rooms-form/add-rooms-form.component';

const routes: Routes = [
  { path: '', component: RoomsPageComponent, canActivate: [HomeOwnerGuard] },
];

@NgModule({
  declarations: [
		RoomsPageComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
		OwnerHomeListComponent,
		AddRoomsFormComponent,
  ],
})
export class RoomPageModule { }