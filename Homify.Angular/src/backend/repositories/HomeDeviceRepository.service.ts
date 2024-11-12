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
}