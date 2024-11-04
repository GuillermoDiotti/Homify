import { Component, EventEmitter, Input, Output } from '@angular/core';
import { DeviceApiRepositoryService } from '../../../../backend/services/device/Device.service';
import { APIError } from '../../../../interfaces/interfaces';
import SearchDeviceResponse from '../../../../backend/services/device/models/SearchDeviceResponse';
import { ButtonComponent } from '../../../components/button/button.component';

@Component({
  selector: 'app-registered-devices-list',
  standalone: true,
  imports: [ButtonComponent],
  templateUrl: './registered-devices-list.component.html',
  styleUrl: './registered-devices-list.component.css'
})
export class RegisteredDevicesListComponent {
	registeredDevices: SearchDeviceResponse[] = [];
	@Output() deviceEmitter = new EventEmitter<string>();
	deviceSelected = '';
	@Input() displayButtons = false;

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

	onDeviceClick(id: string) {
		this.deviceSelected = id;
		this.deviceEmitter.emit(this.deviceSelected)
	}
}
