import { Component, Input } from '@angular/core';
import { HomeService } from '../../../../backend/services/homes/home.service';
import { NotificatedMembersRequest } from '../../../../backend/services/homes/models/NotificatedMembersRequest';
import { APIError } from '../../../../interfaces/interfaces';
import { ButtonComponent } from '../../../components/button/button.component';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';

@Component({
  selector: 'app-make-user-notificable-form',
  standalone: true,
  imports: [ButtonComponent, SuccessMessageComponent, ErrorMessageComponent],
  templateUrl: './make-user-notificable-form.component.html',
  styleUrl: './make-user-notificable-form.component.css'
})
export class MakeUserNotificableFormComponent {
	@Input() selectedMemberId = '';
	@Input() selectedHomeId = '';

	errorMessage = '';
	successMessage = '';

	constructor(private readonly HomeService: HomeService) {}

	onClick() {
		this.errorMessage = '';
		this.successMessage = '';
		console.log(this.selectedMemberId)

		const req: NotificatedMembersRequest = {
			homeUserId: this.selectedMemberId,
		};
		this.HomeService.makeUserNotificable(this.selectedHomeId, req).subscribe(
			res => this.successMessage = 'Member is now notificable',
			(err: APIError) => this.errorMessage = err.error.message,
		)
	}
}
