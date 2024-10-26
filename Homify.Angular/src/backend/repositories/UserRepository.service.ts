import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import ApiRepository from "./api-repository";
import { environment } from "../../environment";

@Injectable({
  providedIn: "root",
})
export class UserTypeApiRepositoryService extends ApiRepository{
  constructor(http: HttpClient) {
    super(environment.homifyApi, 'users', http);
  }

  public createAdmin(): Observable<>> {
    return this.post<>();
  }

  public createCompanyOwner(): Observable<>> {
    return this.post<>();
  }

  public createHomeOwner(): Observable<>> {
    return this.post<>();
  }

  public getAll(): Observable<Array<MovieTypeBasicInfoModel>> {
    return this.get<Array<MovieTypeBasicInfoModel>>();
  }
}