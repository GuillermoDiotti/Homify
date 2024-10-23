import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";
import CreateSessionResponse from "../services/session/models/CreateSessionResponse";
import { environment } from "../environment";

@Injectable({
  providedIn: "root",
})
export class SessionTypeApiRepositoryService {
  private readonly _endpoint = "sessions";
  
  constructor(private readonly _http: HttpClient) {}

  public login(username: string, password: string): Observable<CreateSessionResponse> {
    return this._http.post<any>(`${environment.homifyApi}/${this._endpoint}`, { Email: username, Password: password })
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error("An error occurred:", error.error.message);
      return throwError(error.error);
    } else {
      console.error(`Backend returned code ${error.status}, body was: ${error.error}`);
      return throwError(error);
    }
  }
}