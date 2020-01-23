class BookBusiness {
    public Model: BooksModel = new BooksModel();

    OnBooksReceive: (model: BooksModel) => void;

    constructor(private service: BookService) { }

    public ConvertResponse = (books: Book[]): BookModel[] => {
        return books.map((book: Book) => {
            var result = new BookModel(book);
            return result;
        });
    }

    public GetBooksUrl(): string {
        return this.service.urls.GetBooksUrl;
    }

    public GetBooks = () => {
        this.service.GetBooks().done((result: any) => {
            if (result.IsSuccess) {
                this.Model.Books = ko.observableArray(this.ConvertResponse(result.Model));
                this.OnBooksReceive(this.Model);
            }
        });
    }

    

    //private InitBooks = () => {
    //    this.service.GetBooks().done((result: any) => {
    //        if (result.IsSuccess) {
    //            this.Model.Books = ko.observableArray(this.ConvertResponse(result.Model));
    //        }
    //    });
    //}
}