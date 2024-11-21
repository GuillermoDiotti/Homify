import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ButtonComponent } from '../button/button.component';
import { GetDevicesResponse } from '../../../backend/services/device/models/GetDevicesResponse';
import { AssingDeviceToRoomFormComponent } from '../../business-components/forms/assing-device-to-room-form/assing-device-to-room-form.component';

@Component({
  selector: 'app-assing-device-to-room-button',
  standalone: true,
  imports: [ButtonComponent],
  templateUrl: './assing-device-to-room-button.component.html',
  styleUrl: './assing-device-to-room-button.component.css'
})
export class AssingDeviceToRoomButtonComponent {
	@Input() device: GetDevicesResponse | null = null;
	@Input() homeId: string = '';

	constructor(public dialog: MatDialog) {}

	openModal(): void {
    this.dialog.open(AssingDeviceToRoomFormComponent, {
      data: { device: this.device, homeId: this.homeId }
    });
  }
}