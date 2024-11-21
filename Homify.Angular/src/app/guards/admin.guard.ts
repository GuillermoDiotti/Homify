import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { HomifyConstants } from '../../utility/HomifyConstants';
import { SessionService } from '../../backend/services/session/Session.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {

  constructor(private readonly SessionService: SessionService) {}

  canActivate(): boolean {
		const { token, roles } = this.SessionService.getCurrentUser(); 

		const hasPermission = roles.some(r => r === HomifyConstants.ADMINISTRATOR);

    if (token && hasPermission) {
      return true;
    } else {
      return false;
    }
  }
}
