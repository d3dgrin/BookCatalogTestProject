class BooksModel {
    public Books: KnockoutObservableArray<BookModel> = ko.observableArray<BookModel>([]);
    public Book: BookModel = new BookModel();

    OnEditSave: (model: BooksModel, event: Event) => void;
    OnAdd: (model: BooksModel, event: Event) => void;
    OnAddSave: (model: BooksModel, event: Event) => void;
}