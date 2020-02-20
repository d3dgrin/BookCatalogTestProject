﻿class HomeItemModel {

    constructor(model: HomeItem) {
        this.BookId(model.BookId);
        this.Title(model.Title);
        this.PublicationDate(model.PublicationDate);
        this.Rating(model.Rating);
        this.PagesCount(model.PagesCount);
    }

    public BookId: KnockoutObservable<number> = ko.observable(null);
    public Title: KnockoutObservable<string> = ko.observable(null);
    public PublicationDate: KnockoutObservable<string> = ko.observable(null);
    public Rating: KnockoutObservable<number> = ko.observable(null);
    public PagesCount: KnockoutObservable<number> = ko.observable(null);

    public EditClick: () => void = () => { this.OnEditClick(this); };


    public OnEditClick: (model: HomeItemModel) => void = (model: HomeItemModel) => { };
}