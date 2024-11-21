import { Injectable } from "@angular/core"
import { HomeOwnerApiRepositoryService } from "../../repositories/HomeOwnerRepository.service"
import { UpdateProfileRequest } from "../session/models/UpdateProfileRequest";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root',
})
export class HomeOwnerService {
  constructor(private readonly _repository: HomeOwnerApiRepositoryService) {}

	public updateProfilePicture(req: UpdateProfileRequest): Observable<any> {
		return this._repository.updateProfilePicture(req);
	}
}