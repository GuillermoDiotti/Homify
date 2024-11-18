import { Component } from '@angular/core';
import { APIError } from '../../../../interfaces/interfaces';
import { UpdateProfileRequest } from '../../../../backend/services/session/models/UpdateProfileRequest';
import { InputComponent } from '../../../components/input/input.component';
import { ButtonComponent } from '../../../components/button/button.component';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { HomeOwnerService } from '../../../../backend/services/home-owner/HomeOwner.service';

@Component({
  selector: 'app-update-profile-form',
  standalone: true,
  imports: [InputComponent, ButtonComponent, SuccessMessageComponent, 
		ErrorMessageComponent],
  templateUrl: './update-profile-form.component.html',
  styleUrl: './update-profile-form.component.css'
})
export class UpdateProfileFormComponent {
	successMessage = '';
	errorMessage = '';
	profilePicture = '';

	constructor(private readonly HomeOwnerService: HomeOwnerService) {}

	handleSubmit() {
		this.errorMessage = '';
		this.successMessage = '';
		
		const req: UpdateProfileRequest = {
			profilePicture: this.profilePicture,
		};

		this.HomeOwnerService.updateProfilePicture(req).subscribe(
			res => this.successMessage = 'Profile updated successfully',
			(err: APIError) => this.errorMessage = err.error.message,
		);
	}

	onPPChange(event: Event) {
		this.profilePicture = (event.target as HTMLInputElement).value;
	}
}
