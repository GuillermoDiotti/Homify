import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { SessionService } from '../../backend/services/session/Session.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private readonly SessionService: SessionService) {}

  canActivate(): boolean {
		const { token, roles } = this.SessionService.getCurrentUser(); 

		const hasPermission = roles.length > 0;
 
    if (token && hasPermission) {
      return true;
    } else {
      return false;
    }
  }
}