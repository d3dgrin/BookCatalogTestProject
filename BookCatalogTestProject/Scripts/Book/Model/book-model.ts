﻿class BookModel {
    public Id: KnockoutObservable<number> = ko.observable(null);
    public Title: KnockoutObservable<string> = ko.observable(null);
    public PublicationDate: KnockoutObservable<string> = ko.observable(null);
    public Rating: KnockoutObservable<number> = ko.observable(null);
    public PagesCount: KnockoutObservable<number> = ko.observable(null);

    OnEdit: (model: BookModel, event: Event) => void;
    OnDelete: (model: BookModel, event: Event) => void;
}