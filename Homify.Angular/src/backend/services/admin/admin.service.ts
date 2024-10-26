import { Injectable } from '@angular/core';
import { AdminTypeApiRepositoryService } from '../../repositories/AdminRepository.service';
import CreateAdminRequest from './models/CreateAdminRequest';
import CreateAdminResponse from './models/CreateAdminResponse';
import { Observable } from 'rxjs';
import UserBasicInfo from './models/UserBasicInfo';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private readonly _repository: AdminTypeApiRepositoryService) { }

  public create(request: CreateAdminRequest): Observable<CreateAdminResponse> {
    return this._repository.create(request);
  }

  public deleteAdmin(id: string) {
    return this._repository.deleteAdmin(id);
  }

  public getAllAccounts(
    limit?: string,
    offset?: string,
    role?: string,
    fullName?: string)
    : Observable<Array<UserBasicInfo>> {
    const query = `limit=${limit ?? ''}&offset=${offset ?? ''}&role=${encodeURIComponent(role ?? '')}&fullName=${encodeURIComponent(fullName ?? '')}`;
    return this._repository.getAllAccounts(query);
  }
}
