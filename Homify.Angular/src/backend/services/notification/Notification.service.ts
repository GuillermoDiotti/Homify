import { Injectable } from '@angular/core';
import { NotificationApiRepositoryService } from '../../repositories/NotificationRepository.service';
import { Observable } from 'rxjs';
import { NotificationBasicInfo } from './models/NotificationBasicInfo';
import { UpdateNotificationResponse } from './models/UpdateNotificationResponse';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  constructor(private readonly _repository: NotificationApiRepositoryService) {}

  public getUserNotifications(
		limit?: string,
		offset?: string,
		eventTriggered?: string,
		date?: string,
		read?: string
	): Observable<NotificationBasicInfo[]> {
		const queryParams: string[] = [];

    if (limit) {
      queryParams.push(`limit=${encodeURIComponent(limit)}`);
    }
    if (offset) {
      queryParams.push(`offset=${encodeURIComponent(offset)}`);
    }
		if (eventTriggered) {
      queryParams.push(`eventTriggered=${encodeURIComponent(eventTriggered)}`);
    }
		if (date) {
      queryParams.push(`date=${encodeURIComponent(date)}`);
    }
		if (read) {
      queryParams.push(`read=${encodeURIComponent(read)}`);
    }

		const query = queryParams.join('&');
    return this._repository.getUserNotifications(query);
  }

	public readNotification(id: string): Observable<UpdateNotificationResponse> {
		return this._repository.readNotification(id);
	}
}