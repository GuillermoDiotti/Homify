import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CompanyTypeApiRepositoryService } from '../../repositories/CompanyRepository.service';
import CreateCompanyRequest from './models/CreateCompanyRequest';
import CreateCompanyResponse from './models/CreateCompanyResponse';
import CompanyBasicInfo from './models/CompanyBasicInfo';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  constructor(private readonly _repository: CompanyTypeApiRepositoryService) { }

  public create(request: CreateCompanyRequest): Observable<CreateCompanyResponse> {
    return this._repository.create(request);
  }

  public getAllCompanies(
    limit?: string,
    offset?: string,
    ownerfullname?: string,
    company?: string)
    : Observable<Array<CompanyBasicInfo>> {
    const query = `limit=${limit ?? ''}&offset=${offset ?? ''}&role=${encodeURIComponent(ownerfullname ?? '')}&fullName=${encodeURIComponent(company ?? '')}`;
    return this._repository.getAllCompanies(query);
  }
}
