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

  public setCurrentUserToken(token: string | null): void {
		localStorage.setItem('token', token ?? '');
  }

  public getCurrentUserToken(): string | null {
    return localStorage.getItem('token') ?? null;
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
