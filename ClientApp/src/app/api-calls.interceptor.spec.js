"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var api_calls_interceptor_1 = require("./api-calls.interceptor");
describe('ApiCallsInterceptor', function () {
    beforeEach(function () { return testing_1.TestBed.configureTestingModule({
        providers: [
            api_calls_interceptor_1.ApiCallsInterceptor
        ]
    }); });
    it('should be created', function () {
        var interceptor = testing_1.TestBed.inject(api_calls_interceptor_1.ApiCallsInterceptor);
        expect(interceptor).toBeTruthy();
    });
});
//# sourceMappingURL=api-calls.interceptor.spec.js.map