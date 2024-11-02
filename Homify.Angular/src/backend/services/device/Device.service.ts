import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError } from "rxjs";
import ApiRepository from "../../repositories/api-repository";
import { environment } from "../../../environment";
import CreateCameraRequest from "./models/CreateCameraRequest";
import CreateDeviceResponse from "./models/CreateDeviceResponse";
import CreateSensorRequest from "./models/CreateSensorRequest";

@Injectable({
  providedIn: "root",
})
export class DeviceApiRepositoryService extends ApiRepository{
  constructor(http: HttpClient) {
    super(environment.homifyApi, 'devices', http);
  }

  public createCamera(request: CreateCameraRequest): Observable<CreateDeviceResponse> {
    return this.post<CreateDeviceResponse>(request, "cameras").pipe(catchError(this.handleError));
  }

	public createMovementSensor(request: CreateSensorRequest): Observable<CreateDeviceResponse> {
    return this.post<CreateDeviceResponse>(request, "movement-sensor").pipe(catchError(this.handleError));
  }

	public createWindowSensor(request: CreateSensorRequest): Observable<CreateDeviceResponse> {
    return this.post<CreateDeviceResponse>(request, "window-sensor").pipe(catchError(this.handleError));
  }

	public createLamp(request: CreateSensorRequest): Observable<CreateDeviceResponse> {
    return this.post<CreateDeviceResponse>(request, "lamps").pipe(catchError(this.handleError));
  }
}