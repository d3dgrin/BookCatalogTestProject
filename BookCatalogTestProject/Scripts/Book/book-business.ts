class BookBusiness {
    public Model: BooksModel = new BooksModel();

    constructor(public service: BookService) { }

    public ConvertResponse = (books: Book[]): BookModel[] => {
        return books.map((book: Book) => {
            var result = new BookModel(book);
            return result;
        });
    }

    public GetBooksUrl(): string {
        return this.service.urls.GetBooksUrl;
    }

    //private InitBooks = () => {
    //    this.service.GetBooks().done((result: any) => {
    //        if (result.IsSuccess) {
    //            this.Model.Books = ko.observableArray(this.ConvertResponse(result.Model));
    //        }
    //    });
    //}
}