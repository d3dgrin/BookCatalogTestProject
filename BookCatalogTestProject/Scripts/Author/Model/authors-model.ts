class AuthorsModel {
    public Authors: KnockoutObservableArray<AuthorModel> = ko.observableArray<AuthorModel>([]);
    public AuthorEdit: AuthorModel = new AuthorModel();

    OnEditSave: (model: AuthorsModel, event: Event) => void;
    OnAdd: (model: AuthorsModel, event: Event) => void;
    OnAddSave: (model: AuthorsModel, event: Event) => void;
}