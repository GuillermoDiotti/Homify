import { Component } from '@angular/core';
import { DeviceApiRepositoryService } from '../../../../backend/services/device/Device.service';
import { APIError } from '../../../../interfaces/interfaces';
import SearchDeviceResponse from '../../../../backend/services/device/models/SearchDeviceResponse';

@Component({
  selector: 'app-registered-devices-list',
  standalone: true,
  imports: [],
  templateUrl: './registered-devices-list.component.html',
  styleUrl: './registered-devices-list.component.css'
})
export class RegisteredDevicesListComponent {
	registeredDevices: SearchDeviceResponse[] = [];

	constructor(private readonly DeviceSevice: DeviceApiRepositoryService) {}

	ngOnInit(): void {
			this.DeviceSevice.getRegisteredDevices().subscribe(
				res => this.registeredDevices = res,
				(error: APIError) => console.error(error)
			)
	}

	handleRefresh() {
		this.DeviceSevice.getRegisteredDevices().subscribe(
			res => this.registeredDevices = res,
			(error: APIError) => console.error(error)
		)
	}
}
