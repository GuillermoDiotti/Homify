export interface GetDevicesResponse {
	id: string;
	name: string;
	customName: string;
	model: string;
	mainPhoto?: string;
	isConnected: boolean;
	isActive: boolean;
	deviceId: string;
	hardwareId: string;
	room: string;
	deviceType: string;
}