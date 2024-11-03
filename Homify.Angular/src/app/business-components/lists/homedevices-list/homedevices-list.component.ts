import { Component, Input, OnInit } from '@angular/core';
import { GetDevicesResponse } from '../../../../backend/services/device/models/GetDevicesResponse';
import { HomeService } from '../../../../backend/services/homes/home.service';
import { APIError } from '../../../../interfaces/interfaces';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';

@Component({
  selector: 'app-homedevices-list',
  standalone: true,
  imports: [ErrorMessageComponent],
  templateUrl: './homedevices-list.component.html',
  styleUrl: './homedevices-list.component.css'
})
export class HomedevicesListComponent implements OnInit{
	homeDevices: GetDevicesResponse[] = [];
	@Input() homeId = "";
	errorMessage = '';

	constructor(private readonly HomeService: HomeService) {}

	ngOnInit(): void {
		this.errorMessage = '';
		this.HomeService.getHomeDevices(this.homeId).subscribe(
			res => {
				this.homeDevices = res;
			},
			(error: APIError) => this.errorMessage = error.error.message,
		)
	}

	handleRefresh() {
		this.errorMessage = '';
		this.HomeService.getHomeDevices(this.homeId).subscribe(
			res => {
				this.homeDevices = res;
			},
			(error: APIError) => this.errorMessage = error.error.message,
		)
	}
}
