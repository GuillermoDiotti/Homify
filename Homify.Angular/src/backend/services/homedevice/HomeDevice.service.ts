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

	public turnOnDevice(hardwareId: string): Observable<any> {
    return this._repository.turnOnDevice(hardwareId);
  }

	public turnOffDevice(hardwareId: string): Observable<any> {
    return this._repository.turnOffDevice(hardwareId);
  }

	public turnOnLamp(hardwareId: string): Observable<any> {
		return this._repository.turnOnLamp(hardwareId);
	}

	public turnOffLamp(hardwareId: string): Observable<any> {
		return this._repository.turnOffLamp(hardwareId);
	}

	public turnOnSensor(hardwareId: string): Observable<any> {
		return this._repository.turnOnSensor(hardwareId);
	}

	public turnOffSensor(hardwareId: string): Observable<any> {
		return this._repository.turnOffSensor(hardwareId);
	}
}