import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RoomApiRepositoryService } from '../../repositories/RoomRepository.service';
import { CreateRoomRequest } from './models/CreateRoomRequest';
import { RoomBasicInfo } from './models/RoomBasicInfo';

@Injectable({
  providedIn: 'root',
})
export class RoomService {
  constructor(private readonly _repository: RoomApiRepositoryService) {}

  public create(req: CreateRoomRequest): Observable<any> {
    return this._repository.create(req);
  }

	public getAllHomeRooms(homeId: string): Observable<RoomBasicInfo[]> {
		return this._repository.getAllHomeRooms(homeId);
	}

	public assingHomeDeviceToRoom(roomId: string, homeDeviceId: string) {
		return this._repository.assingHomeDeviceToRoom(roomId, homeDeviceId);
	}
}
