import { Injectable } from "@angular/core";
import { ImporterApiRepositoryService } from "../../repositories/ImporterRepository.service";
import { ImportRequest } from "./models/ImportRequest";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
  })
  export class ImportService {
  
    constructor(private readonly _repository: ImporterApiRepositoryService) { }
  
    public add(request: ImportRequest): Observable<any> {
      return this._repository.AddImportedDevices(request);
    }

		public getImporters(): Observable<string[]> {
			return this._repository.getImporters();
		}

    public getValidators(): Observable<string[]> {
			return this._repository.getImporters();
		}
}