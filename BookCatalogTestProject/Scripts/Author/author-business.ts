class AuthorBusiness {
    public Model: AuthorsModel = new AuthorsModel();

    constructor(public service: AuthorService) {
        this.Model.OnEditSave = this.OnEditSave;
    }

    public GetAuthors = () => {
        this.service.GetAuthors().done((result: any) => {
            if (result.IsSuccess) {
                this.Model.Authors = ko.observableArray(this.ConvertResponse(result.Model));
                ko.applyBindings(this.Model);
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

            return result;
        });
    }

    private OnEdit = (model: AuthorModel, event: Event): void => {
        this.Model.AuthorEdit.Id(model.Id());
        this.Model.AuthorEdit.Name(model.Name());
        this.Model.AuthorEdit.Surname(model.Surname());
        this.Model.ShowEditBlock(true);
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
}