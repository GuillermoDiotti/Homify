import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError } from "rxjs";
import ApiRepository from "./api-repository";
import { environment } from "../../environment";
import CreateCompanyOwnerRequest from "../services/company-owner/models/CreateCompanyOwnerRequest";
import CreateCompanyOwnerResponse from "../services/company-owner/models/CreateCompanyOwnerResponse";


@Injectable({
  providedIn: "root",
})
export class CompanyOwnerTypeApiRepositoryService extends ApiRepository{
  constructor(http: HttpClient) {
    super(environment.homifyApi, 'company-owners', http);
  }

  public create(request: CreateCompanyOwnerRequest): Observable<CreateCompanyOwnerResponse> {
    return this.post<CreateCompanyOwnerResponse>(request).pipe(catchError(this.handleError));
  }
}