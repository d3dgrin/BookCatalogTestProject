class AuthorItemModel {

    constructor(model: AuthorItem) {
        this.AuthorId(model.AuthorId);
        this.Name(model.Name);
        this.Surname(model.Surname);
    }

    public AuthorId: KnockoutObservable<number> = ko.observable(null);
    public Name: KnockoutObservable<string> = ko.observable(null);
    public Surname: KnockoutObservable<string> = ko.observable(null);

    public EditClick: () => void = () => { this.OnEditClick(this); };
    public EditSaveClick: () => void = () => { this.OnEditSaveClick(this); };
    public DeleteClick: () => void = () => { this.OnDeleteClick(this); };


    public OnEditClick: (model: AuthorItemModel) => void = (model: AuthorItemModel) => { };
    public OnEditSaveClick: (model: AuthorItemModel) => void = (model: AuthorItemModel) => { };
    public OnDeleteClick: (model: AuthorItemModel) => void = (model: AuthorItemModel) => { };
}