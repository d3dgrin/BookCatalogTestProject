class HomeService {
    constructor(public urls: HomeUrlModel) {
    }

    public GetBooks(): JQueryXHR {
        return $.get(this.urls.GetBooksUrl);
    }

    //public CreateBook(data: HomeModel): JQueryXHR {
    //    return $.post(this.urls.CreateBookUrl,
    //        {
    //            Title: data.Title(), PublicationDate: data.PublicationDate(), Rating: data.Rating(), PagesCount: data.PagesCount()
    //        }
    //    );
    //}

    //public UpdateBook(data: HomeModel): JQueryXHR {
    //    return $.post(this.urls.UpdateBookUrl,
    //        {
    //            Id: data.BookId(), Title: data.Title(), PublicationDate: data.PublicationDate(), Rating: data.Rating(), PagesCount: data.PagesCount()
    //        }
    //    );
    //}
}