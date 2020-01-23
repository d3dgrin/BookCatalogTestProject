class AuthorService {
    constructor(public urls: AuthorUrlModel) {
    }

    public GetAuthors(): JQueryXHR {
        return $.get(this.urls.GetAuthorsUrl);
    }

    public UpdateAuthor(data: AuthorModel): JQueryXHR {
        return $.post(this.urls.UpdateAuthorUrl, { Id: data.Id(), Name: data.Name(), Surname: data.Surname() })
    }
}