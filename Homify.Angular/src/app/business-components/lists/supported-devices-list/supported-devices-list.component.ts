import { Component, OnInit } from '@angular/core';
import { DeviceApiRepositoryService } from '../../../../backend/services/device/Device.service';
import { APIError } from '../../../../interfaces/interfaces';
import SearchSupportedDevicesResponse from '../../../../backend/services/device/models/SearchSupportedDevicesResponse';

@Component({
  selector: 'app-supported-devices-list',
  standalone: true,
  imports: [],
  templateUrl: './supported-devices-list.component.html',
  styleUrl: './supported-devices-list.component.css'
})
export class SupportedDevicesListComponent implements OnInit {
	supportedDevices: SearchSupportedDevicesResponse[] = [];

	constructor(private readonly DeviceSevice: DeviceApiRepositoryService) {}

	ngOnInit(): void {
			this.DeviceSevice.getSupportedDevices().subscribe(
				res => this.supportedDevices = res,
				(error: APIError) => console.error(error)
			)
	}

	handleRefresh() {
		this.DeviceSevice.getSupportedDevices().subscribe(
			res => this.supportedDevices = res,
			(error: APIError) => console.error(error)
		)
	}
}
