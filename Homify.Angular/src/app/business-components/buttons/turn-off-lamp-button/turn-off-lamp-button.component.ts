import { Component, Input } from '@angular/core';
import { GetDevicesResponse } from '../../../../backend/services/device/models/GetDevicesResponse';
import { HomeDeviceService } from '../../../../backend/services/homedevice/HomeDevice.service';
import { APIError } from '../../../../interfaces/interfaces';
import { ButtonComponent } from '../../../components/button/button.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';

@Component({
  selector: 'app-turn-off-lamp-button',
  standalone: true,
  imports: [ButtonComponent, ErrorMessageComponent, SuccessMessageComponent],
  templateUrl: './turn-off-lamp-button.component.html',
  styleUrl: './turn-off-lamp-button.component.css'
})
export class TurnOffLampButtonComponent {
	@Input() device: GetDevicesResponse | null = null;

	successMessage = '';
	errorMessage = '';

	constructor(private readonly HomeDeviceService: HomeDeviceService) {}

	handleTurnOnDevice() {
		this.successMessage = '';
		this.errorMessage = '';

		this.HomeDeviceService.turnOffLamp(this.device?.hardwareId ?? '').subscribe(
			res => this.successMessage = 'Lamp is now OFF',
			(err: APIError) => this.errorMessage = err.error.message,
		)
	}
}
