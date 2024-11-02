export default interface CreateSensorRequest {
    name: string;
    model: string;
    description: string;
    photos: Array<string>;
    ppalPicture: string;
}