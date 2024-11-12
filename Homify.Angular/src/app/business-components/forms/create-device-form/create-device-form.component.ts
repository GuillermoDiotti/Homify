import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { FormComponent } from '../../../components/form/form/form.component';
import { FormButtonComponent } from '../../../components/form/form-button/form-button.component';
import { FormInputComponent } from '../../../components/form/form-input/form-input.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';
import { APIError } from '../../../../interfaces/interfaces';
import CreateCameraRequest from '../../../../backend/services/device/models/CreateCameraRequest';
import CreateSensorRequest from '../../../../backend/services/device/models/CreateSensorRequest';
import { DeviceService } from '../../../../backend/services/device/Device.service';

@Component({
  selector: 'app-create-device-form',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    FormComponent,
    FormButtonComponent,
    FormInputComponent,
    SuccessMessageComponent,
    ErrorMessageComponent,
  ],
  templateUrl: './create-device-form.component.html',
  styleUrl: './create-device-form.component.css',
})
export class CreateDeviceFormComponent {
  form: FormGroup;
  successMessage = '';
  errorMessage = '';
  device = 'camera';

  constructor(private fb: FormBuilder, private DeviceService: DeviceService) {
    this.form = this.fb.group({
      name: ['', [Validators.required]],
      model: ['', [Validators.required]],
      description: ['', [Validators.required]],
      ppalPicture: ['', [Validators.required]],
      isExterior: [false],
      isInterior: [false],
      movementDetection: [false],
      peopleDetection: [false],
    });
  }

  onDeviceTypeChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    this.device = selectElement.value;
  }

  handleSubmit() {
    this.successMessage = '';
    this.errorMessage = '';
    if (this.form.valid) {
      this.createDevice(this.device);
    } else {
      this.errorMessage = 'Form is invalid';
    }
  }

  createDevice(device: string) {
    const {
      name,
      model,
      description,
      ppalPicture,
      isExterior,
      isInterior,
      photos,
      movementDetection,
      peopleDetection,
    } = this.form.value;
		
    switch (device) {
      case 'camera':
        const cameraRequest: CreateCameraRequest = {
          name,
          model,
          description,
          ppalPicture,
          isExterior,
          isInterior,
          photos,
          movementDetection,
          peopleDetection,
        };

        this.DeviceService.createCamera(cameraRequest).subscribe(
          (response) => {
            this.successMessage = 'Camera created successfully';
          },
          (error: APIError) => {
            this.errorMessage = error.error.message;
          }
        );
        break;

      case 'window-sensor':
        const windowSensorRequest: CreateSensorRequest = {
          description,
          model,
          name,
          photos,
          ppalPicture,
        };

        this.DeviceService.createWindowSensor(windowSensorRequest).subscribe(
          (response) => {
            this.successMessage = 'Window Sensor created successfully';
          },
          (error: APIError) => {
            this.errorMessage = error.error.message;
          }
        );
        break;

      case 'movement-sensor':
        const movementSensorRequest: CreateSensorRequest = {
          description,
          model,
          name,
          photos,
          ppalPicture,
        };

        this.DeviceService.createMovementSensor(
          movementSensorRequest
        ).subscribe(
          (response) => {
            this.successMessage = 'Movement Sensor created successfully';
          },
          (error: APIError) => {
            this.errorMessage = error.error.message;
          }
        );
        break;

      case 'lamp':
        const lampRequest: CreateSensorRequest = {
          description,
          model,
          name,
          photos,
          ppalPicture,
        };

        this.DeviceService.createLamp(lampRequest).subscribe(
          (response) => {
            this.successMessage = 'Lamp created successfully';
          },
          (error: APIError) => {
            this.errorMessage = error.error.message;
          }
        );
        break;

      default:
        console.log('Unknown device type');
    }
  }
}
