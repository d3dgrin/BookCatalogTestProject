class AuthorController {

    private dataTableBodySelector: string = '#authors_tbody';
    private authorsGridSelector: string = '#authors_grid';

    constructor(public business: AuthorBusiness, public gridController: AuthorGridController) {
        this.gridController.DrawCallback = this.OnDrawCallback;
    }

    public OnDrawCallback = (data: AuthorItem[]): void => {
        if (data.length === 0) {
            return;
        }

        this.business.Model.Authors = this.MapToObservable(this.business.ConvertResponse(data));

        ko.cleanNode($(this.authorsGridSelector)[0]);
        ko.applyBindings(this.business.Model, $(this.authorsGridSelector)[0]);
    }

    private MapToObservable(data: AuthorItemModel[]): KnockoutObservableArray<AuthorItemModel> {
        return ko.observableArray(data);
    }
}