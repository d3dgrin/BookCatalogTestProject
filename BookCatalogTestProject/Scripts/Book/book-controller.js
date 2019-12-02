var BookController = /** @class */ (function () {
    function BookController(business, gridController) {
        var _this = this;
        this.business = business;
        this.gridController = gridController;
        this.OnDrawCallback = function (data) {
            _this.business.Model.Books = _this.MapToObservable(_this.business.ConvertResponse(data));
            ko.applyBindings(_this.business.Model, $('#book_tbody')[0]);
        };
        this.gridController.DrawCallback = this.OnDrawCallback;
    }
    BookController.prototype.MapToObservable = function (books) {
        return ko.observableArray(books);
    };
    return BookController;
}());
//# sourceMappingURL=book-controller.js.map