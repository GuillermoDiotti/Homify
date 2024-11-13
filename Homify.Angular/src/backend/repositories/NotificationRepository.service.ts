import { Injectable } from "@angular/core";
import ApiRepository from "./api-repository";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environment";
import { catchError, Observable } from "rxjs";
import { NotificationBasicInfo } from "../services/notification/models/NotificationBasicInfo";
import { UpdateNotificationResponse } from "../services/notification/models/UpdateNotificationResponse";

@Injectable({
  providedIn: "root",
})
export class NotificationApiRepositoryService extends ApiRepository {
  constructor(http: HttpClient) {
    super(environment.homifyApi, 'notifications', http);
  }

  public getUserNotifications(query: string): Observable<Array<NotificationBasicInfo>> {
    return this.get<Array<NotificationBasicInfo>>("", query).pipe(catchError(this.handleError));
  }

	public readNotification(id: string): Observable<UpdateNotificationResponse> {
		return this.putById<UpdateNotificationResponse>(id).pipe(catchError(this.handleError));
	}
}