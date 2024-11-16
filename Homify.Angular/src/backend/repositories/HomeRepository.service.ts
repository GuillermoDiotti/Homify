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
import { UpdateMemberListResponse } from "../services/homes/models/UpdateMemberListResponse";
import { UpdateMembersPermissionRequest } from "../services/homes/models/UpdateMembersPermissionRequest";
import { HomeMemberBasicInfo } from "../services/homes/models/HomeMemberBasicInfo";
import { GetMembersResponse } from "../services/homes/models/GetMembersResponse";
import { GetDevicesResponse } from "../services/device/models/GetDevicesResponse";
import { UpdateHomeDevicesRequest } from "../services/homes/models/UpdateHomeDevicesRequest";
import { UpdateHomeDeviceResponse } from "../services/homes/models/UpdateHomeDeviceResponse";
import { NotificatedMembersRequest } from "../services/homes/models/NotificatedMembersRequest";
import { NotificatedMembersResponse } from "../services/homes/models/NotificatedMembersResponse";
import { RenameHomeRequest } from "../services/homes/models/RenameHomeRequest";


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

			public getAllHomesByMember()
        : Observable<Array<GetAllHomesResponse>> {
        return this.get<Array<GetAllHomesResponse>>("by-member").pipe(catchError(this.handleError));
      }

      public UpdateHomeMembers(id:string, request: UpdateMemberListRequest)
        :Observable<UpdateMemberListResponse>{
          return this.putById<UpdateMemberListResponse>(id, request, "members").pipe(catchError(this.handleError));
      }

			public renameHome(id:string, request: RenameHomeRequest)
        :Observable<any>{
          return this.putById<any>(id, request, "rename").pipe(catchError(this.handleError));
      }

      public UpdateMembersPermissions(homeId:string, memberId:string, request:UpdateMembersPermissionRequest)
      :Observable<HomeMemberBasicInfo>{
        return this.putById<HomeMemberBasicInfo>(homeId, request, memberId).pipe(catchError(this.handleError));
      }

      public GetHomeMembers(homeId:string)
      : Observable<Array<GetMembersResponse>>{
        return this.get<Array<GetMembersResponse>>(`${homeId}/members`).pipe(catchError(this.handleError));
      }

			public GetHomeDevices(homeId:string): Observable<GetDevicesResponse[]>{
				return this.get<GetDevicesResponse[]>(`${homeId}/devices`).pipe(catchError(this.handleError));
			}

			public addNewDevice(homeId: string, req: UpdateHomeDevicesRequest): Observable<UpdateHomeDeviceResponse> {
				return this.putById<UpdateHomeDeviceResponse>(homeId, req, "devices").pipe(catchError(this.handleError));
			}

			public makeUserNotificable(homeId: string, req: NotificatedMembersRequest): Observable<NotificatedMembersResponse> {
				return this.putById<NotificatedMembersResponse>(`${homeId}/notifications`, req).pipe(catchError(this.handleError));
			}
    }