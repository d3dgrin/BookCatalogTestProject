class BookService {
    constructor(public urls: BookUrlModel) {
    }

    public GetAuthors(): JQueryXHR {
        return $.get(this.urls.GetBooksUrl);
    }
}