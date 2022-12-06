using Models.Errors;
using Models.Requests;
using System.Xml.Linq;

namespace ShoppingListBLL.Validations
{
    public class CreateRequestValidation : IValidatable<ProductCreateRequest, ProductValidationErrors>
    {
        public List<ProductValidationErrors> Validate(ProductCreateRequest request)
        {
            List<ProductValidationErrors> allErrors = new List<ProductValidationErrors>();

            allErrors.AddRange(ValidateNameField(request.Title));
            allErrors.AddRange(ValidateBrandField(request.Brand));
            allErrors.AddRange(ValidatePriceField(request.Price));
            allErrors.AddRange(ValidateCategoryField(request.CategoryId));
            /*allErrors.AddRange(ValidateRangeOfDiscount(request.Discount));*/
            allErrors.AddRange(ValidateDescriptionField(request.Description));
            
            /*allErrors.AddRange(ValidateDiscountPossibility(request.Price,request.Discount));*/
            /*allErrors.AddRange(ValidateFileNameField(createFieldRequest.File_Id));*/

            return allErrors;
        }

        private List<ProductValidationErrors> ValidateNameField(string name)
        {
            List<ProductValidationErrors> errorsList = new List<ProductValidationErrors>();
            string trimmedName = name.Trim();
            if (trimmedName == null || trimmedName.Length == 0)
            {
                errorsList.Add(ProductValidationErrors.Empty_name);
            } else if (trimmedName.Length < 3 || trimmedName.Length > 32)
            {
                errorsList.Add(ProductValidationErrors.Name_length_violation);
            }

            return errorsList;
        }

        private List<ProductValidationErrors> ValidateBrandField(string brand)
        {
            List<ProductValidationErrors> errorsList = new List<ProductValidationErrors>();
            string trimmedBrand = brand.Trim();
            if (trimmedBrand == null || trimmedBrand.Length == 0)
            {
                errorsList.Add(ProductValidationErrors.Empty_brand);
            } else if (trimmedBrand.Length < 2 || trimmedBrand.Length > 32)
            {
                errorsList.Add(ProductValidationErrors.Brand_length_violation);
            }

            return errorsList;
        }

        private List<ProductValidationErrors> ValidatePriceField(decimal price)
        {
            List<ProductValidationErrors> errorsList = new List<ProductValidationErrors>();

            if (price == null)
            {
                errorsList.Add(ProductValidationErrors.Empty_price);
            } else
            {
                errorsList.AddRange(NegativeNumberCheck(price));
            }

            return errorsList;
        }

        private List<ProductValidationErrors> NegativeNumberCheck(decimal price)
        {
            List<ProductValidationErrors> errorsList = new List<ProductValidationErrors>();

            if (price.CompareTo(Decimal.Zero) <= 0)
            {
                errorsList.Add(ProductValidationErrors.Negative_or_zero_price);
            }

            return errorsList;
        }

        /*private List<ProductValidationErrors> ValidateDiscountPossibility(decimal price, decimal discount)
        {
            List<ProductValidationErrors> errorsList = new List<ProductValidationErrors>();

            if (price != null && discount != null)
            {
                if (price.CompareTo(20) < 0
                        && discount.CompareTo(Decimal.Zero) != 0)
                {
                    errorsList.Add(ProductValidationErrors.Discount_application_limit_violation);
                }
            }

            return errorsList;
        }*/

        private List<ProductValidationErrors> ValidateCategoryField(int category_id)
        {
            List<ProductValidationErrors> errorsList = new List<ProductValidationErrors>();

            if (category_id == null)
            {
                errorsList.Add(ProductValidationErrors.Empty_category);
            }

            return errorsList;
        }

        /*private List<ProductValidationErrors> ValidateRangeOfDiscount(decimal discount)
        {
            List<ProductValidationErrors> errorsList = new List<ProductValidationErrors>();

            if (discount != null)
            {
                if (discount.CompareTo(Decimal.Zero) < 0
                        || discount.CompareTo(100) > 0)
                {
                    errorsList.Add(ProductValidationErrors.Invalid_discount_range);
                }
            }

            return errorsList;
        }*/

        private List<ProductValidationErrors> ValidateDescriptionField(string description)
        {
            List<ProductValidationErrors> errorsList = new List<ProductValidationErrors>();

            if (description != null)
            {
                if (description.Length < 8 || description.Length > 300)
                {
                    errorsList.Add(ProductValidationErrors.Description_length_violation);
                }
            }

            return errorsList;
        }
    }
}
