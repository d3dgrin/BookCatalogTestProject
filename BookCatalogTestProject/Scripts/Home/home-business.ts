class HomeBusiness {
    public Model: HomeModel = new HomeModel();

    constructor(public service: HomeService) { }

    public GetBooksUrl = () => this.service.urls.GetBooksUrl;

    public ConvertResponse = (items: HomeItem[]): HomeItemModel[] => {
        return items.map((item: HomeItem) => {
            var result = new HomeItemModel(item);

            result.OnEditClick = this.OnEditClick;

            return result;
        });
    }

    private OnEditClick = (model: HomeItemModel): void => {
        debugger;
    }
}
