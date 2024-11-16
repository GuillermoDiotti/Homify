import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RoomApiRepositoryService } from '../../repositories/RoomRepository.service';
import { CreateRoomRequest } from './models/CreateRoomRequest';

@Injectable({
  providedIn: 'root',
})
export class RoomService {
  constructor(private readonly _repository: RoomApiRepositoryService) {}

  public create(req: CreateRoomRequest): Observable<any> {
    return this._repository.create(req);
  }
}
