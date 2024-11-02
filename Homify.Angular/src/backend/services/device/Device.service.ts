import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError } from 'rxjs';
import ApiRepository from '../../repositories/api-repository';
import { environment } from '../../../environment';
import CreateCameraRequest from './models/CreateCameraRequest';
import CreateDeviceResponse from './models/CreateDeviceResponse';
import CreateSensorRequest from './models/CreateSensorRequest';
import SearchDeviceResponse from './models/SearchDeviceResponse';
import SearchSupportedDevicesResponse from './models/SearchSupportedDevicesResponse';

@Injectable({
  providedIn: 'root',
})
export class DeviceApiRepositoryService extends ApiRepository {
  constructor(http: HttpClient) {
    super(environment.homifyApi, 'devices', http);
  }

  public createCamera(
    request: CreateCameraRequest
  ): Observable<CreateDeviceResponse> {
    return this.post<CreateDeviceResponse>(request, 'cameras').pipe(
      catchError(this.handleError)
    );
  }

  public createMovementSensor(
    request: CreateSensorRequest
  ): Observable<CreateDeviceResponse> {
    return this.post<CreateDeviceResponse>(request, 'movement-sensors').pipe(
      catchError(this.handleError)
    );
  }

  public createWindowSensor(
    request: CreateSensorRequest
  ): Observable<CreateDeviceResponse> {
    return this.post<CreateDeviceResponse>(request, 'window-sensors').pipe(
      catchError(this.handleError)
    );
  }

  public createLamp(
    request: CreateSensorRequest
  ): Observable<CreateDeviceResponse> {
    return this.post<CreateDeviceResponse>(request, 'lamps').pipe(
      catchError(this.handleError)
    );
  }

	public getRegisteredDevices(
    limit?: number,
    offset?: number,
		deviceName?: string,
    model?: string,
    companyName?: string,
    deviceType?: string
  ): Observable<any> {
		const query = `limit=${encodeURIComponent(limit ?? "")}&offset=${encodeURIComponent(offset ?? "")}&deviceName=${encodeURIComponent(deviceName ?? "")}&model=${encodeURIComponent(model ?? "")}&company=${encodeURIComponent(companyName ?? "")}&type=${encodeURIComponent(deviceType ?? "")}`;
    return this.get<SearchDeviceResponse>('', query).pipe(
      catchError(this.handleError));
  }

  public getSupportedDevices(): Observable<any> {
    return this.get<SearchSupportedDevicesResponse>('supported').pipe(
      catchError(this.handleError));
  }
}
