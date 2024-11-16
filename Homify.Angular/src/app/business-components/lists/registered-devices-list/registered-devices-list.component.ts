import { Component, EventEmitter, Inject, Input, Output } from '@angular/core';
import { APIError } from '../../../../interfaces/interfaces';
import SearchDeviceResponse from '../../../../backend/services/device/models/SearchDeviceResponse';
import { ButtonComponent } from '../../../components/button/button.component';
import { DeviceService } from '../../../../backend/services/device/Device.service';
import { PaginationComponent } from '../../../components/pagination/pagination.component';
import { InputComponent } from '../../../components/input/input.component';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { DevicePhotosListComponent } from '../../../components/device-photos-list/device-photos-list.component';

@Component({
  selector: 'app-registered-devices-list',
  standalone: true,
  imports: [ButtonComponent, PaginationComponent, InputComponent],
  templateUrl: './registered-devices-list.component.html',
  styleUrl: './registered-devices-list.component.css',
})
export class RegisteredDevicesListComponent {
  registeredDevices: SearchDeviceResponse[] = [];
  @Output() deviceEmitter = new EventEmitter<string>();
  deviceSelected: string = '';
  @Input() displayButtons = false;

  constructor(
    private readonly DeviceSevice: DeviceService,
		public dialog: MatDialog
  ) {}

  filterByDeviceName = '';
  filterByModel = '';
  filterByCompany = '';
  filterByDeviceType = '';

  limit = 10;
  offset = 0;

  updateLimit(newLimit: number) {
    this.limit = newLimit;
  }

  updateOffset(newOffset: number) {
    this.offset = newOffset;
  }

	handleViewPhotos(device: SearchDeviceResponse) {
		this.dialog.open(DevicePhotosListComponent, {
			data: {
				device,
			}
		});
	}

  ngOnInit(): void {
    this.DeviceSevice.getRegisteredDevices(
      this.limit,
      this.offset,
      this.filterByDeviceName,
      this.filterByModel,
      this.filterByCompany,
      this.filterByDeviceType
    ).subscribe(
      (res) => (this.registeredDevices = res),
      (error: APIError) => console.error(error)
    );
  }

  handleRefresh() {
    this.DeviceSevice.getRegisteredDevices(
      this.limit,
      this.offset,
      this.filterByDeviceName,
      this.filterByModel,
      this.filterByCompany,
      this.filterByDeviceType
    ).subscribe(
      (res) => (this.registeredDevices = res),
      (error: APIError) => console.error(error)
    );
  }

  handleRefreshWithoutFilters() {
    this.DeviceSevice.getRegisteredDevices().subscribe(
      (res) => (this.registeredDevices = res),
      (error: APIError) => console.error(error)
    );
  }

  onDeviceClick(id: string) {
    this.deviceSelected = id;
    this.deviceEmitter.emit(id);
  }

  onNameChange(event: Event) {
    this.filterByDeviceName = (event.target as HTMLInputElement).value;
  }

  onModelChange(event: Event) {
    this.filterByModel = (event.target as HTMLInputElement).value;
  }

  onCompanyChange(event: Event) {
    this.filterByCompany = (event.target as HTMLInputElement).value;
  }

  onTypeChange(event: Event) {
    this.filterByDeviceType = (event.target as HTMLInputElement).value;
  }
}
