import { Injectable } from '@angular/core';
import { HomeApiRepositoryService } from '../../repositories/HomeRepository.service';
import { CreateHomeRequest } from './models/CreateHomeRequest';
import { CreateHomeResponse } from './models/CreateHomeResponse';
import { Observable } from 'rxjs';
import { GetAllHomesResponse } from './models/GetAllHomesResponse';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private readonly _repository: HomeApiRepositoryService) { }

  public create(request: CreateHomeRequest): Observable<CreateHomeResponse> {
    return this._repository.create(request);
  }

  public getHomesByOwner()
    : Observable<Array<GetAllHomesResponse>> {
    return this._repository.getAllHomesByOwner();
  }
}
