import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError } from "rxjs";
import ApiRepository from "./api-repository";
import { environment } from "../../environment";
import CreateAdminRequest from "../services/admin/models/CreateAdminRequest";
import CreateAdminResponse from "../services/admin/models/CreateAdminResponse";
import UserBasicInfo from "../services/admin/models/UserBasicInfo";

@Injectable({
  providedIn: "root",
})
export class AdminTypeApiRepositoryService extends ApiRepository{
  constructor(http: HttpClient) {
    super(environment.homifyApi, 'admins', http);
  }

  public create(request: CreateAdminRequest): Observable<CreateAdminResponse> {
    return this.post<CreateAdminResponse>(request).pipe(catchError(this.handleError));
  }

  public deleteAdmin(id: string) {
    return this.delete(id).pipe(catchError(this.handleError));
  }

  public getAllAccounts(
    limit?: string,
    offset?: string,
    role?: string,
    fullName?: string)
    : Observable<Array<UserBasicInfo>> {
    const query = `limit=${limit ?? ''}&offset=${offset ?? ''}&role=${encodeURIComponent(role ?? '')}&fullName=${encodeURIComponent(fullName ?? '')}`;
    return this.get<Array<UserBasicInfo>>("accounts", query).pipe(catchError(this.handleError));
  }
}