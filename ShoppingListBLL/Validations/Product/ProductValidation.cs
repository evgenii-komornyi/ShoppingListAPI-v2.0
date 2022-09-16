namespace ShoppingListBLL.Validations
{
    public class ProductValidation
    {
        public FindRequestValidation FindRequestValidation;

        public ProductValidation(FindRequestValidation findRequestValidation)
        {
            FindRequestValidation = findRequestValidation;
        }
    }
}
