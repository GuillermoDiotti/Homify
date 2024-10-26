import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeOwnerPageComponent } from './home-owner-page.component';

const routes: Routes = [
  { path: '', component: HomeOwnerPageComponent },
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
		RouterModule.forChild(routes),
  ]
})
export class HomeOwnerModule { }
