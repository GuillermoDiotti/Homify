import { Component, EventEmitter, Output } from '@angular/core';
import { GetAllHomesResponse } from '../../../../backend/services/homes/models/GetAllHomesResponse';
import { HomeService } from '../../../../backend/services/homes/home.service';
import { ButtonComponent } from '../../../components/button/button.component';
import { RenameHomeButtonComponent } from '../../../components/rename-home-button/rename-home-button.component';

@Component({
  selector: 'app-home-integrants-list',
  standalone: true,
  imports: [ButtonComponent, RenameHomeButtonComponent],
  templateUrl: './home-integrants-list.component.html',
  styleUrl: './home-integrants-list.component.css'
})
export class HomeIntegrantsListComponent {
	homes: GetAllHomesResponse[] = [];
  @Output() homeSelected = new EventEmitter<string>();	
  selectedHomeId = "";
	constructor(private HomeService: HomeService){}

	ngOnInit() {
		this.loadHomes();
	}

	handleRefresh() {
		this.loadHomes();
	}

	onClick(id:string){
		this.selectedHomeId = id;
		this.homeSelected.emit(this.selectedHomeId);
	}

	loadHomes () {
		this.HomeService.getHomesByOwner().subscribe(
			response => {
				this.homes = response;

				this.HomeService.getHomesByMember().subscribe(
					response => {
						this.homes = [...this.homes, ...response];
					},
					error => {
						console.error("Error listing homes", error);
					}
				)
			},
			error => {
				console.error("Error listing homes", error);
			}
		)
	}
 }
