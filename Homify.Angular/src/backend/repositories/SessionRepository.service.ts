import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";
import { environment } from "../../environment";
import CreateSessionResponse from "../services/session/models/CreateSessionResponse";
import ApiRepository from "./api-repository";

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
}