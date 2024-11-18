import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SessionTypeApiRepositoryService } from '../../repositories/SessionRepository.service';
import CreateSessionResponse from './models/CreateSessionResponse';
import { CreateHomeOwnerResponse } from './models/CreateHomeOwnerResponse';
import { UpdateProfileRequest } from './models/UpdateProfileRequest';

export interface User {
  id: string;
  name: string;
  surname: string;
  fullName: string;
  role: string;
  createdAt: string;
}

@Injectable({
  providedIn: 'root',
})
export class SessionService {
  constructor(private sessionRepository: SessionTypeApiRepositoryService) {}

  public setCurrentUser(
    token: string | null,
    roles: string[] | null,
    name: string
  ): void {
    localStorage.setItem('token', token ?? '');
    localStorage.setItem('roles', JSON.stringify(roles) ?? '[]');
		localStorage.setItem('name', name ?? '');
  }

  public getCurrentUser(): {
    token: string | null;
    roles: string[];
    name: string;
  } {
    const token = localStorage.getItem('token') ?? null;
		const name = localStorage.getItem('name') ?? '';
		const roles = JSON.parse(localStorage.getItem('roles') ?? '[]');
    return { token, roles, name };
  }

  public removeCurrentUserToken(): void {
    localStorage.removeItem('token');
		localStorage.removeItem('roles');
		localStorage.removeItem('name');
  }

  public login(
    username: string,
    password: string
  ): Observable<CreateSessionResponse> {
    return this.sessionRepository.login(username, password);
  }

  public register(
    username: string,
    password: string,
    name: string,
    lastName: string,
    profilePicUrl: string
  ): Observable<CreateHomeOwnerResponse> {
    return this.sessionRepository.register(
      username,
      password,
      name,
      lastName,
      profilePicUrl
    );
  }
}
