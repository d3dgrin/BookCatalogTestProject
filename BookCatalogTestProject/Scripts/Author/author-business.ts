class AuthorBusiness {
    public Model: AuthorsModel = new AuthorsModel();

    constructor(public service: AuthorService) { }

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
            var result = new AuthorModel(author);

            result.OnEdit = this.OnEdit;

            return result;
        });
    }

    private OnEdit = (model: AuthorModel, event: Event): void => {
        this.Model.ShowEditBlock(true);
        this.Model.Name(model.Name());
        this.Model.Surname(model.Surname());
        //this.Model.Authors().push(model);
        //ko.applyBindings(this.Model);
        //this.Model.Authors.valueHasMutated();
    }
}