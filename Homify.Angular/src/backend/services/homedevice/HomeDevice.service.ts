import { Injectable } from "@angular/core";
import { HomeDeviceTypeApiRepositoryService } from "../../repositories/HomeDeviceRepository.service";
import { UpdateHomeDeviceRequest } from "./models/UpdateHomeDeviceRequest";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root',
})
export class HomeDeviceService {
  constructor(private readonly _repository: HomeDeviceTypeApiRepositoryService) {}

	public renameDevice(req: UpdateHomeDeviceRequest, id: string): Observable<any> {
		return this._repository.renameDevice(req, id);
	}
}