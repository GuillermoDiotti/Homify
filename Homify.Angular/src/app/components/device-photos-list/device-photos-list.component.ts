import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import SearchDeviceResponse from '../../../backend/services/device/models/SearchDeviceResponse';

@Component({
  selector: 'app-device-photos-list',
  standalone: true,
  imports: [],
  templateUrl: './device-photos-list.component.html',
  styleUrl: './device-photos-list.component.css',
})
export class DevicePhotosListComponent {
  constructor(
    public dialogRef: MatDialogRef<DevicePhotosListComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { device: SearchDeviceResponse | null }
  ) {}
}
