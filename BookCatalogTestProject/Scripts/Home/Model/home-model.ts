class HomeModel {
    constructor() {
    }

    public Books: KnockoutObservableArray<HomeItemModel> = ko.observableArray<HomeItemModel>([]);
}