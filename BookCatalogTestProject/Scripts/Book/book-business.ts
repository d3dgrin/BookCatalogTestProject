class BookBusiness {
    public Model: BooksModel = new BooksModel();

    public InitDatatable = () => void {}

    constructor(public service: BookService) { }

    public InitBooks = () => {
        this.service.GetBooks().done((result: any) => {
            if (result.IsSuccess) {
                this.Model.Books = ko.observableArray(this.ConvertResponse(result.Model));
                this.ApplyBindings();
                this.InitDatatable();
            }
        });
    }

    public GetBooksUrl(): string {
        return this.service.urls.GetBooksUrl;
    }

    private ApplyBindings() {
        ko.applyBindings(this.Model);
    }

    private ConvertResponse = (books: Book[]): BookModel[] => {
        return books.map((book: Book) => {
            var result = new BookModel(book);
            return result;
        });
    }
}