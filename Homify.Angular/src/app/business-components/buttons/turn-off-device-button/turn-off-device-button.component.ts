import { Component, Input } from '@angular/core';
import { GetDevicesResponse } from '../../../../backend/services/device/models/GetDevicesResponse';
import { DeviceService } from '../../../../backend/services/device/Device.service';
import { APIError } from '../../../../interfaces/interfaces';
import { ButtonComponent } from '../../../components/button/button.component';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';

@Component({
  selector: 'app-turn-off-device-button',
  standalone: true,
  imports: [ButtonComponent, SuccessMessageComponent, ErrorMessageComponent],
  templateUrl: './turn-off-device-button.component.html',
  styleUrl: './turn-off-device-button.component.css'
})
export class TurnOffDeviceButtonComponent {
	@Input() device: GetDevicesResponse | null = null;

	successMessage = '';
	errorMessage = '';

	constructor(private readonly DeviceService: DeviceService) {}

	handleTurnOnDevice() {
		this.successMessage = '';
		this.errorMessage = '';

		this.DeviceService.turnOffDevice(this.device?.hardwareId ?? '').subscribe(
			res => this.successMessage = 'Device is now OFF',
			(err: APIError) => this.errorMessage = err.error.message,
		)
	}
}
