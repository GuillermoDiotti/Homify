export interface GetMembersResponse {
    id:string;
    fullname: string;
    email: string;
    photo: string;
    permissions: string[];
    mustBeNotified: string;
  }