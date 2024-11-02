import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SessionTypeApiRepositoryService } from '../../repositories/SessionRepository.service';
import CreateSessionResponse from './models/CreateSessionResponse';

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

  login(username: string, password: string): Observable<CreateSessionResponse> {
    return this.sessionRepository.login(username, password);
  }
}
