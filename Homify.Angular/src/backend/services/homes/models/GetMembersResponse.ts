export interface GetMembersResponse {
    id:string;
    fullName: string;
    email: string;
    photo: string;
    permissions: string[];
    mustBeNotified: string;
  }