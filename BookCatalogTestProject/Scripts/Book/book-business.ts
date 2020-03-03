class BookBusiness {
    public Model: BookModel = new BookModel();

    constructor(public service: BookService) {
        this.Model.OnAddClick = this.OnAddClick;
        this.Model.BookModal.OnEditSaveClick = this.OnAddSaveClick;
    }

    public GetBooksUrl = () => this.service.urls.GetBooksUrl;

    public ConvertResponse = (items: BookItem[]): BookItemModel[] => {
        return items.map((item: BookItem) => {
            var result = new BookItemModel(item);

            result.OnEditClick = this.OnEditClick;
            result.OnEditSaveClick = this.OnEditSaveClick;
            result.OnDeleteClick = this.OnDeleteClick;

            return result;
        });
    }

    public GetAuthors = (): void => {
        debugger;
        this.service.GetAuthors().done((data) => {
            debugger;
            this.Model.Authors = ko.observableArray(data.Model);
        });
    }

    private OnAddClick = (): void => {
        this.Model.BookModal.Title('');
        this.Model.BookModal.PublicationDate('');
        this.Model.BookModal.Rating(0);
        this.Model.BookModal.PagesCount(0);
        this.Model.SelectedAuthors = ko.observableArray<number>([]);

        ko.cleanNode($('#bookModal')[0]);
        ko.applyBindings(this.Model, $('#bookModal')[0]);
        $('#bookModal').modal('toggle');
    }

    private OnAddSaveClick = (model: BookItemModel): void => {
        this.service.CreateBook(model).done(function () {
            $('#bookModal').modal('toggle');
            $(document).trigger('grid.reload', null);
        });
    }

    private OnEditClick = (model: BookItemModel): void => {
        ko.cleanNode($('#bookModal')[0]);
        ko.applyBindings(model, $('#bookModal')[0]);
        $('#bookModal').modal('toggle');
    }

    private OnEditSaveClick = (model: BookItemModel): void => {
        this.service.UpdateBook(model).done(function () {
            $('#bookModal').modal('toggle');
            $(document).trigger('grid.reload', null);
        });
    }

    private OnDeleteClick = (model: BookItemModel): void => {
        this.service.DeleteBook(model.BookId()).done(function () {
            $(document).trigger('grid.reload', null);
        });
    }
}