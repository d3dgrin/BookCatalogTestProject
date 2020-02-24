﻿class AuthorModel {
    constructor() {
    }

    public Authors: KnockoutObservableArray<AuthorItemModel> = ko.observableArray<AuthorItemModel>([]);
    public AuthorModal: AuthorItemModel = new AuthorItemModel({AuthorId: 0, Name: '', Surname: ''});

    public AddClick: () => void = () => { this.OnAddClick(); };

    public OnAddClick: () => void = () => { };

    //public AuthorId: KnockoutObservable<number> = ko.observable(null);
    //public Name: KnockoutObservable<string> = ko.observable(null);
    //public Surname: KnockoutObservable<string> = ko.observable(null);

    //OnEdit: (model: AuthorModel, event: Event) => void;
    //OnDelete: (model: AuthorModel, event: Event) => void;
}