import { Injectable } from '@angular/core';
import ApiRepository from './api-repository';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environment';
import { catchError, Observable } from 'rxjs';
import { CreateRoomRequest } from '../services/rooms/models/CreateRoomRequest';
import { RoomBasicInfo } from '../services/rooms/models/RoomBasicInfo';

@Injectable({
  providedIn: 'root',
})
export class RoomApiRepositoryService extends ApiRepository {
  constructor(http: HttpClient) {
    super(environment.homifyApi, 'rooms', http);
  }

  public create(req: CreateRoomRequest): Observable<any> {
    return this.post<any>(req).pipe(catchError(this.handleError));
  }

	public getAllHomeRooms(homeId: string): Observable<RoomBasicInfo[]> {
		return this.get<RoomBasicInfo[]>(homeId).pipe(catchError(this.handleError));
	}

	public assingHomeDeviceToRoom(roomId: string, homeDeviceId: string) {
		return this.putById(`${roomId}/${homeDeviceId}`).pipe(catchError(this.handleError));
	}
}
