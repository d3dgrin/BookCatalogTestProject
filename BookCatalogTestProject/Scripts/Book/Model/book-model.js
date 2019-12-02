var BookModel = /** @class */ (function () {
    function BookModel(model) {
        this.Id = ko.observable(null);
        this.Title = ko.observable(null);
        this.PublicationDate = ko.observable(null);
        this.Rating = ko.observable(null);
        this.PagesCount = ko.observable(null);
        this.Id(model.Id);
        this.Title(model.Title);
        this.PublicationDate(model.PublicationDate);
        this.Rating(model.Rating);
        this.PagesCount(model.PagesCount);
    }
    return BookModel;
}());
//# sourceMappingURL=book-model.js.map