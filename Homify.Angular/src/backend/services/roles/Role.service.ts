import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { RoleApiRepositoryService } from "../../repositories/RoleRepository.service";

@Injectable({
    providedIn: 'root'
  })
  export class RoleService {
  
    constructor(private readonly _repository: RoleApiRepositoryService) { }
  
    public addRoleToExistingUser(): Observable<any> {
      return this._repository.addRoleToExistingUser();
    }
}