import { Component, Input } from '@angular/core';
import { APIError } from '../../../../interfaces/interfaces';
import { RoomService } from '../../../../backend/services/rooms/Room.service';
import { CreateRoomRequest } from '../../../../backend/services/rooms/models/CreateRoomRequest';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';
import { ButtonComponent } from '../../../components/button/button.component';
import { InputComponent } from '../../../components/input/input.component';

@Component({
  selector: 'app-add-rooms-form',
  standalone: true,
  imports: [ErrorMessageComponent, SuccessMessageComponent, 
		InputComponent, ButtonComponent],
  templateUrl: './add-rooms-form.component.html',
  styleUrl: './add-rooms-form.component.css'
})
export class AddRoomsFormComponent {
	@Input() homeId = '';
	errorMessage = '';
	successMessage = ''; 
	roomName: string = '';

	
	constructor(private readonly RoomService: RoomService) {}
	
	handleSubmit() {
		this.successMessage = '';
		this.errorMessage = '';

		const req: CreateRoomRequest = {
			homeId: this.homeId,
			name: this.roomName,
		};

		this.RoomService.create(req).subscribe(
			res => this.successMessage = "Room has added to home",
			(err: APIError) => this.errorMessage = err.error.message,
		)
	}

	onRoomChange(event: Event) {
		this.roomName = (event.target as HTMLInputElement).value;
	}
}
