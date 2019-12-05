﻿class BookBusiness {
    public Model: BooksModel = new BooksModel();

    public ApplyBindingsDelegate = () => void {}

    constructor(public service: BookService) { }

    public InitBooks(): void {
        this.service.GetBooks().done((result: any) => {
            if (result.IsSuccess) {
                this.Model.Books = ko.observableArray(this.ConvertResponse(result.Model));
                this.ApplyBindingsDelegate();
            }
        });
    }

    public GetBooksUrl(): string {
        return this.service.urls.GetBooksUrl;
    }

    private ConvertResponse = (books: Book[]): BookModel[] => {
        return books.map((book: Book) => {
            var result = new BookModel(book);
            return result;
        });
    }
}