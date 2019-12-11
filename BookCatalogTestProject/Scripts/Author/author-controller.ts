class AuthorController {
    constructor(private business: AuthorBusiness) {

    }

    public Initialize = () => {
        this.business.GetAuthors();
    }
}