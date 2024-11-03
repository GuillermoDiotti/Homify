import { Component, EventEmitter, Input, output, Output } from '@angular/core';
import { GetMembersResponse } from '../../../../backend/services/homes/models/GetMembersResponse';
import { HomeService } from '../../../../backend/services/homes/home.service';
import { ButtonComponent } from '../../../components/button/button.component';

@Component({
  selector: 'app-home-member-list',
  standalone: true,
  imports: [ButtonComponent],
  templateUrl: './home-member-list.component.html',
  styleUrl: './home-member-list.component.css'
})
export class HomeMemberListComponent {
  members: GetMembersResponse[] = [];
  @Output() memberSelected = new EventEmitter<string>();	
  @Input() selectedMemberId = "";
  @Input() selectedHomeId = "";
  
	constructor(private HomeService: HomeService){}

	ngOnInit() {
		this.HomeService.GetMembers(this.selectedHomeId).subscribe(
			response => {
				this.members = response;
			},
			error => {
				console.error("Error listing members", error);
			}
		)
	}

	handleRefresh() {
		this.HomeService.GetMembers(this.selectedHomeId).subscribe(
			response => {
				this.members = response;
			},
			error => {
				console.error("Error listing homes", error);
			}
		)
	}

	onClick(id:string){
		this.selectedMemberId = id;
		this.memberSelected.emit(this.selectedMemberId);
	}
}
