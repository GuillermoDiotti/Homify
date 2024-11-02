import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DevicePageComponent } from './device-page.component';
import { CreateDeviceFormComponent } from '../../business-components/forms/create-device-form/create-device-form.component';

const routes: Routes = [
  { path: '', component: DevicePageComponent },
];

@NgModule({
  declarations: [DevicePageComponent],
  imports: [
    CommonModule,
		RouterModule.forChild(routes),
		CreateDeviceFormComponent,
  ]
})
export class DevicePageModule { }