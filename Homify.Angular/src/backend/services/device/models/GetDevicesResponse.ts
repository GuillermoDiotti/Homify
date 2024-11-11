export interface GetDevicesResponse {
	name: string;
	model: string;
	mainPhoto?: string;
	isConnected: boolean;
	deviceId: string;
	hardwareId: string;
}