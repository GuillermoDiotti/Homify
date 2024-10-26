import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { CompanyOwnerTypeApiRepositoryService } from "../../repositories/CompanyOwnerRepository.service";
import CreateCompanyOwnerRequest from "./models/CreateCompanyOwnerRequest";
import CreateCompanyOwnerResponse from "./models/CreateCompanyOwnerResponse";

@Injectable({
    providedIn: 'root'
  })
  export class CompanyOwnerService {

    constructor(private readonly _repository: CompanyOwnerTypeApiRepositoryService) { }

    public create(request: CreateCompanyOwnerRequest): Observable<CreateCompanyOwnerResponse> {
      return this._repository.create(request);
    }
  }