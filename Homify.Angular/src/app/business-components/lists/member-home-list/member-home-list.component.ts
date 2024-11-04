import { Component, EventEmitter, Output } from '@angular/core';
import { GetAllHomesResponse } from '../../../../backend/services/homes/models/GetAllHomesResponse';
import { HomeService } from '../../../../backend/services/homes/home.service';
import { ButtonComponent } from '../../../components/button/button.component';

@Component({
  selector: 'app-member-home-list',
  standalone: true,
  imports: [ButtonComponent],
  templateUrl: './member-home-list.component.html',
  styleUrl: './member-home-list.component.css'
})
export class MemberHomeListComponent {
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
		this.HomeService.getHomesByMember().subscribe(
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
