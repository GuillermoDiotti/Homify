import { Component, Input } from '@angular/core';
import { GetDevicesResponse } from '../../../backend/services/device/models/GetDevicesResponse';
import { MatDialog } from '@angular/material/dialog';
import { RenameDeviceFormComponent } from '../../business-components/forms/rename-device-form/rename-device-form.component';
import { ButtonComponent } from '../button/button.component';

@Component({
  selector: 'app-rename-device-button',
  standalone: true,
  imports: [ButtonComponent],
  templateUrl: './rename-device-button.component.html',
  styleUrl: './rename-device-button.component.css'
})
export class RenameDeviceButtonComponent {
	@Input() device: GetDevicesResponse | null = null;

	constructor(public dialog: MatDialog) {}

	openModal(): void {
    this.dialog.open(RenameDeviceFormComponent, {
      data: { device: this.device }
    });
  }
}
