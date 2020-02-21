class AuthorController {

    private dataTableBodySelector: string = '#authors_tbody';

    constructor(public business: AuthorBusiness, public gridController: AuthorGridController) {
        this.gridController.DrawCallback = this.OnDrawCallback;
    }

    public OnDrawCallback = (data: AuthorItem[]): void => {
        if (data.length === 0) {
            return;
        }

        this.business.Model.Authors = this.MapToObservable(this.business.ConvertResponse(data));

        ko.applyBindings(this.business.Model, $(this.dataTableBodySelector)[0]);
    }

    private MapToObservable(data: AuthorItemModel[]): KnockoutObservableArray<AuthorItemModel> {
        return ko.observableArray(data);
    }








    //constructor(private business: AuthorBusiness) {

    //}

    //public Initialize = () => {
    //    this.business.GetAuthors();
    //}
}