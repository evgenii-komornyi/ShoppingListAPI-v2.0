namespace ShoppingListBLL.Validations
{
    public class ProductValidation
    {
        public CreateRequestValidation CreateRequestValidation;
        public FindRequestValidation FindRequestValidation;

        public ProductValidation(FindRequestValidation findRequestValidation, CreateRequestValidation createRequestValidation)
        {
            FindRequestValidation = findRequestValidation;
            CreateRequestValidation = createRequestValidation;
        }
    }
}
