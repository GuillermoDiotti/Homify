import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";
import { environment } from "../../environment";
import ApiRepository from "./api-repository";
import { CreateHomeRequest } from "../services/homes/models/CreateHomeRequest";
import { CreateHomeResponse } from "../services/homes/models/CreateHomeResponse";
import { GetAllHomesResponse } from "../services/homes/models/GetAllHomesResponse";
import { UpdateMemberListRequest } from "../services/homes/models/UpdateMemberListRequest";


@Injectable({
    providedIn: "root",
  })
  export class HomeApiRepositoryService extends ApiRepository{    
    constructor(http: HttpClient) {
        super(environment.homifyApi, 'homes', http);
      }
    
      public create(request: CreateHomeRequest): Observable<CreateHomeResponse> {
        return this.post<CreateHomeResponse>(request).pipe(catchError(this.handleError));
      }

      public getAllHomesByOwner()
        : Observable<Array<GetAllHomesResponse>> {
        return this.get<Array<GetAllHomesResponse>>("by-owner").pipe(catchError(this.handleError));
      }

      public UpdateHomeMembers(id:string, request: UpdateMemberListRequest)
        :Observable<GetAllHomesResponse[]>{
          return this.putById<Array<GetAllHomesResponse>>(id, request, "members").pipe(catchError(this.handleError));
      }
    
    }