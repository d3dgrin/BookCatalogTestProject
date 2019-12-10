class BookController {

    constructor(private business: BookBusiness, private grid: BookGridController) {
        this.grid.DrawCallback = this.OnDrawCallback;
    }

    public OnDrawCallback = (data: Book[]): void => {
        this.business.Model.Books = this.MapToObservable(this.business.ConvertResponse(data));
        ko.applyBindings(this.business.Model, $('#book-tbody')[0]);
    }

    private MapToObservable(books: BookModel[]): KnockoutObservableArray<BookModel> {
        return ko.observableArray(books);
    }
}