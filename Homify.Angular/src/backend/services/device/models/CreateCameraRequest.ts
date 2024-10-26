export default interface CreateCameraRequest {
    Name: string;
    Model: string;
    IsExterior: boolean;
    IsInterior: boolean;
    Description: string;
    Photos: Array<string>;
    PpalPicture: string;
}