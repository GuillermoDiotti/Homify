import { Injectable } from "@angular/core";
import ApiRepository from "./api-repository";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environment";
import { ImportRequest } from "../services/importer/models/ImportRequest";
import { catchError, Observable } from "rxjs";

@Injectable({
    providedIn: "root",
  })
  export class ImporterApiRepositoryService extends ApiRepository{    
    constructor(http: HttpClient) {
        super(environment.homifyApi, 'importers', http);
      }
    
      public AddImportedDevices(request: ImportRequest): Observable<any> {
        return this.post<any>(request).pipe(catchError(this.handleError));
      }

			public getImporters(): Observable<string[]> {
        return this.get<string[]>().pipe(catchError(this.handleError));
      }

      public getValidators(): Observable<string[]> {
        return this.get<string[]>("validators").pipe(catchError(this.handleError));
      }
    }