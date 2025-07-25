import { Component, Input, OnInit } from '@angular/core';
import { GetDevicesResponse } from '../../../../backend/services/device/models/GetDevicesResponse';
import { HomeService } from '../../../../backend/services/homes/home.service';
import { APIError } from '../../../../interfaces/interfaces';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { UpdateHomeDevicesRequest } from '../../../../backend/services/homes/models/UpdateHomeDevicesRequest';
import { RegisteredDevicesListComponent } from '../registered-devices-list/registered-devices-list.component';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';
import { TurnOnDeviceButtonComponent } from '../../buttons/turn-on-device-button/turn-on-device-button.component';
import { RenameDeviceButtonComponent } from '../../../components/rename-device-button/rename-device-button.component';
import { TurnOffDeviceButtonComponent } from '../../buttons/turn-off-device-button/turn-off-device-button.component';
import { InputComponent } from '../../../components/input/input.component';
import { ButtonComponent } from '../../../components/button/button.component';
import { AssingDeviceToRoomButtonComponent } from '../../../components/assing-device-to-room-button/assing-device-to-room-button.component';
import { TurnOnLampButtonComponent } from '../../buttons/turn-on-lamp-button/turn-on-lamp-button.component';
import { TurnOffLampButtonComponent } from '../../buttons/turn-off-lamp-button/turn-off-lamp-button.component';
import { CommonModule } from '@angular/common';
import { TurnOnSensorButtonComponent } from '../../buttons/turn-on-sensor-button/turn-on-sensor-button.component';
import { TurnOffSensorButtonComponent } from '../../buttons/turn-off-sensor-button/turn-off-sensor-button.component';

@Component({
  selector: 'app-homedevices-list',
  standalone: true,
  imports: [CommonModule, ErrorMessageComponent, SuccessMessageComponent, 
		RegisteredDevicesListComponent, TurnOnDeviceButtonComponent, 
		RenameDeviceButtonComponent, TurnOffDeviceButtonComponent,
		InputComponent, ButtonComponent, AssingDeviceToRoomButtonComponent,
		TurnOnLampButtonComponent, TurnOffLampButtonComponent,
		TurnOnSensorButtonComponent, TurnOffSensorButtonComponent
	],
  templateUrl: './homedevices-list.component.html',
  styleUrl: './homedevices-list.component.css'
})
export class HomedevicesListComponent implements OnInit{
	homeDevices: GetDevicesResponse[] = [];
	@Input() homeId = "";
	filterByRoom = '';
	errorMessage = '';
	successMessage = '';

	constructor(private readonly HomeService: HomeService) {}

	ngOnInit(): void {
		this.errorMessage = '';
		this.successMessage = '';
		this.HomeService.getHomeDevices(this.homeId, this.filterByRoom).subscribe(
			res => {
				this.homeDevices = res;
			},
			(error: APIError) => this.errorMessage = error.error.message,
		)
	}

	handleRefresh() {
		this.errorMessage = '';
		this.successMessage = '';
		this.HomeService.getHomeDevices(this.homeId, this.filterByRoom).subscribe(
			res => {
				this.homeDevices = res;
			},
			(error: APIError) => this.errorMessage = error.error.message,
		)
	}

	handleAddNewDevice(id: string) {
		this.errorMessage = '';
		this.successMessage = '';

		const req: UpdateHomeDevicesRequest = {
			deviceId: id,
		}

		this.HomeService.addNewDevice(this.homeId, req).subscribe(
			res => this.successMessage = "Device added to selected home",
			(error: APIError) => this.errorMessage = error.error.message,
		)
	}

	handleFilterChange(event: Event) {
		this.filterByRoom = (event.target as HTMLInputElement).value;
	}
}
