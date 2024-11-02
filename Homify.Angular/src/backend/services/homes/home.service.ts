import { Injectable } from '@angular/core';
import { HomeApiRepositoryService } from '../../repositories/HomeRepository.service';
import { CreateHomeRequest } from './models/CreateHomeRequest';
import { CreateHomeResponse } from './models/CreateHomeResponse';
import { Observable } from 'rxjs';
import { GetAllHomesResponse } from './models/GetAllHomesResponse';
import { UpdateMemberListRequest } from './models/UpdateMemberListRequest';
import { UpdateMemberListResponse } from './models/UpdateMemberListResponse';
import { UpdateMembersPermissionRequest } from './models/UpdateMembersPermissionRequest';
import { HomeMemberBasicInfo } from './models/HomeMemberBasicInfo';
import { GetMembersResponse } from './models/GetMembersResponse';

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

  public UpdateMembers(id:string, request: UpdateMemberListRequest): Observable<UpdateMemberListResponse>{
    return this._repository.UpdateHomeMembers(id, request);
  }

  public UpdatePermissions(homeId: string, request: UpdateMembersPermissionRequest, memberId:string)
  :Observable<HomeMemberBasicInfo>{
    return this._repository.UpdateMembersPermissions(homeId, memberId, request)
  }

  public GetMembers(homeId:string) : Observable<Array<GetMembersResponse>>{
    return this._repository.GetHomeMembers(homeId);
  }
}
