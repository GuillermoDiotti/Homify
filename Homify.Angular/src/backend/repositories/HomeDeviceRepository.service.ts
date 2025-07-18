import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import ApiRepository from "./api-repository";
import { environment } from "../../environment";
import { UpdateHomeDeviceRequest } from "../services/homedevice/models/UpdateHomeDeviceRequest";
import { catchError, Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class HomeDeviceTypeApiRepositoryService extends ApiRepository {
  constructor(http: HttpClient) {
    super(environment.homifyApi, 'home-devices', http);
  }

	public renameDevice(req: UpdateHomeDeviceRequest, id: string): Observable<any> {
		return this.putById<any>(`${id}/update`, req).pipe(
      catchError(this.handleError)
    );
	}

	public turnOnDevice(hardwareId: string): Observable<any> {
    return this.putById(`${hardwareId}/activate`).pipe(
      catchError(this.handleError)
    );
  }

	public turnOffDevice(hardwareId: string): Observable<any> {
    return this.putById(`${hardwareId}/deactivate`).pipe(
      catchError(this.handleError)
    );
  }

	public turnOnLamp(hardwareId: string): Observable<any> {
    return this.putById(`${hardwareId}/lampOn`).pipe(
      catchError(this.handleError)
    );
  }

	public turnOffLamp(hardwareId: string): Observable<any> {
    return this.putById(`${hardwareId}/lampOff`).pipe(
      catchError(this.handleError)
    );
  }

	public turnOnSensor(hardwareId: string): Observable<any> {
    return this.putById(`${hardwareId}/windowOpen`).pipe(
      catchError(this.handleError)
    );
  }

	public turnOffSensor(hardwareId: string): Observable<any> {
    return this.putById(`${hardwareId}/windowClose`).pipe(
      catchError(this.handleError)
    );
  }
}