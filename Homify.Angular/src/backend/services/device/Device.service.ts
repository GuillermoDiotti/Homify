import { Injectable } from '@angular/core';
import { Observable, catchError } from 'rxjs';
import CreateCameraRequest from './models/CreateCameraRequest';
import CreateDeviceResponse from './models/CreateDeviceResponse';
import CreateSensorRequest from './models/CreateSensorRequest';
import SearchDeviceResponse from './models/SearchDeviceResponse';
import SearchSupportedDevicesResponse from './models/SearchSupportedDevicesResponse';
import { DeviceTypeApiRepositoryService } from '../../repositories/DeviceRepository.service';

@Injectable({
  providedIn: 'root',
})
export class DeviceService {
  constructor(private readonly _repository: DeviceTypeApiRepositoryService) {}

  public createCamera(
    request: CreateCameraRequest
  ): Observable<CreateDeviceResponse> {
    return this._repository.createCamera(request);
  }

  public createMovementSensor(
    request: CreateSensorRequest
  ): Observable<CreateDeviceResponse> {
    return this._repository.createMovementSensor(request);
  }

  public createWindowSensor(
    request: CreateSensorRequest
  ): Observable<CreateDeviceResponse> {
    return this._repository.createWindowSensor(request);
  }

  public createLamp(
    request: CreateSensorRequest
  ): Observable<CreateDeviceResponse> {
    return this._repository.createLamp(request);
  }

  public getRegisteredDevices(
    limit?: number,
    offset?: number,
    deviceName?: string,
    model?: string,
    companyName?: string,
    deviceType?: string
  ): Observable<any> {
		const queryParams: string[] = [];

    if (limit) {
      queryParams.push(`limit=${encodeURIComponent(limit)}`);
    }
    if (offset) {
      queryParams.push(`offset=${encodeURIComponent(offset)}`);
    }
		if (deviceType) {
      queryParams.push(`type=${encodeURIComponent(deviceType)}`);
    }
		if (companyName) {
      queryParams.push(`comapny=${encodeURIComponent(companyName)}`);
    }
		if (model) {
      queryParams.push(`model=${encodeURIComponent(model)}`);
    }
		if (deviceName) {
      queryParams.push(`deviceName=${encodeURIComponent(deviceName)}`);
    }

		const query = queryParams.join('&');
    
		return this._repository.getRegisteredDevices(query);
  }

  public getSupportedDevices(): Observable<any> {
    return this._repository.getSupportedDevices();
  }

  public turnOnDevice(hardwareId: string): Observable<any> {
    return this._repository.turnOnDevice(hardwareId);
  }
}
