class BookItemModel {

    constructor(model: BookItem) {
        this.BookId(model.BookId);
        this.Title(model.Title);
        this.PublicationDate(model.PublicationDate);
        this.Rating(model.Rating);
        this.PagesCount(model.PagesCount);
        this.Authors(model.Authors);
    }

    public BookId: KnockoutObservable<number> = ko.observable(null);
    public Title: KnockoutObservable<string> = ko.observable(null);
    public PublicationDate: KnockoutObservable<string> = ko.observable(null);
    public Rating: KnockoutObservable<number> = ko.observable(null);
    public PagesCount: KnockoutObservable<number> = ko.observable(null);
    public Authors: any = ko.observable(null);

    public EditClick: () => void = () => { this.OnEditClick(this); };
    public EditSaveClick: () => void = () => { this.OnEditSaveClick(this); };
    public DeleteClick: () => void = () => { this.OnDeleteClick(this); };


    public OnEditClick: (model: BookItemModel) => void = (model: BookItemModel) => { };
    public OnEditSaveClick: (model: BookItemModel) => void = (model: BookItemModel) => { };
    public OnDeleteClick: (model: BookItemModel) => void = (model: BookItemModel) => { };
}