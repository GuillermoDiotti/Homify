import { Component, Input } from '@angular/core';
import { GetDevicesResponse } from '../../../../backend/services/device/models/GetDevicesResponse';
import { HomeDeviceService } from '../../../../backend/services/homedevice/HomeDevice.service';
import { APIError } from '../../../../interfaces/interfaces';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { ButtonComponent } from '../../../components/button/button.component';

@Component({
  selector: 'app-turn-off-sensor-button',
  standalone: true,
  imports: [ButtonComponent, SuccessMessageComponent,
		ErrorMessageComponent
	],
  templateUrl: './turn-off-sensor-button.component.html',
  styleUrl: './turn-off-sensor-button.component.css'
})
export class TurnOffSensorButtonComponent {
	@Input() device: GetDevicesResponse | null = null;

	successMessage = '';
	errorMessage = '';

	constructor(private readonly HomeDeviceService: HomeDeviceService) {}

	handleTurnOnDevice() {
		this.successMessage = '';
		this.errorMessage = '';

		this.HomeDeviceService.turnOffSensor(this.device?.hardwareId ?? '').subscribe(
			res => this.successMessage = 'Sensor is now CLOSED',
			(err: APIError) => this.errorMessage = err.error.message,
		)
	}
}
