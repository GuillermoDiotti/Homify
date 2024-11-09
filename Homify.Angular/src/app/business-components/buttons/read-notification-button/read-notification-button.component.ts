import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-read-notification-button',
  standalone: true,
  imports: [],
  templateUrl: './read-notification-button.component.html',
  styleUrl: './read-notification-button.component.css'
})
export class ReadNotificationButtonComponent {
	@Input() notiId: string = '';
}
