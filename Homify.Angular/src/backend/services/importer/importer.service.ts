import { Injectable } from "@angular/core";
import { ImporterApiRepositoryService } from "../../repositories/ImporterRepository.service";
import { ImportRequest } from "./models/ImportRequest";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
  })
  export class HomeService {
  
    constructor(private readonly _repository: ImporterApiRepositoryService) { }
  
    public add(request: ImportRequest): Observable<any> {
      return this._repository.AddImportedDevices(request);
    }
}