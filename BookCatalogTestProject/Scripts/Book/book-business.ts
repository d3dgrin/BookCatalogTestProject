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
            result.PublicationDate(moment(result.PublicationDate()).format('MM/DD/YYYY'));

            result.OnEditClick = this.OnEditClick;
            result.OnEditSaveClick = this.OnEditSaveClick;
            result.OnDeleteClick = this.OnDeleteClick;

            return result;
        });
    }

    public GetAuthors = (): void => {
        this.service.GetAuthors().done((data) => {
            this.Model.Authors = ko.observableArray(data.Model);
        });
    }

    private OnAddClick = (): void => {
        this.Model.BookModal.Title(null);
        this.Model.BookModal.PublicationDate(null);
        this.Model.BookModal.Rating(null);
        this.Model.BookModal.PagesCount(null);
        this.Model.SelectedAuthors = ko.observableArray<number>([]);

        ko.cleanNode($('#bookModal')[0]);
        ko.applyBindings(this.Model, $('#bookModal')[0]);
        $('#bookAuthors').select2();
        $('#bookPublicationDate').datepicker({
            dateFormat: 'dd/mm/yy'
        });
        $('#bookModal').modal('show');
    }

    private OnAddSaveClick = (model: any): void => {
        this.service.CreateBook(model).done(function () {
            $('#bookModal').modal('hide');
            $(document).trigger('grid.reload', null);
        });
    }

    private OnEditClick = (model: BookItemModel): void => {
        this.Model.BookModal = model;
        ko.cleanNode($('#bookModal')[0]);
        ko.applyBindings(this.Model, $('#bookModal')[0]);
        $('#bookAuthors').select2();
        $('#bookPublicationDate').datepicker({
            dateFormat: 'dd/mm/yy'
        });
        $('#bookModal').modal('show');
    }

    private OnEditSaveClick = (model: BookItemModel): void => {
        this.service.UpdateBook(model).done(function () {
            $('#bookModal').modal('hide');
            $(document).trigger('grid.reload', null);
        });
    }

    private OnDeleteClick = (model: BookItemModel): void => {
        this.service.DeleteBook(model.BookId()).done(function () {
            $(document).trigger('grid.reload', null);
        });
    }
}