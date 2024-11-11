import { Injectable } from '@angular/core';
import { NotificationApiRepositoryService } from '../../repositories/NotificationRepository.service';
import { Observable } from 'rxjs';
import { NotificationBasicInfo } from './models/NotificationBasicInfo';
import { UpdateNotificationResponse } from './models/UpdateNotificationResponse';
import { GenerateNotificationRequest } from './models/GenerateNotificationRequest';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  constructor(private readonly _repository: NotificationApiRepositoryService) {}

  public getUserNotifications(
		eventTriggered?: string,
		date?: string,
		read?: string
	): Observable<NotificationBasicInfo[]> {
		const queryParams: string[] = [];

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

	public createNotification(req: GenerateNotificationRequest, type: string): Observable<any> {
		return this._repository.createNotification(req, type);
	}
}