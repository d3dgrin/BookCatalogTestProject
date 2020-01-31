class AuthorBusiness {
    public Model: AuthorsModel = new AuthorsModel();

    constructor(public service: AuthorService) {
        this.Model.OnEditSave = this.OnEditSave;
        this.Model.OnAdd = this.OnAdd;
        this.Model.OnAddSave = this.OnAddSave;
    }

    public GetAuthors = () => {
        this.service.GetAuthors().done((result: any) => {
            if (result.IsSuccess) {
                ko.cleanNode(window.document.body);
                this.Model.Authors = ko.observableArray(this.ConvertResponse(result.Model));
                ko.applyBindings(this.Model);
            }
        });
    }

    private ConvertResponse = (authors: Author[]): AuthorModel[] => {
        return authors.map((author: Author) => {
            var result = this.MapModel(author);
            return result;
        });
    }

    private OnEdit = (model: AuthorModel, event: Event): void => {
        this.Model.AuthorEdit.Id(model.Id());
        this.Model.AuthorEdit.Name(model.Name());
        this.Model.AuthorEdit.Surname(model.Surname());

        $('#editAuthorModal').modal('show');
    }

    private OnDelete = (model: AuthorModel, event: Event): void => {
        this.service.DeleteAuthor(model.Id()).done((result: any) => {
            if (result.IsSuccess) {
                this.Model.Authors.remove((author: AuthorModel) => author.Id() === model.Id());
            }
        });
    }

    private OnEditSave = (model: AuthorsModel, event: Event): void => {
        this.service.UpdateAuthor(model.AuthorEdit).done((result: any) => {
            if (result.IsSuccess) {
                let author = this.Model.Authors().filter(a => a.Id() === model.AuthorEdit.Id())[0];
                author.Name(model.AuthorEdit.Name());
                author.Surname(model.AuthorEdit.Surname());
            }
        });
        $('#editAuthorModal').modal('hide');
    }

    private OnAdd = (model: AuthorsModel, event: Event): void => {
        this.ClearModalBindings();
        $('#createAuthorModal').modal('show');
    }

    private OnAddSave = (model: AuthorsModel, event: Event): void => {
        this.service.CreateAuthor(model.AuthorEdit).done((result: any) => {
            if (result.IsSuccess) {
                var newModel = this.MapModel(result.Model);
                this.Model.Authors.push(newModel);
            }
        });
        $('#createAuthorModal').modal('hide');
    }

    private ClearModalBindings = (): void => {
        var element = $('#createAuthorModal')[0];
        ko.cleanNode(element);
        this.Model.AuthorEdit = new AuthorModel();
        ko.applyBindings(this.Model, element);
    }

    private MapModel = (data: any): AuthorModel => {
        var newModel = ko.mapping.fromJS(data);
        newModel.OnEdit = this.OnEdit;
        newModel.OnDelete = this.OnDelete;

        return newModel;
    }
}