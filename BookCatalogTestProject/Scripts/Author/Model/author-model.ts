class AuthorModel {
    constructor() {
    }

    public Authors: KnockoutObservableArray<AuthorItemModel> = ko.observableArray<AuthorItemModel>([]);

    //public AuthorId: KnockoutObservable<number> = ko.observable(null);
    //public Name: KnockoutObservable<string> = ko.observable(null);
    //public Surname: KnockoutObservable<string> = ko.observable(null);

    //OnEdit: (model: AuthorModel, event: Event) => void;
    //OnDelete: (model: AuthorModel, event: Event) => void;
}