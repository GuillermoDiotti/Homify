import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { RoleApiRepositoryService } from "../../repositories/RoleRepository.service";
import { RoleBasicInfo } from "./models/roles/RolesBasicInfo";

@Injectable({
    providedIn: 'root'
  })
  export class RoleService {
  
    constructor(private readonly _repository: RoleApiRepositoryService) { }
  
    public addRoleToExistingUser(): Observable<RoleBasicInfo> {
      return this._repository.addRoleToExistingUser();
    }
}