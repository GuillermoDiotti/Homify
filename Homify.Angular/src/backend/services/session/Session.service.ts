import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SessionTypeApiRepositoryService } from '../../repositories/SessionRepository.service';
import CreateSessionResponse from './models/CreateSessionResponse';
import { CreateHomeOwnerResponse } from './models/CreateHomeOwnerResponse';

export interface User {
	id: string;
	name: string,
	surname: string,
	fullName: string,
	role: string,
	createdAt: string,
}	

@Injectable({
  providedIn: 'root'
})
export class SessionService {
  constructor(private sessionRepository: SessionTypeApiRepositoryService) {}

  public setCurrentUser(token: string | null, roles: string[] | null): void {
		localStorage.setItem('token', token ?? '');
		localStorage.setItem('roles', JSON.stringify(roles));
  }

  public getCurrentUser(): { token: string | null, roles: string[] } {
    const token = localStorage.getItem('token') ?? null;
		const roles = JSON.parse(localStorage.getItem('roles') ?? '');
		return { token, roles };
  }

	public removeCurrentUserToken(): void {
		localStorage.removeItem('token');
	}

  public login(username: string, password: string): Observable<CreateSessionResponse> {
    return this.sessionRepository.login(username, password);
  }

	public register(username: string, password: string, name: string, lastName: string, profilePicUrl: string): Observable<CreateHomeOwnerResponse> {
    return this.sessionRepository.register(username, password, name, lastName, profilePicUrl);
  }
}
