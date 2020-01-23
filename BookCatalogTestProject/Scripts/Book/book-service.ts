class BookService {
    constructor(public urls: BookUrlModel) {
    }

    public GetBooks(): JQueryXHR {
        return $.get(this.urls.GetBooksUrl);
    }
}