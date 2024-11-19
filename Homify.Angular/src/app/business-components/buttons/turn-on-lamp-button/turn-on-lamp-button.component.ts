import { Component, Input } from '@angular/core';
import { GetDevicesResponse } from '../../../../backend/services/device/models/GetDevicesResponse';
import { HomeDeviceService } from '../../../../backend/services/homedevice/HomeDevice.service';
import { APIError } from '../../../../interfaces/interfaces';
import { ButtonComponent } from '../../../components/button/button.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';

@Component({
  selector: 'app-turn-on-lamp-button',
  standalone: true,
  imports: [ButtonComponent, ErrorMessageComponent, SuccessMessageComponent],
  templateUrl: './turn-on-lamp-button.component.html',
  styleUrl: './turn-on-lamp-button.component.css'
})
export class TurnOnLampButtonComponent {
	@Input() device: GetDevicesResponse | null = null;

	successMessage = '';
	errorMessage = '';

	constructor(private readonly HomeDeviceService: HomeDeviceService) {}

	handleTurnOnDevice() {
		this.successMessage = '';
		this.errorMessage = '';

		this.HomeDeviceService.turnOnLamp(this.device?.hardwareId ?? '').subscribe(
			res => this.successMessage = 'Lamp is now ON',
			(err: APIError) => this.errorMessage = err.error.message,
		)
	}
}
