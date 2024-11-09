import { Component } from '@angular/core';
import { NotificationService } from '../../../../backend/services/notification/Notification.service';
import { NotificationBasicInfo } from '../../../../backend/services/notification/models/NotificationBasicInfo';
import { PaginationComponent } from '../../../components/pagination/pagination.component';
import { ReadNotificationButtonComponent } from '../../buttons/read-notification-button/read-notification-button.component';

@Component({
  selector: 'app-notification-list',
  standalone: true,
  imports: [PaginationComponent, ReadNotificationButtonComponent],
  templateUrl: './notification-list.component.html',
  styleUrl: './notification-list.component.css',
})
export class NotificationListComponent {
  notifications: NotificationBasicInfo[] = [];
  constructor(private readonly NotificationService: NotificationService) {}

	filterByEvent = '';
  filterByDate = '';
	filterByRead = '';

  limit = 10;
  offset = 0;

  updateLimit(newLimit: number) {
    this.limit = newLimit;
  }

  updateOffset(newOffset: number) {
    this.offset = newOffset;
  }

  ngOnInit() {
    this.NotificationService.getUserNotifications(
      this.limit.toString(),
      this.offset.toString(),
			this.filterByEvent,
      this.filterByDate,
			this.filterByRead,
    ).subscribe(
      (response) => {
        this.notifications = response;
      },
      (error) => {
        console.error('Error fetching notifications', error);
      }
    );
  }
  handleRefresh() {
    this.NotificationService.getUserNotifications(
      this.limit.toString(),
      this.offset.toString(),
      this.filterByEvent,
      this.filterByDate,
			this.filterByRead,
    ).subscribe(
      (response) => {
        this.notifications = response;
      },
      (error) => {
        console.error('Error creating admin', error);
      }
    );
  }

	onEventTriggeredChange(event: Event) {
		const selectElement = event.target as HTMLSelectElement;
		this.filterByEvent = selectElement.value;
	}

	onDateChange(event: Event) {
		this.filterByDate = (event.target as HTMLInputElement).value;
	}
	
	onReadChange(event: Event) {
		this.filterByRead = (event.target as HTMLInputElement).checked.toString();
	}
}