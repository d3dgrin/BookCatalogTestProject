class BookModel {
    constructor(model: Book) {
        this.Id(model.Id);
        this.Title(model.Title);
        this.PublicationDate(moment(model.PublicationDate).format('DD-MM-YYYY'));
        this.Rating(model.Rating);
        this.PagesCount(model.PagesCount);
    }

    public Id: KnockoutObservable<number> = ko.observable(null);
    public Title: KnockoutObservable<string> = ko.observable(null);
    public PublicationDate: KnockoutObservable<string> = ko.observable(null);
    public Rating: KnockoutObservable<number> = ko.observable(null);
    public PagesCount: KnockoutObservable<number> = ko.observable(null);
}