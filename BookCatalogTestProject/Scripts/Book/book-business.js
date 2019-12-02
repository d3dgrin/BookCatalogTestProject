var BookBusiness = /** @class */ (function () {
    function BookBusiness(service) {
        this.service = service;
        this.Model = new BooksModel();
        this.ConvertResponse = function (books) {
            return books.map(function (book) {
                var result = new BookModel(book);
                return result;
            });
        };
    }
    BookBusiness.prototype.GetBooksUrl = function () {
        return this.service.urls.GetBooksUrl;
    };
    return BookBusiness;
}());
//# sourceMappingURL=book-business.js.map