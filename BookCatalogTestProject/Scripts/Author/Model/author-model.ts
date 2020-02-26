class AuthorModel {
    constructor() {
    }

    public Authors: KnockoutObservableArray<AuthorItemModel> = ko.observableArray<AuthorItemModel>([]);
    public AuthorModal: AuthorItemModel = new AuthorItemModel({AuthorId: 0, Name: '', Surname: ''});

    public AddClick: () => void = () => { this.OnAddClick(); };

    public OnAddClick: () => void = () => { };
}