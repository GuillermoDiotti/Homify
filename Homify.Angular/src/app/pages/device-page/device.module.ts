import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DevicePageComponent } from './device-page.component';
import { CreateDeviceFormComponent } from '../../business-components/forms/create-device-form/create-device-form.component';
import { SupportedDevicesComponent } from './supported-devices/supported-devices.component';
import { AllDevicesComponent } from './all-devices/all-devices.component';
import { SupportedDevicesListComponent } from '../../business-components/lists/supported-devices-list/supported-devices-list.component';
import { RegisteredDevicesListComponent } from '../../business-components/lists/registered-devices-list/registered-devices-list.component';

const routes: Routes = [
  { path: '', component: DevicePageComponent },
	{ path: 'supported', component: SupportedDevicesComponent },
	{ path: 'all', component: AllDevicesComponent },
];

@NgModule({
  declarations: [DevicePageComponent, SupportedDevicesComponent, AllDevicesComponent],
  imports: [
    CommonModule,
		RouterModule.forChild(routes),
		CreateDeviceFormComponent,
		SupportedDevicesListComponent,
		RegisteredDevicesListComponent,
  ]
})
export class DevicePageModule { }