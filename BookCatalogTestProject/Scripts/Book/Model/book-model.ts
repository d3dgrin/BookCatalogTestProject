class BookModel {
    constructor() {
    }

    public Books: KnockoutObservableArray<BookItemModel> = ko.observableArray<BookItemModel>([]);
    public BookModal: BookItemModel = new BookItemModel({ BookId: 0, Title: '', PublicationDate: '', Rating: 0, PagesCount: 0, Authors: null, SelectedAuthors: null });
    public Authors: KnockoutObservableArray<any> = ko.observableArray<any>([]);
    public SelectedAuthors: KnockoutObservableArray<number> = ko.observableArray<number>([]);

    public AddClick: () => void = () => { this.OnAddClick(); };

    public OnAddClick: () => void = () => { };
}