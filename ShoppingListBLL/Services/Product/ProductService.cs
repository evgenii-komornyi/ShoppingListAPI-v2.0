using Microsoft.Data.SqlClient;
using Models;
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

        public ProductCreateResponse CreateProduct(ProductCreateRequest request)
        {
            var response = new ProductCreateResponse();
            List<ProductValidationErrors> validationErrors = _validation.CreateRequestValidation.Validate(request);
            var dbErrors = new List<DatabaseErrors>();

            if (validationErrors.Count != 0)
            {
                response.ValidationErrors = validationErrors;
            }
            else
            {
                try
                {
                    var product = AddProductToDB(request);

                    if (product == null) throw new NullReferenceException("Product not found");

                    response.Product = product;
                }
                catch (NullReferenceException)
                {
                    dbErrors.Add(DatabaseErrors.DB_CONNECTION_FAILED);

                }
                response.DBErrors = dbErrors;
            }

            return response;
        }

        private Product AddProductToDB(ProductCreateRequest request)
        {
            return _repository.Create(
                new Product
                {
                    Title = request.Title,
                    Brand = request.Brand,
                    Price = request.Price,
                    Description = request.Description,
                    IsAvailable = request.IsAvailable,
                    IsInStock = request.IsInStock,
                    CreationDate = DateTime.Now,
                    CategoryId = request.CategoryId
                }
            );
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
            List<ProductValidationErrors> validationErrors = _validation.FindRequestValidation.Validate(request);
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
