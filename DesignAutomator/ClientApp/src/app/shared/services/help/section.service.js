"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var SectionService = /** @class */ (function () {
    function SectionService(http) {
        this.http = http;
        this.service = 'SectionService';
    }
    SectionService.prototype.getList = function () {
        return this.http.get("api/" + this.service + "/List")
            .map(function (response) { return response; });
    };
    return SectionService;
}());
exports.SectionService = SectionService;
//# sourceMappingURL=section.service.js.map