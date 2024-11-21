import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SessionTypeApiRepositoryService } from '../../repositories/SessionRepository.service';
import CreateSessionResponse from './models/CreateSessionResponse';
import { CreateHomeOwnerResponse } from './models/CreateHomeOwnerResponse';

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
    name: string,
		userId: string
  ): void {
    localStorage.setItem('token', token ?? '');
    localStorage.setItem('roles', JSON.stringify(roles) ?? '[]');
		localStorage.setItem('name', name ?? '');
		localStorage.setItem('userId', userId ?? '');
  }

  public getCurrentUser(): {
    token: string | null;
    roles: string[];
    name: string;
		userId: string;
  } {
    const token = localStorage.getItem('token') ?? null;
		const name = localStorage.getItem('name') ?? '';
		const userId = localStorage.getItem('userId') ?? '';
		const roles = JSON.parse(localStorage.getItem('roles') ?? '[]');
    return { token, roles, name, userId };
  }

  public removeCurrentUserToken(): void {
    localStorage.removeItem('token');
		localStorage.removeItem('roles');
		localStorage.removeItem('name');
		localStorage.removeItem('userId');
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
