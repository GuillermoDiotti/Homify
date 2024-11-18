import { Injectable } from '@angular/core';
import ApiRepository from './api-repository';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environment';
import { catchError, Observable } from 'rxjs';
import { RoleBasicInfo } from '../services/roles/models/roles/RolesBasicInfo';

@Injectable({
  providedIn: 'root',
})
export class RoleApiRepositoryService extends ApiRepository {
  constructor(http: HttpClient) {
    super(environment.homifyApi, 'roles', http);
  }

  public addRoleToExistingUser(): Observable<RoleBasicInfo> {
    return this.putById<any>('').pipe(catchError(this.handleError));
  }
}
