class AuthorService {
    constructor(public urls: AuthorUrlModel) {
    }

    public GetAuthors(): JQueryXHR {
        return $.get(this.urls.GetAuthorsUrl);
    }
}