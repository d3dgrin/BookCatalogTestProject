class BookController {

    private dataTableBodySelector: string = '#books_tbody';
    private booksGridSelector: string = '#books_grid';

    constructor(public business: BookBusiness, public gridController: BookGridController) {
        this.gridController.DrawCallback = this.OnDrawCallback;
        this.InitializeValidation();
    }

    public OnDrawCallback = (data: BookItem[]): void => {
        if (data.length === 0) {
            return;
        }

        this.business.Model.Books = this.MapToObservable(this.business.ConvertResponse(data));

        ko.cleanNode($(this.booksGridSelector)[0]);
        ko.applyBindings(this.business.Model, $(this.booksGridSelector)[0]);
    }

    private MapToObservable(data: BookItemModel[]): KnockoutObservableArray<BookItemModel> {
        return ko.observableArray(data);
    }

    private InitializeValidation = (): void => {
        //$('#bookModalForm').validate({
        //    rules: {
        //        bookTitle: {
        //            required: true
        //        }
        //    }
        //});
    }
}