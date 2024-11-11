export interface GetDevicesResponse {
	name: string;
	model: string;
	mainPhoto?: string;
	isConnected: boolean;
	isActive: boolean;
	deviceId: string;
	hardwareId: string;
}