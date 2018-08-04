import { DnaClient } from "./dnaclient.model";

export class UserDnaClient {
  id: number;
  dnaClient: DnaClient;
  dnaAuthorizationLevelId: number;
  startDate: string;
  endDate: string;
  isDefault: string;
}
