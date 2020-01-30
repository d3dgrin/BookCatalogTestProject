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

    public GetAuthors2 = () => {
        this.service.GetAuthors().done((result: any) => {
            if (result.IsSuccess) {
                this.Model.Authors = ko.observableArray(this.ConvertResponse(result.Model));
            }
        });
    }

    private ConvertResponse = (authors: Author[]): AuthorModel[] => {
        return authors.map((author: Author) => {
            var result = new AuthorModel();
            result.Id(author.Id);
            result.Name(author.Name);
            result.Surname(author.Surname);

            result.OnEdit = this.OnEdit;
            result.OnDelete = this.OnDelete;

            return result;
        });
    }

    private OnEdit = (model: AuthorModel, event: Event): void => {
        this.Model.AuthorEdit.Id(model.Id());
        this.Model.AuthorEdit.Name(model.Name());
        this.Model.AuthorEdit.Surname(model.Surname());
        //this.Model.ShowEditBlock(true);

        $('#editAuthorModal').modal('show');
    }

    private OnDelete = (model: AuthorModel, event: Event): void => {
        this.service.DeleteAuthor(model.Id()).done((result: any) => {
            if (result.IsSuccess) {
                this.GetAuthors2();
            }
        });
    }

    private OnEditSave = (model: AuthorsModel, event: Event): void => {
        this.service.UpdateAuthor(model.AuthorEdit).done((result: any) => {
            if (result.IsSuccess) {
                this.Model.ShowEditBlock(false);
                let id = model.AuthorEdit.Id();
                let author = this.Model.Authors().filter(a => {
                    return a.Id() == id;
                })[0];
                author.Name(model.AuthorEdit.Name());
                author.Surname(model.AuthorEdit.Surname());
            }
        });
    }

    private OnAdd = (model: AuthorsModel, event: Event): void => {
        this.ClearModalBindings();
        $('#createAuthorModal').modal('show');
    }

    private OnAddSave = (model: AuthorsModel, event: Event): void => {
        this.service.CreateAuthor(model.AuthorEdit).done((result: any) => {
            if (result.IsSuccess) {
                var newModel = new AuthorModel();
                newModel.Id(result.Model.Id);
                newModel.Name(result.Model.Name);
                newModel.Surname(result.Model.Surname);
                newModel.OnEdit = this.OnEdit;
                newModel.OnDelete = this.OnDelete;

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
}