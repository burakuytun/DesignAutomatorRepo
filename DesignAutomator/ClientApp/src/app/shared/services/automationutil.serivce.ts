import { Injectable } from "@angular/core";

@Injectable()
export class AutomationUtilService {
  constructor() { }
  getTheFunctionNameFromRouteParam(functionId: number): string {
    return (
      functionId === 1
        ? "CAD"
        : functionId === 2
          ? "AACS"
          : functionId === 3
            ? "CCTV"
            : functionId === 4
              ? "IHAS"
              : "-");
  }
}
