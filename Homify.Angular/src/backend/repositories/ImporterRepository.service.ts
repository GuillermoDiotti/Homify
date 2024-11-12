import { Injectable } from "@angular/core";
import ApiRepository from "./api-repository";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environment";
import { ImportRequest } from "../services/importer/models/ImportRequest";
import { catchError, Observable } from "rxjs";

@Injectable({
    providedIn: "root",
  })
  export class HomeApiRepositoryService extends ApiRepository{    
    constructor(http: HttpClient) {
        super(environment.homifyApi, 'importer', http);
      }
    
      public AddImportedDevices(request: ImportRequest): Observable<any> {
        return this.post(request).pipe(catchError(this.handleError));
      }
    }