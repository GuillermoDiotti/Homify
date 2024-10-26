import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError } from "rxjs";
import ApiRepository from "./api-repository";
import { environment } from "../../environment";
import UserBasicInfo from "../services/admin/models/UserBasicInfo";
import CreateCompanyResponse from "../services/company/models/CreateCompanyResponse";
import CreateCompanyRequest from "../services/company/models/CreateCompanyRequest";

@Injectable({
  providedIn: "root",
})
export class CompanyTypeApiRepositoryService extends ApiRepository{
  constructor(http: HttpClient) {
    super(environment.homifyApi, 'companies', http);
  }

  public create(request: CreateCompanyRequest): Observable<CreateCompanyResponse> {
    return this.post<CreateCompanyResponse>(request).pipe(catchError(this.handleError));
  }

  public getAllCompanies(
    limit?: string,
    offset?: string,
    ownerfullname?: string,
    company?: string)
    : Observable<Array<UserBasicInfo>> {
    const query = `limit=${limit ?? ''}&offset=${offset ?? ''}&role=${encodeURIComponent(ownerfullname ?? '')}&fullName=${encodeURIComponent(company ?? '')}`;
    return this.get<Array<UserBasicInfo>>("",query).pipe(catchError(this.handleError));
  }
}