class AuthorModel {
    public Id: KnockoutObservable<number> = ko.observable(null);
    public Name: KnockoutObservable<string> = ko.observable(null);
    public Surname: KnockoutObservable<string> = ko.observable(null);

    OnEdit: (model: AuthorModel, event: Event) => void;
}