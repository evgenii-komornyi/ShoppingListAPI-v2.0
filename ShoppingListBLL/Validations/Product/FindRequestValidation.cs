using Models.Errors;
using Models.Requests;

namespace ShoppingListBLL.Validations
{
    public class FindRequestValidation : IValidatable<ProductFindRequest, ProductValidationErrors>
    {
        public List<ProductValidationErrors> Validate(ProductFindRequest findFieldRequest)
        {
            return new List<ProductValidationErrors>(ValidateSearchCriteria(findFieldRequest));
        }

        private List<ProductValidationErrors> ValidateSearchCriteria(ProductFindRequest searchCriteria)
        {
            List<ProductValidationErrors> allErrors = new List<ProductValidationErrors>();

            if (searchCriteria.Id == 0)
            {
                allErrors.Add(ProductValidationErrors.No_search_criteria);
            }

            return allErrors;
        }
    }
}
