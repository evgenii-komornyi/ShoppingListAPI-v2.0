using Microsoft.Data.SqlClient;
using Models.Errors;
using Models.Requests;
using Models.Responses;
using ShoppingListBLL.Validations;
using ShoppingListDAL.Repositories;

namespace ShoppingListBLL.Services
{
    public class ProductService : IProductService
    {
        readonly IProductRepository _repository;
        readonly ProductValidation _validation;

        public ProductService(IProductRepository repository, ProductValidation validation)
        {
            _repository = repository;
            _validation = validation;
        }

        public ProductFindResponse FindAll()
        {
            var response = new ProductFindResponse();
            var dbErrors = new List<DatabaseErrors>();

            try
            {
                response.ListOfFoundProducts = _repository.ReadAll();
            }
            catch (SqlException)
            {
                dbErrors.Add(DatabaseErrors.DB_CONNECTION_FAILED);
            }
            response.DBErrors = dbErrors;

            return response;
        }

        public ProductFindResponse FindById(ProductFindRequest request)
        {
            var response = new ProductFindResponse();
            var validationErrors = _validation.FindRequestValidation.Validate(request);
            var dbErrors = new List<DatabaseErrors>();

            if (validationErrors.Count != 0)
            {
                response.ValidationErrors = validationErrors;
            }
            else
            {
                try
                {
                    response.FoundProduct = _repository.ReadSingle(request);
                }
                catch (SqlException)
                {
                    dbErrors.Add(DatabaseErrors.DB_CONNECTION_FAILED);
                }
                catch (NullReferenceException)
                {
                    validationErrors.Add(ProductValidationErrors.Product_Not_Found);
                }
                response.DBErrors = dbErrors;
            }

            return response;
        }
    }
}
