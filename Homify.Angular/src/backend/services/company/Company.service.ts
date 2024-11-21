import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CompanyTypeApiRepositoryService } from '../../repositories/CompanyRepository.service';
import CreateCompanyRequest from './models/CreateCompanyRequest';
import CreateCompanyResponse from './models/CreateCompanyResponse';
import CompanyBasicInfo from './models/CompanyBasicInfo';
import AddValidatorBasicInfo from './models/AddValidatorBasicInfo';

@Injectable({
  providedIn: 'root',
})
export class CompanyService {
  constructor(private readonly _repository: CompanyTypeApiRepositoryService) {}

  public create(
    request: CreateCompanyRequest
  ): Observable<CreateCompanyResponse> {
    return this._repository.create(request);
  }

  public getAllCompanies(
    limit?: string,
    offset?: string,
    ownerfullname?: string,
    company?: string
  ): Observable<Array<CompanyBasicInfo>> {
    const queryParams: string[] = [];

    if (limit) {
      queryParams.push(`limit=${encodeURIComponent(limit)}`);
    }
    if (offset) {
      queryParams.push(`offset=${encodeURIComponent(offset)}`);
    }
    if (company) {
      queryParams.push(`company=${encodeURIComponent(company)}`);
    }
    if (ownerfullname) {
      queryParams.push(`ownerFullName=${encodeURIComponent(ownerfullname)}`);
    }

    const query = queryParams.join('&');
    return this._repository.getAllCompanies(query);
  }

  public addValidator(request: AddValidatorBasicInfo): Observable<AddValidatorBasicInfo> {
      return this._repository.addValidator(request);
  }
}
