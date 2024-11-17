import { Component, Input } from '@angular/core';
import { GetDevicesResponse } from '../../../../backend/services/device/models/GetDevicesResponse';
import { MatDialog } from '@angular/material/dialog';
import { AssingDeviceToRoomFormComponent } from '../../forms/assing-device-to-room-form/assing-device-to-room-form.component';
import { ButtonComponent } from '../../../components/button/button.component';

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