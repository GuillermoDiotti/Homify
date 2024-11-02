import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DevicePageComponent } from './device-page.component';

const routes: Routes = [
  { path: '', component: DevicePageComponent },
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
		RouterModule.forChild(routes),
  ]
})
export class DevicePageModule { }