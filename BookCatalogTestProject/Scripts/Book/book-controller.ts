//declare var Datatable: any;

class BookController {

    constructor(public business: BookBusiness) {
        this.business.ApplyBindingsDelegate = this.ApplyBindings;
    }

    public Initialize(): void {
        this.business.InitBooks();
    }

    private ApplyBindings = () => {
        ko.applyBindings(this.business.Model);
    }

    //public OnDrawCallback = (data: any): void => {
    //    this.business.Model.Books = this.MapToObservable(this.business.ConvertResponse(data));

    //    ko.applyBindings(this.business.Model, $('#book_tbody')[0]);
    //}

    //private MapToObservable(books: BookModel[]): KnockoutObservableArray<BookModel> {
    //    return ko.observableArray(books);
    //}
}