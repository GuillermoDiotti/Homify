import { Component } from '@angular/core';

@Component({
  selector: 'app-rooms-page',
  templateUrl: './rooms-page.component.html',
  styleUrl: './rooms-page.component.css'
})
export class RoomsPageComponent {
	selectedHomeId: string | null = null;
  onHomeSelected(id: string) { this.selectedHomeId = id; }
}
