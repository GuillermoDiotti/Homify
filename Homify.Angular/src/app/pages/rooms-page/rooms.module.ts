import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeOwnerGuard } from '../../guards/home-owner.guard';
import { RoomsPageComponent } from './rooms-page.component';

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
  ],
})
export class RoomPageModule { }