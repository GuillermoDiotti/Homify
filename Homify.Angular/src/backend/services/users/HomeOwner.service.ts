import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
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
  private currentUserTokenSubject: BehaviorSubject<string | null>;
  public currentUserToken: Observable<string | null>;

  constructor(private sessionRepository: SessionTypeApiRepositoryService) {
    this.currentUserTokenSubject = new BehaviorSubject<string | null>(null);
    this.currentUserToken = this.currentUserTokenSubject.asObservable();
  }

  public setCurrentUserToken(token: string | null): void {
    this.currentUserTokenSubject.next(token);
  }

  public getCurrentUserToken(): Observable<string | null> {
    return this.currentUserToken;
  }

  login(username: string, password: string): Observable<CreateSessionResponse> {
    return this.sessionRepository.login(username, password);
  }
}
