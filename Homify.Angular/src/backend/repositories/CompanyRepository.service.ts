import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError } from 'rxjs';
import ApiRepository from './api-repository';
import { environment } from '../../environment';
import CreateCompanyResponse from '../services/company/models/CreateCompanyResponse';
import CreateCompanyRequest from '../services/company/models/CreateCompanyRequest';
import CompanyBasicInfo from '../services/company/models/CompanyBasicInfo';
import AddValidatorBasicInfo from '../services/company/models/AddValidatorBasicInfo';

@Injectable({
  providedIn: 'root',
})
export class CompanyTypeApiRepositoryService extends ApiRepository {
  constructor(http: HttpClient) {
    super(environment.homifyApi, 'companies', http);
  }

  public create(
    request: CreateCompanyRequest
  ): Observable<CreateCompanyResponse> {
    return this.post<CreateCompanyResponse>(request).pipe(
      catchError(this.handleError)
    );
  }

  public getAllCompanies(query: string): Observable<Array<CompanyBasicInfo>> {
    return this.get<Array<CompanyBasicInfo>>('', query).pipe(
      catchError(this.handleError)
    );
  }

  public addValidator(request: AddValidatorBasicInfo): Observable<AddValidatorBasicInfo>{
    return this.putById<AddValidatorBasicInfo>("validators", request).pipe(
      catchError(this.handleError)
    );
  }
}
