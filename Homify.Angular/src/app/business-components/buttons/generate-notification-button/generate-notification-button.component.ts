import { Component, Input } from '@angular/core';
import { ButtonComponent } from '../../../components/button/button.component';
import { GenerateNotificationFormComponent } from '../../forms/generate-notification-form/generate-notification-form.component';
import { MatDialog } from '@angular/material/dialog';
import { GetDevicesResponse } from '../../../../backend/services/device/models/GetDevicesResponse';

@Component({
  selector: 'app-generate-notification-button',
  standalone: true,
  imports: [ButtonComponent, GenerateNotificationFormComponent],
  templateUrl: './generate-notification-button.component.html',
  styleUrl: './generate-notification-button.component.css'
})
export class GenerateNotificationButtonComponent {

	@Input() device: GetDevicesResponse | null = null;

	constructor(public dialog: MatDialog) {}

  openModal(): void {
    this.dialog.open(GenerateNotificationFormComponent, {
      data: { device: this.device }
    });
  }
}
