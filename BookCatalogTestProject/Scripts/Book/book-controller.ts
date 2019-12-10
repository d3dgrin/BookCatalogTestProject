//declare var Datatable: any;

class BookController {

    constructor(public business: BookBusiness) {
        this.business.InitDatatable = this.InitDatatable;
    }

    public Initialize(): void {
        this.business.InitBooks();
    }

    private InitDatatable = () => {
        $("#books-table").DataTable({
            data: this.business.Model.Books(),
            columns: [
                { data: "Id" },
                { data: "Title" },
                { data: "PublicationDate" },
                { data: "Rating" },
                { data: "PagesCount" }
            ]
        });
    }

    //public OnDrawCallback = (data: any): void => {
    //    this.business.Model.Books = this.MapToObservable(this.business.ConvertResponse(data));

    //    ko.applyBindings(this.business.Model, $('#book_tbody')[0]);
    //}

    //private MapToObservable(books: BookModel[]): KnockoutObservableArray<BookModel> {
    //    return ko.observableArray(books);
    //}
}