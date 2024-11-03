import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";
import { environment } from "../../environment";
import CreateSessionResponse from "../services/session/models/CreateSessionResponse";
import ApiRepository from "./api-repository";
import { CreateHomeOwnerResponse } from "../services/session/models/CreateHomeOwnerResponse";

@Injectable({
  providedIn: "root",
})
export class SessionTypeApiRepositoryService extends ApiRepository {
  constructor(_http: HttpClient) {
		super(environment.homifyApi, "sessions", _http)
	}

  public login(username: string, password: string): Observable<CreateSessionResponse> {
    return this._http.post<any>(`${environment.homifyApi}/${this._endpoint}`, { Email: username, Password: password })
      .pipe(
        catchError(this.handleError)
      );
  }

	public register(username: string, password: string, name: string, lastName: string, profilePicUrl: string): Observable<CreateHomeOwnerResponse> {
    return this._http.post<any>(`${environment.homifyApi}/homeowners`, { email: username, password, name, lastName, profilePicUrl })
      .pipe(
        catchError(this.handleError)
      );
  }
}