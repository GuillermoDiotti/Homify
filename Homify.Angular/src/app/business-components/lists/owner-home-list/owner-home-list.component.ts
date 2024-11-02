import { Component } from '@angular/core';
import { GetAllHomesResponse } from '../../../../backend/services/homes/models/GetAllHomesResponse';
import { HomeService } from '../../../../backend/services/homes/home.service';

@Component({
  selector: 'app-owner-home-list',
  standalone: true,
  imports: [],
  templateUrl: './owner-home-list.component.html',
  styleUrl: './owner-home-list.component.css'
})
export class OwnerHomeListComponent {
  homes: GetAllHomesResponse[] = [];
	constructor(private HomeService: HomeService){}

	ngOnInit() {
		this.HomeService.getHomesByOwner().subscribe(
			response => {
				this.homes = response;
			},
			error => {
				console.error("Error listing homes", error);
			}
		)
	}

	handleRefresh() {
		this.HomeService.getHomesByOwner().subscribe(
			response => {
				this.homes = response;
			},
			error => {
				console.error("Error listing homes", error);
			}
		)
	}
}
