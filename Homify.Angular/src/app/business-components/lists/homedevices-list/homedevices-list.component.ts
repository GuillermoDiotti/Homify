import { Component, Input, OnInit } from '@angular/core';
import { GetDevicesResponse } from '../../../../backend/services/device/models/GetDevicesResponse';
import { HomeService } from '../../../../backend/services/homes/home.service';
import { APIError } from '../../../../interfaces/interfaces';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { UpdateHomeDevicesRequest } from '../../../../backend/services/homes/models/UpdateHomeDevicesRequest';
import { RegisteredDevicesListComponent } from '../registered-devices-list/registered-devices-list.component';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';

@Component({
  selector: 'app-homedevices-list',
  standalone: true,
  imports: [ErrorMessageComponent, SuccessMessageComponent,RegisteredDevicesListComponent],
  templateUrl: './homedevices-list.component.html',
  styleUrl: './homedevices-list.component.css'
})
export class HomedevicesListComponent implements OnInit{
	homeDevices: GetDevicesResponse[] = [];
	@Input() homeId = "";
	errorMessage = '';
	successMessage = '';
	selectedDeviceId = '';

	constructor(private readonly HomeService: HomeService) {}

	ngOnInit(): void {
		this.errorMessage = '';
		this.successMessage = '';
		this.HomeService.getHomeDevices(this.homeId).subscribe(
			res => {
				this.homeDevices = res;
			},
			(error: APIError) => this.errorMessage = error.error.message,
		)
	}

	handleRefresh() {
		this.errorMessage = '';
		this.successMessage = '';
		this.HomeService.getHomeDevices(this.homeId).subscribe(
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
}
