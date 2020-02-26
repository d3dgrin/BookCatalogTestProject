class BookModel {
    constructor() {
    }

    public Books: KnockoutObservableArray<BookItemModel> = ko.observableArray<BookItemModel>([]);
    public BookModal: BookItemModel = new BookItemModel({ BookId: 0, Title: '', PublicationDate: '', Rating: 0, PagesCount: 0, Authors: '' });

    public AddClick: () => void = () => { this.OnAddClick(); };

    public OnAddClick: () => void = () => { };
}