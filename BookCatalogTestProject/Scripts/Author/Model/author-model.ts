class AuthorModel {
    constructor(model: Author) {
        this.Id(model.Id);
        this.Name(model.Name);
        this.Surname(model.Surname);
    }

    public Id: KnockoutObservable<number> = ko.observable(null);
    public Name: KnockoutObservable<string> = ko.observable(null);
    public Surname: KnockoutObservable<string> = ko.observable(null);

    OnEdit: (model: AuthorModel, event: Event) => void;
}