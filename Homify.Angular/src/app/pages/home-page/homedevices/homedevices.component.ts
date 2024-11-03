import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-homedevices',
  templateUrl: './homedevices.component.html',
  styleUrl: './homedevices.component.css'
})
export class HomedevicesComponent {
	@Input() selectedHomeId: string | null = null;
  
	onHomeSelected(id: string) { 
    this.selectedHomeId = id; 
	}
}
