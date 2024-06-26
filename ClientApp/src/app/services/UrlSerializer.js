"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
exports.LowerCaseUrlSerializer = void 0;
var router_1 = require("@angular/router");
var LowerCaseUrlSerializer = /** @class */ (function (_super) {
    __extends(LowerCaseUrlSerializer, _super);
    function LowerCaseUrlSerializer() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    LowerCaseUrlSerializer.prototype.parse = function (url) {
        var urlstring;
        var urlmain = null;
        if (url) {
            urlstring = url.split('?');
            if (urlstring.length > 1) {
                urlmain = urlstring[0].toLowerCase();
                return _super.prototype.parse.call(this, urlmain.concat('?', urlstring[1]));
            }
            else {
                urlmain = urlstring[0].toLowerCase();
                return _super.prototype.parse.call(this, urlmain);
            }
        }
        return _super.prototype.parse.call(this, url.toLowerCase());
    };
    return LowerCaseUrlSerializer;
}(router_1.DefaultUrlSerializer));
exports.LowerCaseUrlSerializer = LowerCaseUrlSerializer;
//# sourceMappingURL=UrlSerializer.js.map