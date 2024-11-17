import { Component, Inject, OnInit } from '@angular/core';
import { GetDevicesResponse } from '../../../../backend/services/device/models/GetDevicesResponse';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ButtonComponent } from '../../../components/button/button.component';
import { RoomService } from '../../../../backend/services/rooms/Room.service';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';
import { APIError } from '../../../../interfaces/interfaces';
import { RoomBasicInfo } from '../../../../backend/services/rooms/models/RoomBasicInfo';

@Component({
  selector: 'app-assing-device-to-room-form',
  standalone: true,
  imports: [ButtonComponent, ErrorMessageComponent, SuccessMessageComponent],
  templateUrl: './assing-device-to-room-form.component.html',
  styleUrl: './assing-device-to-room-form.component.css',
})
export class AssingDeviceToRoomFormComponent implements OnInit {
  errorMessage = '';
  successMessage = '';
	rooms: RoomBasicInfo[] = [];
  selectedRoomId = '';

  constructor(
    public dialogRef: MatDialogRef<AssingDeviceToRoomFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { device: GetDevicesResponse | null, homeId: string },
    private readonly RoomService: RoomService
  ) {}

	ngOnInit(): void {
		this.RoomService.getAllHomeRooms(this.data.homeId).subscribe(
			res => {
				console.log(res)
				this.rooms = res;
				this.selectedRoomId = this.rooms.length > 0 ? res[0].id : '';
			},
			(err: APIError) => console.error(err),
		)
	}

  handleAssign() {
    this.errorMessage = '';
    this.successMessage = '';

    this.RoomService.assingHomeDeviceToRoom(
      this.selectedRoomId,
      this.data.device?.id ?? ''
    ).subscribe(
      (res) => (this.successMessage = 'Device assigned to room'),
      (err: APIError) => (this.errorMessage = err.error.message)
    );
  }

  onRoomChange(event: Event) {}
}
