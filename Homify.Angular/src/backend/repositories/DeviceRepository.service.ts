import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError } from "rxjs";
import ApiRepository from "./api-repository";
import { environment } from "../../environment";
import CreateCameraRequest from "../services/device/models/CreateCameraRequest";
import CreateDeviceResponse from "../services/device/models/CreateDeviceResponse";
import CreateSensorRequest from "../services/device/models/CreateSensorRequest";
import SearchSupportedDevicesResponse from "../services/device/models/SearchSupportedDevicesResponse";
import SearchDeviceResponse from "../services/device/models/SearchDeviceResponse";

@Injectable({
  providedIn: "root",
})
export class DeviceTypeApiRepositoryService extends ApiRepository{
  constructor(http: HttpClient) {
    super(environment.homifyApi, 'devices', http);
  }

  public createCamera(request: CreateCameraRequest): Observable<CreateDeviceResponse> {
    return this.post<CreateDeviceResponse>(request, "cameras").pipe(catchError(this.handleError));
  }

  public createSensor(request: CreateSensorRequest): Observable<CreateDeviceResponse> {
    return this.post<CreateDeviceResponse>(request, "sensors").pipe(catchError(this.handleError));
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
    query: string
  ): Observable<any> {
    return this.get<SearchDeviceResponse>('', query).pipe(
      catchError(this.handleError)
    );
  }

  public getSupportedDevices(): Observable<any> {
    return this.get<SearchSupportedDevicesResponse>('supported').pipe(
      catchError(this.handleError)
    );
  }
}