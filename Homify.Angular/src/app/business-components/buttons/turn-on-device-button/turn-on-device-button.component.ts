import { Component, Input } from '@angular/core';
import { ButtonComponent } from '../../../components/button/button.component';
import { GetDevicesResponse } from '../../../../backend/services/device/models/GetDevicesResponse';
import { DeviceService } from '../../../../backend/services/device/Device.service';
import { APIError } from '../../../../interfaces/interfaces';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { HomeDeviceService } from '../../../../backend/services/homedevice/HomeDevice.service';

@Component({
  selector: 'app-turn-on-device-button',
  standalone: true,
  imports: [ButtonComponent, SuccessMessageComponent, ErrorMessageComponent],
  templateUrl: './turn-on-device-button.component.html',
  styleUrl: './turn-on-device-button.component.css'
})
export class TurnOnDeviceButtonComponent {
	@Input() device: GetDevicesResponse | null = null;

	successMessage = '';
	errorMessage = '';

	constructor(private readonly HomeDeviceService: HomeDeviceService) {}

	handleTurnOnDevice() {
		this.successMessage = '';
		this.errorMessage = '';

		this.HomeDeviceService.turnOnDevice(this.device?.hardwareId ?? '').subscribe(
			res => this.successMessage = 'Device is now ON',
			(err: APIError) => this.errorMessage = err.error.message,
		)
	}
}
