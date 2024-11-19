import { Component, Input } from '@angular/core';
import { GetDevicesResponse } from '../../../../backend/services/device/models/GetDevicesResponse';
import { HomeDeviceService } from '../../../../backend/services/homedevice/HomeDevice.service';
import { APIError } from '../../../../interfaces/interfaces';
import { ButtonComponent } from '../../../components/button/button.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';

@Component({
  selector: 'app-turn-on-sensor-button',
  standalone: true,
  imports: [ButtonComponent, ErrorMessageComponent, SuccessMessageComponent],
  templateUrl: './turn-on-sensor-button.component.html',
  styleUrl: './turn-on-sensor-button.component.css'
})
export class TurnOnSensorButtonComponent {
	@Input() device: GetDevicesResponse | null = null;

	successMessage = '';
	errorMessage = '';

	constructor(private readonly HomeDeviceService: HomeDeviceService) {}

	handleTurnOnDevice() {
		this.successMessage = '';
		this.errorMessage = '';

		this.HomeDeviceService.turnOnSensor(this.device?.hardwareId ?? '').subscribe(
			res => this.successMessage = 'Sensor is now OPEN',
			(err: APIError) => this.errorMessage = err.error.message,
		)
	}
}
