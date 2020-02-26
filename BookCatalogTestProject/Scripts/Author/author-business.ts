class AuthorBusiness {

    public Model: AuthorModel = new AuthorModel();

    constructor(public service: AuthorService) {
        this.Model.OnAddClick = this.OnAddClick;
        this.Model.AuthorModal.OnEditSaveClick = this.OnAddSaveClick;
    }

    public GetAuthorsUrl = () => this.service.urls.GetAuthorsUrl;

    public ConvertResponse = (items: AuthorItem[]): AuthorItemModel[] => {
        return items.map((item: AuthorItem) => {
            var result = new AuthorItemModel(item);

            result.OnEditClick = this.OnEditClick;
            result.OnEditSaveClick = this.OnEditSaveClick;
            result.OnDeleteClick = this.OnDeleteClick;

            return result;
        });
    }

    private OnAddClick = (): void => {
        this.Model.AuthorModal.Name('');
        this.Model.AuthorModal.Surname('');
        ko.cleanNode($('#editAuthorModal')[0]);
        ko.applyBindings(this.Model.AuthorModal, $('#editAuthorModal')[0]);
        $('#editAuthorModal').modal('toggle');
    }

    private OnAddSaveClick = (model: AuthorItemModel): void => {
        this.service.CreateAuthor(model).done(function () {
            $('#editAuthorModal').modal('toggle');
            $(document).trigger('grid.reload', null);
        });
    }

    private OnEditClick = (model: AuthorItemModel): void => {
        ko.cleanNode($('#editAuthorModal')[0]);
        ko.applyBindings(model, $('#editAuthorModal')[0]);
        $('#editAuthorModal').modal('toggle');
    }

    private OnEditSaveClick = (model: AuthorItemModel): void => {
        this.service.UpdateAuthor(model).done(function () {
            $('#editAuthorModal').modal('toggle');
            $(document).trigger('grid.reload', null);
        });
    }

    private OnDeleteClick = (model: AuthorItemModel): void => {
        this.service.DeleteAuthor(model.AuthorId()).done(function () {
            $(document).trigger('grid.reload', null);
        });
    }
}