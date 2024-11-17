import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DevicePageComponent } from './device-page.component';
import { CreateDeviceFormComponent } from '../../business-components/forms/create-device-form/create-device-form.component';
import { SupportedDevicesComponent } from './supported-devices/supported-devices.component';
import { AllDevicesComponent } from './all-devices/all-devices.component';
import { SupportedDevicesListComponent } from '../../business-components/lists/supported-devices-list/supported-devices-list.component';
import { RegisteredDevicesListComponent } from '../../business-components/lists/registered-devices-list/registered-devices-list.component';
import { AuthGuard } from '../../guards/auth.guard';
import { CompanyOwnerGuard } from '../../guards/company-owner.guard';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';

const routes: Routes = [
  { path: '', component: DevicePageComponent, canActivate: [CompanyOwnerGuard] },
	{ path: 'supported', component: SupportedDevicesComponent, canActivate: [AuthGuard] },
	{ path: 'all', component: AllDevicesComponent, canActivate: [AuthGuard] },
];

@NgModule({
  declarations: [DevicePageComponent, SupportedDevicesComponent, AllDevicesComponent],
  imports: [
    CommonModule,
		RouterModule.forChild(routes),
		CreateDeviceFormComponent,
		SupportedDevicesListComponent,
		RegisteredDevicesListComponent,
		MatButtonModule,
    MatDialogModule,
  ],
})
export class DevicePageModule { }