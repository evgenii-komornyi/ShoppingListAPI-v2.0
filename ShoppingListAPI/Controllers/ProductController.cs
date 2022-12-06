using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Errors;
using Models.Requests;
using Models.Responses;
using ShoppingListBLL.Services;
using ShoppingListDTO;
using ShoppingListDTO.FileStorage;
using ShoppingListDTO.Product;

namespace ShoppingListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        readonly IProductService _productService;
        readonly IFileStorageService _fileService;
        readonly IWebHostEnvironment _environment;

        public ProductController(IProductService productService, IFileStorageService fileService, IWebHostEnvironment environment)
        {
            _productService = productService;
            _fileService = fileService;
            _environment = environment;
        }

        [HttpGet("products")]
        public ListProductsDTO GetProducts()
        {
            var productDTOList = new List<ProductDTO>();
            var productList = _productService.FindAll().ListOfFoundProducts;

            foreach (var product in productList)
            {
                productDTOList.Add(СonvertProductToDTO(product));
            }

            return new ListProductsDTO
            {
                products = productDTOList,
                status = Status.Success
            };
        }

        [HttpGet("products/{id}")]
        public FindProductDTO? GetProductById(int id)
        {
            return new FindProductDTO
            {
                product = СonvertProductByIdToDTO(_productService.FindById(new ProductFindRequest
                {
                    Id = id
                }).FoundProduct)
            };
        }

        [HttpPost]
        public CreateProductDTO Create(ProductCreateRequest request)
        {
            ProductCreateResponse product = _productService.CreateProduct(request);
            var responseJson = new CreateProductDTO();

            if (product.HasValidationErrors() || product.HasDBErrors())
            {
                responseJson.validationErrors = ConvertErrorsToString(product.ValidationErrors);
                responseJson.dbErrors = product.DBErrors;
                responseJson.status = Status.Failed;
            }
            else
            {
                responseJson.newProduct = product;
                
                responseJson.status = Status.Success;
            }

            return responseJson;
        }

        [HttpPost("upload")]
        public UploadFileDTO UploadFiles(int productId, List<IFormFile> files)
        {
            var responseJson = new UploadFileDTO();
            var filesList = new List<string>();
            bool isUploaded = false;

            foreach (var file in files)
            {
                filesList.Add(file.FileName);

                isUploaded = _fileService.UploadFile(_environment.WebRootPath, file, productId);
                SaveFiles(productId, file.FileName);
            }

            if (!isUploaded)
            {
                responseJson.status = Status.Failed;
            }

            responseJson.uploadedFiles = filesList;
            responseJson.status = Status.Success;

            return responseJson;
        }

        private FileStorageCreateResponse SaveFiles(int productId, string fileName)
        {
            var fileRequest = new FileStorageCreateRequest
            {
                ProductId = productId,
                FileName = fileName,
            };

            return _fileService.SaveFile(fileRequest);
        }

        private ProductDTO СonvertProductToDTO(Product product) => 
            new ProductDTO
            {
                id = product.Id,
                title = product.Title,
                brand = product.Brand,
                category = product.Category.Name,
                price = product.Price,
                isAvailable = product.IsAvailable,
                inStock = product.IsInStock,
                files = ConvertFileStorageToDTO(product.Files.ToList())
            };

        private ProductByIdDTO СonvertProductByIdToDTO(Product product) =>
            new ProductByIdDTO
            {
                id = product.Id,
                title = product.Title,
                brand = product.Brand,
                category = product.Category.Name,
                price = product.Price,
                isAvailable = product.IsAvailable,
                inStock = product.IsInStock,
                files = ConvertFileStorageToDTO(product.Files.ToList()),
                description = product.Description,
                creationDate = product.CreationDate,
                categoryId = product.CategoryId,
            };

        private List<FileStorageDTO> ConvertFileStorageToDTO(List<FileStorage> files)
        {
            var listDTO = new List<FileStorageDTO>();

            foreach (var file in files) 
            {
                var dto = new FileStorageDTO
                {
                    fileName = file.Name
                };
                listDTO.Add(dto);
            }

            return listDTO;
        }

        private List<string> ConvertErrorsToString(List<ProductValidationErrors> errors)
        {
            List<string> convertedErrors = new List<string>();
            
            if (errors != null)
            {
                foreach (var error in errors)
                {
                    convertedErrors.Add(error.ToString());
                }

            }

            return convertedErrors;
        }
    }
}
