import { Component, EventEmitter, Output } from '@angular/core';
import { GetAllHomesResponse } from '../../../../backend/services/homes/models/GetAllHomesResponse';
import { HomeService } from '../../../../backend/services/homes/home.service';
import { ButtonComponent } from '../../../components/button/button.component';
import { RenameHomeButtonComponent } from '../../../components/rename-home-button/rename-home-button.component';

@Component({
  selector: 'app-owner-home-list',
  standalone: true,
  imports: [ButtonComponent, RenameHomeButtonComponent],
  templateUrl: './owner-home-list.component.html',
  styleUrl: './owner-home-list.component.css'
})
export class OwnerHomeListComponent {
  homes: GetAllHomesResponse[] = [];
  @Output() homeSelected = new EventEmitter<string>();	
  selectedHomeId = "";
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

	onClick(id:string){
		this.selectedHomeId = id;
		this.homeSelected.emit(this.selectedHomeId);
	}
}
