import { Component } from '@angular/core';
import { NotificationService } from '../../../../backend/services/notification/Notification.service';
import { NotificationBasicInfo } from '../../../../backend/services/notification/models/NotificationBasicInfo';
import { ReadNotificationButtonComponent } from '../../buttons/read-notification-button/read-notification-button.component';
import { InputComponent } from '../../../components/input/input.component';
import { ButtonComponent } from '../../../components/button/button.component';

@Component({
  selector: 'app-notification-list',
  standalone: true,
  imports: [ReadNotificationButtonComponent, InputComponent, ButtonComponent],
  templateUrl: './notification-list.component.html',
  styleUrl: './notification-list.component.css',
})
export class NotificationListComponent {
  notifications: NotificationBasicInfo[] = [];
  constructor(
    private readonly NotificationService: NotificationService
  ) {}

  filterByEvent = '';
  filterByDate = '';
  filterByRead = '';

  ngOnInit() {
    this.NotificationService.getUserNotifications(
      this.filterByEvent,
      this.filterByDate,
      this.filterByRead
    ).subscribe(
      (response) => {
        this.notifications = response;
      },
      (error) => {
        console.error('Error getting notifications', error);
      }
    );
  }

  handleRefresh() {
    this.NotificationService.getUserNotifications(
      this.filterByEvent,
      this.filterByDate,
      this.filterByRead
    ).subscribe(
      (response) => {
        this.notifications = response;
      },
      (error) => {
        console.error('Error getting notifications', error);
      }
    );
  }

	handleSearchWithoutFilters() {
		this.NotificationService.getUserNotifications(
    ).subscribe(
      (response) => {
        this.notifications = response;
      },
      (error) => {
        console.error('Error fetching notifications', error);
      }
    );
	}

  onEventTriggeredChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    this.filterByEvent = selectElement.value;
  }

  onDateChange(event: Event) {
    const inputValue = (event.target as HTMLInputElement).value;

		if (!inputValue) {
			this.filterByDate = "";
			return;
		}

    const selectedDate = new Date(inputValue + 'T00:00:00');

    const day = selectedDate.getUTCDate().toString().padStart(2, '0');
    const month = (selectedDate.getUTCMonth() + 1).toString().padStart(2, '0');
    const year = selectedDate.getUTCFullYear();

    this.filterByDate = `${day}/${month}/${year}`;
  }

  onReadChange(event: Event) {
    this.filterByRead = (event.target as HTMLInputElement).checked.toString();
  }
}
