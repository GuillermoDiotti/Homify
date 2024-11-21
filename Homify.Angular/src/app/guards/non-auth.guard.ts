import { Injectable } from '@angular/core';
import { CanActivate} from '@angular/router';
import { SessionService } from '../../backend/services/session/Session.service';

@Injectable({
  providedIn: 'root'
})
export class NonAuthGuard implements CanActivate {

  constructor(private readonly SessionService: SessionService) {}

  canActivate(): boolean {
		const { token } = this.SessionService.getCurrentUser(); 
    if (!token) {
      return true;
    } else {
      return false;
    }
  }
}