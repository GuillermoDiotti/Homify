import { Component, Input } from '@angular/core';
import { NotificationService } from '../../../../backend/services/notification/Notification.service';
import { APIError } from '../../../../interfaces/interfaces';

@Component({
  selector: 'app-read-notification-button',
  standalone: true,
  imports: [],
  templateUrl: './read-notification-button.component.html',
  styleUrl: './read-notification-button.component.css'
})
export class ReadNotificationButtonComponent {
	@Input() notiId: string = '';
	successMessage = '';
	errorMessage = '';

	constructor(private readonly NotificationService: NotificationService) {}

	handleClick() {
		this.NotificationService.readNotification(this.notiId).subscribe(
			res => this.successMessage = 'Notification read successfully',
			(err: APIError) => this.errorMessage = err.error.message,
		)
	}
}
