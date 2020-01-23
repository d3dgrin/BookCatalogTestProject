class AuthorsModel {
    public Authors: KnockoutObservableArray<AuthorModel> = ko.observableArray<AuthorModel>([]);
    public AuthorEdit: AuthorModel = new AuthorModel();
    public ShowEditBlock: KnockoutObservable<boolean> = ko.observable(false);

    OnEditSave: (model: AuthorsModel, event: Event) => void;
}