export default interface CreateCameraRequest {
  name: string;
  model: string;
  isExterior: boolean;
  isInterior: boolean;
  description: string;
  photos: Array<string>;
  ppalPicture: string;
}
