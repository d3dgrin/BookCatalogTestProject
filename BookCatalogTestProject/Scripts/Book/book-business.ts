class BookBusiness {
    public Model: BooksModel = new BooksModel();

    constructor(public service: BookService) { }

    public GetBooksUrl(): string {
        return this.service.urls.GetBooksUrl;
    }

    public ConvertResponse = (books: Book[]): BookModel[] => {
        return books.map((book: Book) => {
            var result = new BookModel(book);
            return result;
        });
    }
}