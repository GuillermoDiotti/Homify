import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError } from "rxjs";
import ApiRepository from "../../repositories/api-repository";
import { environment } from "../../../environment";
import CreateCameraRequest from "./models/CreateCameraRequest";
import CreateDeviceResponse from "./models/CreateDeviceResponse";

@Injectable({
  providedIn: "root",
})
export class DeviceApiRepositoryService extends ApiRepository{
  constructor(http: HttpClient) {
    super(environment.homifyApi, 'companies', http);
  }

  public createCamera(request: CreateCameraRequest): Observable<CreateDeviceResponse> {
    return this.post<CreateDeviceResponse>(request).pipe(catchError(this.handleError));
  }
}