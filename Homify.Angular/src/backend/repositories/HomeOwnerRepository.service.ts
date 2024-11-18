import { Injectable } from "@angular/core";
import ApiRepository from "./api-repository";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environment";
import { UpdateProfileRequest } from "../services/session/models/UpdateProfileRequest";
import { catchError, Observable } from "rxjs";

@Injectable({
  providedIn: 'root',
})
export class HomeOwnerApiRepositoryService extends ApiRepository {
  constructor(http: HttpClient) {
    super(environment.homifyApi, 'homeowners', http);
  }

  public updateProfilePicture(req: UpdateProfileRequest): Observable<any> {
		return this.putById<any>(`profile`, req).pipe(catchError(this.handleError));
	}
}