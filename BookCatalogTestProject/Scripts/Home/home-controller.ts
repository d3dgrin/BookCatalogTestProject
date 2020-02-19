class HomeController {
    private dataTableBodySelector: string = '#books_tbody';

    constructor(public business: HomeBusiness, public gridController: HomeGridController) {
        this.gridController.DrawCallback = this.OnDrawCallback;
    }

    public OnDrawCallback = (data: HomeItem[]): void => {
        if (data.length === 0) {
            return;
        }

        this.business.Model.Books = this.MapToObservable(this.business.ConvertResponse(data));

        ko.applyBindings(this.business.Model, $(this.dataTableBodySelector)[0]);
    }

    private MapToObservable(data: HomeItemModel[]): KnockoutObservableArray<HomeItemModel> {
        return ko.observableArray(data);
    }
}