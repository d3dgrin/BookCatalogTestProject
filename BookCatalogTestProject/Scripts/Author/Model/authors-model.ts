class AuthorsModel {
    public Authors: KnockoutObservableArray<AuthorModel> = ko.observableArray<AuthorModel>([]);
    public ShowEditBlock: KnockoutObservable<boolean> = ko.observable(false);

    public Id: KnockoutObservable<number> = ko.observable(null);
    public Name: KnockoutObservable<string> = ko.observable(null);
    public Surname: KnockoutObservable<string> = ko.observable(null);
}