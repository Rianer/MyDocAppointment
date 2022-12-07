export class ServerResponse<ResponseObj>{
    entity: ResponseObj[];
    error: any;
    isFailure: boolean;
    isSuccess: boolean;
}